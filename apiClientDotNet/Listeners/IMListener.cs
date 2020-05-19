using apiClientDotNet.Models;

namespace apiClientDotNet.Listeners
{
    public interface IMListener
    {
        void onIMMessage(InboundMessage message);
        void onIMCreated(Stream stream);
    }
}
