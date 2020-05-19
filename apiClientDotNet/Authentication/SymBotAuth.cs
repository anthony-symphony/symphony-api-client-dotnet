using System;
using apiClientDotNet.Models;
using Newtonsoft.Json;

namespace apiClientDotNet.Authentication
{   
 
    public class SymBotAuth : SymAuthBase
    {
        public SymBotAuth(SymConfig config)
        {
            SymConfig = config;
            InitializeAuthClients();
        }

        public override void Authenticate()
        {
            SessionAuthenticate();
            KeyManagerAuthenticate();
        }

        public override void SessionAuthenticate()
        {
            var response = SessionAuthClient.PostAsync(AuthEndpointConstants.SessionAuthPath, null).Result;
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

        public override void KeyManagerAuthenticate()
        {
            var response = KeyAuthClient.PostAsync(AuthEndpointConstants.KeyAuthPath, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                KeyManagerToken = JsonConvert.DeserializeObject<TokenObject>(result).Token;
            }
            else 
            {
                KeyManagerToken = null;
            }
        }

        public override string GetKeyManagerToken()
        {
            return KeyManagerToken;
        }
        
        public override void SetKeyManagerToken(string kmToken)
        {
            KeyManagerToken = kmToken;
        }

        public override void Logout() 
        {
            throw new NotImplementedException();
        }
    }
}
