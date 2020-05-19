using System;
using apiClientDotNet.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace apiClientDotNet.Authentication 
{

    public class SymOBOAuth : SymAuthBase
    {
        public string AppSessionToken
        { 
            get { return SessionToken; }
            set { SessionToken = value; }
        }
        
        private string UserSessionToken;

        public SymOBOAuth(SymConfig config) 
        {
            SymConfig = config;
            InitializeAuthClients();
        }
        public SymOBOUserAuth GetUserAuth(string username) 
        {
            SymOBOUserAuth userAuth = new SymOBOUserAuth(username, this);
            UserSessionToken = userAuth.GetUserSessionToken();
            return userAuth;
        }

        public SymOBOUserAuth GetUserAuth(long uid) 
        {
            SymOBOUserAuth userAuth = new SymOBOUserAuth(uid, this);
            UserSessionToken = userAuth.GetUserSessionToken();
            return userAuth;
        }

        public override void SessionAuthenticate() 
        {
            var response = SessionAuthClient.PostAsync(AuthEndpointConstants.AppSessionAuthPath, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                SessionToken = JsonConvert.DeserializeObject<TokenObject>(result).Token;
            }
            else 
            {
                SessionToken = null;
            }
        }

        public HttpClient GetAppAuthClient() 
        {
            return SessionAuthClient;
        }

        public override void Authenticate()
        {
            SessionAuthenticate();
        }

        public override void KeyManagerAuthenticate() {}
        public override string GetKeyManagerToken()
        {
            return null;
        }
        
        public override void SetKeyManagerToken(string kmToken) {}

        public override void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
