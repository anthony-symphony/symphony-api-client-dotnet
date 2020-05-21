using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public interface IMListener
    {
        void OnIMMessage(InboundMessage message);
        void OnIMCreated(Stream stream);
    }
}
