using System;
using apiClientDotNet.Models;
using Newtonsoft.Json;

namespace apiClientDotNet.Authentication
{
    public class SymOBOUserAuth
    {
        public long UserId {get; private set;}
        public String UserName {get; private set;}
        private SymOBOAuth AppAuth;
        public string UserSessionToken {get; private set;}

        public SymOBOUserAuth(long uid, SymOBOAuth appAuth)
        {
            UserId = uid;
            AppAuth = appAuth;
        }

        public SymOBOUserAuth(string username, SymOBOAuth appAuth)
        {
            UserName = username;
            AppAuth = appAuth;
        }

        public string GetUserSessionToken()
        {
            string requestPath;
            if (UserId != 0) 
            {
                requestPath = AuthEndpointConstants.OboUserAuthByIdPath.Replace("{uid}", UserId.ToString());
            }
            else 
            {
                requestPath = AuthEndpointConstants.OboUserAuthByUsernamePath.Replace("{username}", UserName);
            }
            var response = AppAuth.GetAppAuthClient().PostAsync(requestPath, null).Result;
            if (response.IsSuccessStatusCode) 
            {
                return JsonConvert.DeserializeObject<TokenObject>(response.Content.ReadAsStringAsync().Result).Token;
            }
            else 
            {
                throw new Exception("Unable to Authenticate");
            }
        }

        public void Logout()
        {
            var response = AppAuth.GetAppAuthClient().PostAsync(AuthEndpointConstants.LogoutPath, null).Result;
        }
    }
}
