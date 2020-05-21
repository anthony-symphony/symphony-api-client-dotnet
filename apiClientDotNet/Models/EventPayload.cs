using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Models
{
    public class EventPayload
    {
        [JsonProperty("messageSent")]
        public MessageSent MessageSent { get; set; }

        [JsonProperty("sharedPost")]
        public SharedPost SharedPost { get; set; }

        [JsonProperty("instantMessageCreated")]
        public IMCreated InstantMessageCreated { get; set; }

        [JsonProperty("roomCreated")]
        public RoomCreated RoomCreated { get; set; }

        [JsonProperty("roomUpdated")]
        public RoomUpdated RoomUpdated { get; set; }

        [JsonProperty("roomDeactivated")]
        public RoomDeactivated RoomDeactivated { get; set; }

        [JsonProperty("roomReactivated")]
        public RoomReactivated RoomReactivated { get; set; }

        [JsonProperty("userJoinedRoom")]
        public UserJoinedRoom UserJoinedRoom { get; set; }

        [JsonProperty("userLeftRoom")]
        public UserLeftRoom UserLeftRoom { get; set; }

        [JsonProperty("roomMemberPromotedToOwner")]
        public RoomMemberPromotedToOwner RoomMemberPromotedToOwner { get; set; }

        [JsonProperty("roomMemberDemotedFromOwner")]
        public RoomMemberDemotedFromOwner RoomMemberDemotedFromOwner { get; set; }

        [JsonProperty("connectionRequested")]
        public ConnectionRequested ConnectionRequested { get; set; }

        [JsonProperty("connectionAccepted")]
        public ConnectionAccepted ConnectionAccepted { get; set; }

        [JsonProperty("messageSuppressed")]
        public MessageSuppressed MessageSuppressed { get; set; }

        [JsonProperty("symphonyElementsAction")]
        public SymphonyElementsAction SymphonyElementsAction { get; set; }
    }
}
