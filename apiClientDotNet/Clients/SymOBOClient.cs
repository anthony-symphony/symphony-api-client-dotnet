using apiClientDotNet.Models;
using apiClientDotNet.Authentication;

namespace apiClientDotNet.Clients
{
    public class SymOBOClient : SymClientBase
    {
        private static SymOBOClient OboClient;

        public static SymOBOClient InitOBOClient(SymConfig config, ISymAuth symAuth)
        {
            OboClient = new SymOBOClient(config, symAuth);
            return OboClient;
        }

        private SymOBOClient(SymConfig config, ISymAuth symAuth)
        {
            SymAuth = symAuth;
            SymConfig = config;
            InitializeBaseClient();
        }
    }
}
