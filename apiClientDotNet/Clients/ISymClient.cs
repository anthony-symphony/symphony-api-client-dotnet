using apiClientDotNet.Models;
using apiClientDotNet.Authentication;
using System.Net.Http;

namespace apiClientDotNet.Clients
{
    public interface ISymClient
    {
        SymConfig GetConfig();

        ISymAuth GetSymAuth();

        MessageClient GetMessagesClient();

        StreamClient GetStreamsClient();

        PresenceClient GetPresenceClient();

        UserClient GetUsersClient();

        ConnectionsClient GetConnectionsClient();
        HttpClient GetPodHttpClient();
        HttpClient GetAgentHttpClient();
        HttpClient GetDefaultHttpClient();


        #region Legacy Forwarders        
        SymConfig getConfig();
 
        ISymAuth getSymAuth();

        MessageClient getMessagesClient();

        StreamClient getStreamsClient();

        PresenceClient getPresenceClient();

        UserClient getUsersClient();

        ConnectionsClient getConnectionsClient();

        #endregion
    }
}
