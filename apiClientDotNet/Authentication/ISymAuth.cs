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
    }
}
