namespace apiClientDotNet.Clients.Constants {
    public class PodConstants 
    {
        public const string PodPrefix = "/pod";
        public const string GetUsersV3 = PodPrefix + "/v3/users";
        public const string GetUserV2 = PodPrefix + "/v2/user";
        public const string GetIm = PodPrefix + "/v1/im/create";
        public const string CreateRoom = PodPrefix + "/v3/room/create";
        public const string AddMember = PodPrefix + "/v1/room/{id}/membership/add";
        public const string RemoveMember = PodPrefix + "/v1/room/{id}/membership/remove";
        public const string GetRoomInfo = PodPrefix + "/v3/room/{id}/info";
        public const string UpdateRoomInfo = PodPrefix + "/v3/room/{id}/update";
        public const string GetStreamInfo = PodPrefix + "/v2/streams/{id}/info";
        public const string GetRoomMembers = PodPrefix + "/v2/room/{id}/membership/list";
        public const string ListUserStreams = PodPrefix + "/v1/streams/list";
        public const string SetActive = PodPrefix + "/v1/admin/room/{id}/setActive";
        public const string PromoteOwner = PodPrefix + "/v1/room/{id}/membership/promoteOwner";
        public const string DemoteOwner = PodPrefix + "/v1/room/{id}/membership/demoteOwner";
        public const string AcceptConnection = PodPrefix + "/v1/connection/accept";
        public const string RejectConnection = PodPrefix + "/v1/connection/reject";
        public const string GetConnectionStatus = PodPrefix + "/v1/connection/user/{userId}/info";
        public const string RemoveConnection = PodPrefix + "/v1/connection/user/{userId}/remove";
        public const string ListConnections = PodPrefix + "/v1/connection/list";
        public const string SendConnectionRequest = PodPrefix + "/v1/connection/create";
        public const string GetMessageStatus =  PodPrefix + "/v1/message/{mid}/status";
        public const string GetUserPresence =  PodPrefix + "/v3/user/{uid}/presence";
        public const string SetPresence =  PodPrefix + "/v2/user/presence";
        public const string RegisterPresenceInterest =  PodPrefix + "/v1/user/presence/register";
        public const string SearchUsers =  PodPrefix + "/v1/user/search";
        public const string SearchRooms = PodPrefix + "/v3/room/search";
        public const string GetAttachmentTypes = PodPrefix + "/v1/files/allowedTypes";
        public const string AdminMessageSuppression = PodPrefix + "/v1/admin/messagesuppression/{id}/suppress";
        public const string AdminCreateIm = PodPrefix + "/v1/admin/im/create";
        public const string AdminListStreamsEnterprise = PodPrefix + "/v2/admin/streams/list";
        public const string AdminGetUser = PodPrefix + "/v2/admin/user/{uid}" ;
        public const string AdminListUsers = PodPrefix + "/v2/admin/user/list" ;
        public const string AdminGetAvatar = PodPrefix + "/v1/admin/user/{uid}/avatar";
        public const string AdminGetUserStatus = PodPrefix + "/v1/admin/user/{uid}/status";
        public const string AdminUpdateUserStatus = PodPrefix + "/v1/admin/user/{uid}/status/update";
        public const string AdminGetPodFeatures = PodPrefix + "/v1/admin/system/features/list";
        public const string AdminGetUserFeatures = PodPrefix + "/v1/admin/user/{uid}/features" ;
        public const string AdminUpdateUserFeatures = PodPrefix + "/v1/admin/user/{uid}/features/update";
        public const string AdminGetUserApplications = PodPrefix + "/v1/admin/user/{uid}/app/entitlement/list";
        public const string AdminUpdateUserApplications = PodPrefix + "/v1/admin/user/{uid}/app/entitlement/list";
        public const string AdminCreateUser =  PodPrefix + "/v2/admin/user/create";
        public const string AdminUpdateUser = PodPrefix + "/v2/admin/user/{uid}/update";
        public const string AdminUpdateAvatar = PodPrefix + "/v1/admin/user/{uid}/avatar/update";
        public const string GetSessionUser = PodPrefix + "/v2/sessioninfo";
    }
}
