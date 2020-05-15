using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;

namespace apiClientDotNet.Authentication
{
    public abstract class SymAuthBase : ISymAuth
    {
        protected string SessionToken;
        protected string KeyManagerToken;
        protected SymConfig SymConfig;
        protected HttpClient SessionAuthClient;
        protected HttpClient KeyAuthClient;

        protected virtual void InitializeAuthClients() 
        {
            var botCertificate = File.ReadAllBytes(SymConfig.botCertPath + SymConfig.botCertName + ".p12");
            var sessionAuthRequestHandler = new HttpClientHandler();
            if (!string.IsNullOrEmpty(SymConfig.sessionProxyURL)) {
                sessionAuthRequestHandler.Proxy = RequestProxyBuilder.CreateWebProxy(SymConfig.sessionProxyURL, SymConfig.sessionProxyUsername, SymConfig.sessionProxyPassword);
            }
            sessionAuthRequestHandler.ClientCertificates.Add(new X509Certificate2(botCertificate, SymConfig.botCertPassword));
            SessionAuthClient = new HttpClient(sessionAuthRequestHandler);
            var sessionAuthBase = new UriBuilder("https", SymConfig.sessionAuthHost, SymConfig.sessionAuthPort);
            SessionAuthClient.BaseAddress = sessionAuthBase.Uri;

            var keyAuthRequestHandler = new HttpClientHandler();
            if (!string.IsNullOrEmpty(SymConfig.keyManagerProxyURL)) {
                keyAuthRequestHandler.Proxy = RequestProxyBuilder.CreateWebProxy(SymConfig.keyManagerProxyURL, SymConfig.keyManagerProxyUsername, SymConfig.keyManagerProxyPassword);
            }
            keyAuthRequestHandler.ClientCertificates.Add(new X509Certificate2(botCertificate, SymConfig.botCertPassword));
            KeyAuthClient = new HttpClient(keyAuthRequestHandler);
            var keyAuthBase = new UriBuilder("https", SymConfig.keyAuthHost, SymConfig.keyAuthPort);
            KeyAuthClient.BaseAddress = keyAuthBase.Uri;
        }

        public virtual string GetSessionToken() 
        {
            return SessionToken;
        }

        public virtual void SetSessionToken(string sessionToken) 
        {
            SessionToken = sessionToken;
        }

        public abstract void Authenticate();
        public abstract void SessionAuthenticate();
        public abstract void KeyManagerAuthenticate();
        public abstract string GetKeyManagerToken();
        public abstract void SetKeyManagerToken(string kmToken);
        public abstract void Logout();

        #region Legacy Forwarders
        public void authenticate()
        {
            Authenticate();
        }
        public void sessionAuthenticate()
        {
            SessionAuthenticate();
        }

        public string getSessionToken()
        {
            return GetSessionToken();
        }
        public void setSessionToken(string sessionToken)
        {
            SetSessionToken(sessionToken);
        }
        public void keyManagerAuthenticate()
        {
            KeyManagerAuthenticate();
        }
        public string getKeyManagerToken()
        {
            return GetKeyManagerToken();
        }
        public void setKeyManagerToken(string kmToken)
        {
            SetKeyManagerToken(kmToken);
        }
        public void logout()
        {
            Logout();
        }
        #endregion
    }
}