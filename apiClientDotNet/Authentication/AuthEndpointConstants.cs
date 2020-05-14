namespace apiClientDotNet.Authentication 
{
    public class AuthEndpointConstants 
    {
        public const string HttpsPrefix = "https://";
        public const string SessionAuthPath = "/sessionauth/v1/authenticate";
        public const string KeyAuthPath = "/keyauth/v1/authenticate";
        public const string LogoutPath = "/sessionauth/v1/logout";
        public const string RsaSessionAuthPath = "/login/pubkey/authenticate";
        public const string RsaKeyManagerAuthPath = "/relay/pubkey/authenticate";
        public const string AppSessionAuthPath = "/sessionauth/v1/app/authenticate";
        public const string OboUserAuthByIdPath = "/sessionauth/v1/app/user/{uid}/authenticate";
        public const string OboUserAuthByUsernamePath = "/sessionauth/v1/app/username/{username}/authenticate";
    }
}
