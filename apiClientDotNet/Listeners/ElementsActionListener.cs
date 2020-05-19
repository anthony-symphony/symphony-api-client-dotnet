using System;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Listeners
{
    public interface ElementsActionListener
    {
        void OnElementsAction(User initiator, SymphonyElementsAction action);
        void OnFormMessage(User initiator, String fstreamid, SymphonyElementsAction form);
    }
}