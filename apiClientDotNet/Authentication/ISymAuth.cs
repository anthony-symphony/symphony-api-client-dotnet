namespace apiClientDotNet.Authentication 
{
    public interface ISymAuth 
    {
        void Authenticate();
        void SessionAuthenticate();
        string GetSessionToken();
        void SetSessionToken(string sessionToken);
        void KeyManagerAuthenticate();
        string GetKeyManagerToken();
        void SetKeyManagerToken(string kmToken);
        void Logout();


        #region Legacy Forwarders
        void authenticate();
        void sessionAuthenticate();
        string getSessionToken();
        void setSessionToken(string sessionToken);
        void keyManagerAuthenticate();
        string getKeyManagerToken();
        void setKeyManagerToken(string kmToken);
        void logout();
        #endregion
    }
}
