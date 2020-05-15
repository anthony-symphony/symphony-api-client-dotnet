using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;
using System.IO;
using System.Net.Http;
using apiClientDotNet.Clients.Constants;
using apiClientDotNet.Clients;

namespace apiClientDotNet
{
    public class MessageClient : ApiClient
    {
        public MessageClient(ISymClient client)
        {
            SymClient = client;
        }

        public InboundMessage SendMessage(string streamId, OutboundMessage message, bool appendTags = false)
        {
            var requestUri = new Uri(AgentConstants.CreateMessage.Replace("{sid}", streamId), UriKind.Relative);
            var payload = new MultipartFormDataContent();
            if (message.message != null)
            {
                payload.Add(new StringContent(message.message), "message");
            }
            if (message.data != null)
            {
                payload.Add(new StringContent(message.data), "data");
            }
            if (message.attachments != null && message.attachments.Count > 0)
            {
                foreach(var attachment in message.attachments)
                {
                    using(var memoryStream = new MemoryStream())
                    {
                    attachment.CopyTo(memoryStream);
                    var byteArray = memoryStream.ToArray();
                    var byteArrayContent = new ByteArrayContent(byteArray);
                    payload.Add(byteArrayContent, "attachment", Path.GetFileName(attachment.Name));
                    }
                }
            }
            var result = ExecuteRequest<InboundMessage>(HttpMethod.Post, requestUri, payload);
            return result.ParsedObject;
        }

        public InboundMessage ForwardMessage(string streamId, InboundMessage message)
        {
            OutboundMessage outboundMessage = new OutboundMessage();
            outboundMessage.message = message.message;
            outboundMessage.data = message.data;
            /*
            outboundMessage.attachments = new List<FileStream>();
            var inboundMessageAttachments = GetMessageAttachments(message);
            foreach (var attachment in inboundMessageAttachments) 
            {

            }
            */
            return SendMessage(streamId, outboundMessage, false);
        }

        public List<InboundMessage> GetMessagesFromStream(string streamId, long since, int? skip = null, int? limit = null)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("since", since);
            requestParams.AddParameter("skip", skip);
            requestParams.AddParameter("limit", limit);
            var requestUri = AgentConstants.GetMessages.Replace("{sid}", streamId) + requestParams.Query;
            var result = ExecuteRequest<List<InboundMessage>>(HttpMethod.Get, new Uri(requestUri, UriKind.Relative));
            return result.ParsedObject;
        }

        public byte[] GetAttachment(string streamId, string attachmentId, string messageId)
        {
            byte[] base64EncodedBytes;
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("messageId", messageId);
            requestParams.AddParameter("fileId", attachmentId);
            var requestUri = AgentConstants.GetAttachment.Replace("{sid}",streamId) + requestParams.Query;
            var response = AgentRequestClient.GetAsync(new Uri(requestUri)).Result;
            if (response.IsSuccessStatusCode)
            {
                var attachmentResponse = response.Content.ReadAsStringAsync().Result;
                base64EncodedBytes = System.Convert.FromBase64String(attachmentResponse);
            }
            else
            {
                HandleError(response);
                base64EncodedBytes = null;
            }
            return base64EncodedBytes;
        }

        public List<FileAttachment> GetMessageAttachments(InboundMessage message)
        {
            List<FileAttachment> result = new List<FileAttachment>();
            List<Attachment> messageAttachments = message.attachments;
            foreach (var attachment in messageAttachments)
            {
                var fileAttachment = new FileAttachment();
                fileAttachment.fileName = attachment.name;
                fileAttachment.size = attachment.size;
                fileAttachment.fileContent = GetAttachment(message.stream.streamId, attachment.id, message.messageId);
                result.Add(fileAttachment);
            }
            return result;
        }

        public MessageStatus GetMessageStatus(string messageId)
        {
            var requestUri = new Uri(PodConstants.GetMessageStatus.Replace("{mid}", messageId), UriKind.Relative);
            var result = ExecuteRequest<MessageStatus>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }


        #region Legacy Forwarders
        public InboundMessage sendMessage(string streamId, OutboundMessage message, bool appendTags)
        {
            return SendMessage(streamId, message,appendTags);
        }

        public InboundMessage forwardMessage(string streamId, InboundMessage message)
        {
            return ForwardMessage(streamId,message);
        }

