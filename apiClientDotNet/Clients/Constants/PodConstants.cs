namespace apiClientDotNet.Clients.Constants {
    public class PodConstants 
    {
        public const string Pod = "/pod";
        public const string GetUsersV3 = Pod+ "/v3/users";
        public const string GetUserV2 = Pod+ "/v2/user";
        public const string GetIm = Pod+ "/v1/im/create";
        public const string CreateRoom = Pod+ "/v3/room/create";
        public const string AddMember = Pod+ "/v1/room/{id}/membership/add";
        public const string RemoveMember = Pod+ "/v1/room/{id}/membership/remove";
        public const string GetRoomInfo = Pod+ "/v3/room/{id}/info";
        public const string UpdateRoomInfo = Pod+ "/v3/room/{id}/update";
        public const string GetStreamInfo = Pod+ "/v2/streams/{id}/info";
        public const string GetRoomMembers = Pod+ "/v2/room/{id}/membership/list";
        public const string ListUserStreams = Pod+ "/v1/streams/list";
        public const string SetActive = Pod+ "/v1/admin/room/{id}/setActive";
        public const string PromoteOwner = Pod+ "/v1/room/{id}/membership/promoteOwner";
        public const string DemoteOwner = Pod+ "/v1/room/{id}/membership/demoteOwner";
        public const string AcceptConnection = Pod+ "/v1/connection/accept";
        public const string RejectConnection = Pod+ "/v1/connection/reject";
        public const string GetConnectionStatus = Pod+ "/v1/connection/user/{userId}/info";
        public const string RemoveConnection = Pod+ "/v1/connection/user/{userId}/remove";
        public const string ListConnections = Pod + "/v1/connection/list";
        public const string SendConnectionRequest = Pod+ "/v1/connection/create";
        public const string GetMessageStatus =  Pod+ "/v1/message/{mid}/status";
        public const string GetUserPresence =  Pod+ "/v3/user/{uid}/presence";
        public const string SetPresence =  Pod+ "/v2/user/presence";
        public const string RegisterPresenceInterest =  Pod+ "/v1/user/presence/register";
        public const string SearchUsers =  Pod+ "/v1/user/search";
        public const string SearchRooms = Pod+ "/v3/room/search";
        public const string GetAttachmentTypes = Pod+ "/v1/files/allowedTypes";
        public const string AdminMessageSuppression = Pod+ "/v1/admin/messagesuppression/{id}/suppress";
        public const string AdminCreateIm = Pod+ "/v1/admin/im/create";
        public const string AdminListStreamsEnterprise = Pod+ "/v2/admin/streams/list";
        public const string AdminGetUser = Pod+ "/v2/admin/user/{uid}" ;
        public const string AdminListUsers = Pod+ "/v2/admin/user/list" ;
        public const string AdminGetAvatar = Pod+ "/v1/admin/user/{uid}/avatar";
        public const string AdminGetUserStatus = Pod+ "/v1/admin/user/{uid}/status";
        public const string AdminUpdateUserStatus = Pod+ "/v1/admin/user/{uid}/status/update";
        public const string AdminGetPodFeatures = Pod+ "/v1/admin/system/features/list";
        public const string AdminGetUserFeatures = Pod+ "/v1/admin/user/{uid}/features" ;
        public const string AdminUpdateUserFeatures = Pod + "/v1/admin/user/{uid}/features/update";
        public const string AdminGetUserApplications = Pod + "/v1/admin/user/{uid}/app/entitlement/list";
        public const string AdminUpdateUserApplications = Pod + "/v1/admin/user/{uid}/app/entitlement/list";
        public const string AdminCreateUser =  Pod + "/v2/admin/user/create";
        public const string AdminUpdateUser = Pod + "/v2/admin/user/{uid}/update";
        public const string AdminUpdateAvatar = Pod + "/v1/admin/user/{uid}/avatar/update";
        public const string GetSessionUser = Pod + "/v2/sessioninfo";
    }
}
