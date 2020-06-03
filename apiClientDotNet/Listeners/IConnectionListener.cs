using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public interface IConnectionListener
    {
        void OnConnectionAccepted(User user);
        void OnConnectionRequested(User user);
    }
}