        public List<InboundMessage> getMessagesFromStream(string streamId, long since, int? skip = null, int? limit = null)
        {
            return getMessagesFromStream(streamId,since,skip,limit);
        }

        public byte[] getAttachment(string streamId, string attachmentId, string messageId)
        {
            return GetAttachment(streamId,attachmentId,messageId);
        }

        public List<FileAttachment> getMessageAttachments(InboundMessage message)
        {
            return GetMessageAttachments(message);
        }

        public MessageStatus getMessageStatus(string messageId)
        {
            return GetMessageStatus(messageId);
        }
        #endregion
        //////////////////////
       /* public InboundMessageList messageSearch(Dictionary<String, String> query, int skip, int limit, Boolean orderAscending)
            {

            InboundMessageList result = null;
            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.SEARCHMESSAGES;


            if (skip > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&skip=" + skip;
                } else
                {
                    url = url + "?skip=" + skip;
                }
            }
            if (limit > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&limit=" + limit;
                }
                else
                {
                    url = url + "?limit=" + limit;
                }
            }
            if (orderAscending)
            {
                if (url.Contains("?"))
                {
                    url = url + "&sortDir=ASC";
                }
                else
                {
                    url = url + "?sortDir=ASC";
                }
            }
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            InboundMessageList inboundMessages = JsonConvert.DeserializeObject<InboundMessageList>(body);

            return inboundMessages;
        }

   /* public InboundImportMessageList importMessages(OutboundImportMessageList messageList) 
    {
            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.MESSAGEIMPORT;

            Response response
                    = botClient.getAgentClient().target(CommonConstants.HTTPSPREFIX + botClient.getConfig().getAgentHost() + ":" + botClient.getConfig().getAgentPort())
                    .path(AgentConstants.MESSAGEIMPORT)
                    .request(MediaType.APPLICATION_JSON)
                    .header("sessionToken",botClient.getSymAuth().getSessionToken())
                    .header("keyManagerToken", botClient.getSymAuth().getKmToken())
                    .post(Entity.entity(messageList,MediaType.APPLICATION_JSON));
            if (response.getStatusInfo().getFamily() != Response.Status.Family.SUCCESSFUL) {
            try
            {
                handleError(response, botClient);
            }
            catch (UnauthorizedException ex)
            {
                return importMessages(messageList);
            }
            return null;
        } else {
            return response.readEntity(InboundImportMessageList.class);
            }
        }

    public SuppressionResult suppressMessage(String id) throws SymClientException
{
    Response response
                = botClient.getAgentClient().target(CommonConstants.HTTPSPREFIX + botClient.getConfig().getPodHost() + ":" + botClient.getConfig().getPodPort())
                .path(PodConstants.MESSAGESUPPRESS.replace("{id}",id))
                .request(MediaType.APPLICATION_JSON)
                .header("sessionToken",botClient.getSymAuth().getSessionToken())
                .post(null);
        if (response.getStatusInfo().getFamily() != Response.Status.Family.SUCCESSFUL) {
        try
        {
            handleError(response, botClient);
        }
        catch (UnauthorizedException ex)
        {
            return suppressMessage(id);
        }
        return null;
    } else {
        return response.readEntity(SuppressionResult.class);
        }
    }

    public InboundShare shareContent(String streamId, OutboundShare shareContent) throws SymClientException
{
    Map<String,Object> map = new HashMap<>();
        map.put("content",shareContent);
        Response response
                = botClient.getAgentClient().target(CommonConstants.HTTPSPREFIX + botClient.getConfig().getAgentHost() + ":" + botClient.getConfig().getAgentPort())
                .path(AgentConstants.SHARE.replace("{sid}", streamId))
                .request(MediaType.APPLICATION_JSON)
                .header("sessionToken", botClient.getSymAuth().getSessionToken())
                .header("keyManagerToken", botClient.getSymAuth().getKmToken())
                .post(Entity.entity(map, MediaType.APPLICATION_JSON));
        if (response.getStatusInfo().getFamily() != Response.Status.Family.SUCCESSFUL) {
            try {
                handleError(response, botClient);
            } catch (UnauthorizedException ex){
                return shareContent(streamId, shareContent);
            }
            return null;
        }
            return response.readEntity(InboundShare.class);
    }*/

    }
}
