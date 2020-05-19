using apiClientDotNet.Models;
using apiClientDotNet.Authentication;
using System.Net.Http;

namespace apiClientDotNet.Clients
{
    public interface ISymClient
    {
        SymConfig GetConfig();

        ISymAuth GetSymAuth();

        void Reauthenticate();

        MessageClient GetMessagesClient();

        StreamClient GetStreamsClient();

        PresenceClient GetPresenceClient();

        UserClient GetUsersClient();

        ConnectionsClient GetConnectionsClient();
        HttpClient GetPodHttpClient();
        HttpClient GetAgentHttpClient();
        HttpClient GetDefaultHttpClient();
    }
}
