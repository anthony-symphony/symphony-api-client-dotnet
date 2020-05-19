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
            if (message.Message != null)
            {
                payload.Add(new StringContent(message.Message), "message");
            }
            if (message.Data != null)
            {
                payload.Add(new StringContent(message.Data), "data");
            }
            if (message.Attachments != null && message.Attachments.Count > 0)
            {
                foreach(var attachment in message.Attachments)
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
            var result = ExecuteRequestContent<InboundMessage>(HttpMethod.Post, requestUri, payload);
            return result.ParsedObject;
        }

        public InboundMessage ForwardMessage(string streamId, InboundMessage message)
        {
            OutboundMessage outboundMessage = new OutboundMessage();
            outboundMessage.Message = message.Message;
            outboundMessage.Data = message.Data;
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
            List<Attachment> messageAttachments = message.Attachments;
            foreach (var attachment in messageAttachments)
            {
                var fileAttachment = new FileAttachment();
                fileAttachment.FileName = attachment.Name;
                fileAttachment.Size = attachment.Size;
                fileAttachment.FileContent = GetAttachment(message.Stream.StreamId, attachment.Id, message.MessageId);
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
    }
}
