using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public interface IIMListener
    {
        void OnIMMessage(InboundMessage message);
        void OnIMCreated(Stream stream);
    }
}
