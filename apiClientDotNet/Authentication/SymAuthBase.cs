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
            var botCertificate = File.ReadAllBytes(SymConfig.BotCertPath + SymConfig.BotCertName + ".p12");
            var sessionAuthRequestHandler = new HttpClientHandler();
            if (!string.IsNullOrEmpty(SymConfig.SessionProxyURL)) {
                sessionAuthRequestHandler.Proxy = RequestProxyBuilder.CreateWebProxy(SymConfig.SessionProxyURL, SymConfig.SessionProxyUsername, SymConfig.SessionProxyPassword);
            }
            sessionAuthRequestHandler.ClientCertificates.Add(new X509Certificate2(botCertificate, SymConfig.BotCertPassword));
            SessionAuthClient = new HttpClient(sessionAuthRequestHandler);
            var sessionAuthBase = new UriBuilder("https", SymConfig.SessionAuthHost, SymConfig.SessionAuthPort);
            SessionAuthClient.BaseAddress = sessionAuthBase.Uri;

            var keyAuthRequestHandler = new HttpClientHandler();
            if (!string.IsNullOrEmpty(SymConfig.KeyManagerProxyURL)) {
                keyAuthRequestHandler.Proxy = RequestProxyBuilder.CreateWebProxy(SymConfig.KeyManagerProxyURL, SymConfig.KeyManagerProxyUsername, SymConfig.KeyManagerProxyPassword);
            }
            keyAuthRequestHandler.ClientCertificates.Add(new X509Certificate2(botCertificate, SymConfig.BotCertPassword));
            KeyAuthClient = new HttpClient(keyAuthRequestHandler);
            var keyAuthBase = new UriBuilder("https", SymConfig.KeyAuthHost, SymConfig.KeyAuthPort);
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
    }
}