using System;
using apiClientDotNet.Models;
using System.Net.Http;
using apiClientDotNet.Utils;
using Newtonsoft.Json;

namespace apiClientDotNet.Authentication 
{
    public class SymBotRSAAuth : SymAuthBase 
    {
        private String JsonWebToken;
        public SymBotRSAAuth(SymConfig config) 
        {
            this.SymConfig = config;
            InitializeAuthClients();
        }
        
        public override void Authenticate() 
        {
            JWTHandler jwtHandler = new JWTHandler();
            JsonWebToken = jwtHandler.generateJWT(SymConfig);
            SessionAuthenticate();
            KeyManagerAuthenticate();
        }
        
        public override void SessionAuthenticate() 
        {
            var token = new 
            {
                token = JsonWebToken
            };
            var response = SessionAuthClient.PostAsync(AuthEndpointConstants.RsaSessionAuthPath, new StringContent(JsonConvert.SerializeObject(token))).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                SessionToken = JsonConvert.DeserializeObject<Token>(result).token;
            }
            else 
            {
                SessionToken = null;
            }
        }

        public override void KeyManagerAuthenticate() {

            var token = new 
            {
                token = JsonWebToken
            };
            var response = KeyAuthClient.PostAsync(AuthEndpointConstants.RsaKeyManagerAuthPath, new StringContent(JsonConvert.SerializeObject(token))).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                KeyManagerToken = JsonConvert.DeserializeObject<Token>(result).token;
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
