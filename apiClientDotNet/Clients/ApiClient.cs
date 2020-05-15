using System;
using apiClientDotNet.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace apiClientDotNet.Clients
{
    public abstract class ApiClient
    {
        protected ISymClient SymClient;
        protected SymConfig config 
        {
            get
            {
                return SymClient.GetConfig();
            }
        }
        protected HttpClient PodRequestClient
        {
            get
            {
                return SymClient.GetPodHttpClient();
            }
        }

        protected HttpClient AgentRequestClient
        {
            get
            {
                return SymClient.GetAgentHttpClient();
            }
        }

        protected HttpClient DefaultRequestClient
        {
            get
            {
                return SymClient.GetDefaultHttpClient();
            }
        }

        protected T GetObjectFromResponse<T>(HttpResponseMessage response)
        {
            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        protected SymClientResponse<T> ExecuteRequest<T>(HttpMethod method, Uri requestUri, object postData = null, HttpRequestHeaders optionalHeaders = null) 
        {
            T result;
            var requestClient = DetermineHttpClient(requestUri);
            var request = new HttpRequestMessage(method, requestUri);
            if (postData is MultipartFormDataContent)
            {
                request.Content = (MultipartFormDataContent) postData;
            }
            else if (postData != null)
            {
                var jsonString = JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            }
            if (optionalHeaders != null)
            {
                foreach (var header in optionalHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            var response = requestClient.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                result = GetObjectFromResponse<T>(response);
            }
            else
            {
                HandleError(response);
                result = default(T);
            }
            return new SymClientResponse<T> (result, response);
        }

        protected HttpClient DetermineHttpClient(Uri request) 
        {
            if (request.OriginalString.ToLower().StartsWith("/pod"))
            {
                return PodRequestClient;
            }
            if (request.OriginalString.ToLower().StartsWith("/agent"))
            {
                return AgentRequestClient;
            }
            return DefaultRequestClient;
        }

        protected void HandleError(HttpResponseMessage response)
        {
            try 
            {
                Console.WriteLine(response.RequestMessage.RequestUri.OriginalString);
                Console.WriteLine(JToken.Parse(response.RequestMessage.Content.ReadAsStringAsync().Result).ToString(Formatting.Indented));
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    //logger.error("Client error occurred", error);
                    throw new Exception("Bad Request Error");
                } 
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //logger.error("User unauthorized, refreshing tokens");
                    //botClient.getSymBotAuth().authenticate();
                    throw new Exception("Bad Tokens");
                } 
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    //logger.error("Forbidden: Caller lacks necessary entitlement.");
                    throw new Exception("Forbidden Error");
                } 
                else if (response.StatusCode == HttpStatusCode.InternalServerError) 
                {
                    //logger.error(error.getMessage());
                    throw new Exception("Bad 500");
                }
            } 
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}