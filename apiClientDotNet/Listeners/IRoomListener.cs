using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Listeners
{
    public interface RoomListener
    {
        void OnRoomMessage(InboundMessage message);
        void OnRoomCreated(RoomCreated roomCreated);
        void OnRoomDeactivated(RoomDeactivated roomDeactivated);
        void OnRoomMemberDemotedFromOwner(RoomMemberDemotedFromOwner roomMemberDemotedFromOwner);
        void OnRoomMemberPromotedToOwner(RoomMemberPromotedToOwner roomMemberPromotedToOwner);
        void OnRoomReactivated(Stream stream);
        void OnRoomUpdated(RoomUpdated roomUpdated);
        void OnUserJoinedRoom(UserJoinedRoom userJoinedRoom);
        void OnUserLeftRoom(UserLeftRoom userLeftRoom); 
    }
}
