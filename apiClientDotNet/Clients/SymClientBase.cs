using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using apiClientDotNet.Authentication;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;

namespace apiClientDotNet.Clients
{
    public abstract class SymClientBase : ISymClient
    {
        public enum SymphonyRequestType 
        {
            SessionAuth,
            KeyManager,
            Pod,
            Agent,
            Default
        };
        protected SymConfig SymConfig;
        protected ISymAuth SymAuth;
        protected MessageClient MessagesClient;
        protected StreamClient StreamClient;
        protected PresenceClient PresenceClient;
        protected UserClient UserClient;
        protected ConnectionsClient ConnectionsClient;
        protected SignalsClient SignalsClient;
        protected AdminClient AdminClient;
        protected Dictionary<SymphonyRequestType,WebProxy> RequestProxies;
        protected Dictionary<SymphonyRequestType,string> BaseUrls;
        protected Dictionary<SymphonyRequestType,HttpClient> RequestClients;
        
        public SymConfig GetConfig()
        {
            return SymConfig;
        }

        public ISymAuth GetSymAuth()
        {
            return SymAuth;
        }

        public MessageClient GetMessagesClient()
        {
            if (MessagesClient == null)
            {
                MessagesClient = new MessageClient(this);
            }
            return MessagesClient;
        }

        public StreamClient GetStreamsClient()
        {
            if (StreamClient == null)
            {
                StreamClient = new StreamClient(this);
            }
            return StreamClient;
        }

        public PresenceClient GetPresenceClient()
        {
            if (PresenceClient == null)
            {
                PresenceClient = new PresenceClient(this);
            }
            return PresenceClient;
        }

        public UserClient GetUsersClient()
        {
            if (UserClient == null)
            {
                UserClient = new UserClient(this);
            }
            return UserClient;
        }

        public ConnectionsClient GetConnectionsClient()
        {
            if (ConnectionsClient == null)
            {
                ConnectionsClient = new ConnectionsClient(this);
            }
            return ConnectionsClient;
        }

        public SignalsClient GetSignalsClient()
        {
            if (SignalsClient == null)
            {
                SignalsClient = new SignalsClient(this);
            }
            return SignalsClient;
        }

        public AdminClient GetAdminClient()
        {
            if (AdminClient == null)
            {
                AdminClient = new AdminClient(this);
            }
            return AdminClient;
        }

        public Dictionary<SymphonyRequestType, WebProxy> GetRequestProxies()
        {
            return RequestProxies;
        }
        public Dictionary<SymphonyRequestType, string> GetBaseUrls()
        {
            return BaseUrls;
        }

        public Dictionary<SymphonyRequestType, HttpClient> GetRequestClients()
        {
            return RequestClients;
        }
        public HttpClient GetPodHttpClient()
        {
            return RequestClients[SymphonyRequestType.Pod];
        }
        public HttpClient GetAgentHttpClient()
        {
            return RequestClients[SymphonyRequestType.Agent];
        }

        public HttpClient GetDefaultHttpClient()
        {
            return RequestClients[SymphonyRequestType.Default];
        }

        protected void InitializeBaseClient(){
            LoadBaseUrls();
            IntializeRequestProxies();
            IntializeAllRequestClients();
        }

        public void Reauthenticate()
        {
            SymAuth.Authenticate();
            SetAuthTokens();
        }

        protected void LoadBaseUrls() 
        {
            BaseUrls = new Dictionary<SymphonyRequestType, string>();
            BaseUrls[SymphonyRequestType.SessionAuth] = new UriBuilder("https", SymConfig.SessionAuthHost, SymConfig.SessionAuthPort).ToString();
            BaseUrls[SymphonyRequestType.KeyManager] = new UriBuilder("https",SymConfig.KeyAuthHost, SymConfig.KeyAuthPort).ToString();
            BaseUrls[SymphonyRequestType.Pod] = new UriBuilder("https", SymConfig.PodHost, SymConfig.PodPort).ToString();
            BaseUrls[SymphonyRequestType.Agent] = new UriBuilder("https", SymConfig.AgentHost, SymConfig.AgentPort).ToString();
            BaseUrls[SymphonyRequestType.Default] = String.Empty;

        }

