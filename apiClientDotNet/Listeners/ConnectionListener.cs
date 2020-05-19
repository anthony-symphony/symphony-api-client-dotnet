using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public interface ConnectionListener
    {
        void OnConnectionAccepted(User user);
        void OnConnectionRequested(User user);
    }
}