        protected void IntializeRequestProxies() 
        {
            RequestProxies = new Dictionary<SymphonyRequestType, WebProxy>();
            if (!string.IsNullOrEmpty(SymConfig.ProxyURL)) 
            {
                RequestProxies[SymphonyRequestType.Default] = RequestProxyBuilder.CreateWebProxy(SymConfig.ProxyURL, SymConfig.ProxyUsername, SymConfig.ProxyPassword);
            }
            else 
            {
                RequestProxies[SymphonyRequestType.Default] = null;
            }

            if (!string.IsNullOrEmpty(SymConfig.SessionProxyURL)) 
            {
                RequestProxies[SymphonyRequestType.SessionAuth] = RequestProxyBuilder.CreateWebProxy(SymConfig.SessionProxyURL, SymConfig.SessionProxyUsername, SymConfig.SessionProxyPassword);
            }
            else 
            {
                RequestProxies[SymphonyRequestType.SessionAuth] = RequestProxies[SymphonyRequestType.Default];
            }

            if (!string.IsNullOrEmpty(SymConfig.KeyManagerProxyURL)) 
            {
                RequestProxies[SymphonyRequestType.KeyManager] = RequestProxyBuilder.CreateWebProxy(SymConfig.KeyManagerProxyURL, SymConfig.KeyManagerProxyUsername, SymConfig.KeyManagerProxyPassword);
            }
            else 
            {
                RequestProxies[SymphonyRequestType.KeyManager] = RequestProxies[SymphonyRequestType.Default];
            }

            if (!string.IsNullOrEmpty(SymConfig.PodProxyURL)) 
            {
                RequestProxies[SymphonyRequestType.Pod] = RequestProxyBuilder.CreateWebProxy(SymConfig.PodProxyURL, SymConfig.PodProxyUsername, SymConfig.PodProxyPassword);
            }
            else 
            {
                RequestProxies[SymphonyRequestType.Pod] = RequestProxies[SymphonyRequestType.Default];
            }

            if (!string.IsNullOrEmpty(SymConfig.AgentProxyURL)) 
            {
                RequestProxies[SymphonyRequestType.Agent] = RequestProxyBuilder.CreateWebProxy(SymConfig.AgentProxyURL, SymConfig.AgentProxyUsername, SymConfig.AgentProxyPassword);
            }
            else 
            {
                RequestProxies[SymphonyRequestType.Agent] = RequestProxies[SymphonyRequestType.Default];
            }
        }

        protected void IntializeAllRequestClients() 
        {
            RequestClients = new Dictionary<SymphonyRequestType, HttpClient>();
            foreach (SymphonyRequestType type in Enum.GetValues(typeof(SymphonyRequestType))) 
            {
                InitializeRequestClient(type);
            }
            SetAuthTokens();
        }

        protected void InitializeRequestClient(SymphonyRequestType type) 
        {
            HttpClient requestClient;
            if (RequestProxies[type] != null) 
            {
                var requestHandler = new HttpClientHandler();
                requestHandler.Proxy = RequestProxies[type];
                requestClient = new HttpClient(requestHandler);
            }
            else 
            {
                requestClient = new HttpClient();
            }
            if (BaseUrls[type] != String.Empty)
            {
                requestClient.BaseAddress = new Uri(BaseUrls[type]);
            }
            RequestClients[type] = requestClient;
        }

        protected void SetAuthTokens()
        {
            RequestClients[SymphonyRequestType.Pod].DefaultRequestHeaders.Remove("sessionToken");
            RequestClients[SymphonyRequestType.Pod].DefaultRequestHeaders.Add("sessionToken", SymAuth.GetSessionToken());
            RequestClients[SymphonyRequestType.Agent].DefaultRequestHeaders.Remove("sessionToken");
            RequestClients[SymphonyRequestType.Agent].DefaultRequestHeaders.Remove("keyManagerToken");
            RequestClients[SymphonyRequestType.Agent].DefaultRequestHeaders.Add("sessionToken", SymAuth.GetSessionToken());
            RequestClients[SymphonyRequestType.Agent].DefaultRequestHeaders.Add("keyManagerToken", SymAuth.GetKeyManagerToken());
        }
    }
}