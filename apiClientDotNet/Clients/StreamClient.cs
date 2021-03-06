﻿using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Clients.Constants;
using apiClientDotNet.Clients;
using System.Net.Http;
using apiClientDotNet.Utils;

namespace apiClientDotNet
{
    public class StreamClient : ApiClient
    {
        public StreamClient(ISymClient client)
        {
            SymClient = client;

        }

        public string GetUserIMStreamId(long userId)
        {
            List<long> userIdList = new List<long>();
            userIdList.Add(userId);
            return GetUserListIM(userIdList);
        }

        public string GetUserListIM(List<long> userIdList)
        {
            var requestUri = new Uri(PodConstants.GetIm, UriKind.Relative);
            var result = ExecuteRequest<StringId>(HttpMethod.Post, requestUri, userIdList);
            return result.ParsedObject.Id;
        }

        public RoomInfo CreateRoom(RoomAttributes room)
        {
            var requestUri = new Uri(PodConstants.CreateRoom, UriKind.Relative);
            var result = ExecuteRequest<RoomInfo>(HttpMethod.Post, requestUri, room);
            return result.ParsedObject;
        }

        public bool AddMemberToRoom(string streamId, long userId)
        {
            var requestUri = new Uri(PodConstants.AddMember.Replace("{id}", streamId), UriKind.Relative);
            var id = new NumericId();
            id.Id = userId;
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri, id);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public bool RemoveMemberFromRoom(string streamId, long userId)
        {
            var requestUri = new Uri(PodConstants.RemoveMember.Replace("{id}", streamId), UriKind.Relative);
            var id = new NumericId();
            id.Id = userId;
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri, id);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public RoomInfo GetRoomInfo(string streamId)
        {
            var requestUri = new Uri(PodConstants.GetRoomInfo.Replace("{id}", streamId), UriKind.Relative);
            var result = ExecuteRequest<RoomInfo>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public RoomInfo UpdateRoom(string streamId, RoomAttributes room) 
        {
            var requestUri = new Uri(PodConstants.UpdateRoomInfo.Replace("{id}", streamId), UriKind.Relative);
            var result = ExecuteRequest<RoomInfo>(HttpMethod.Post, requestUri, room);
            return result.ParsedObject;
         }

        public StreamInfo GetStreamInfo(string streamId) 
        {
            var requestUri = new Uri(PodConstants.GetStreamInfo.Replace("{id}", streamId), UriKind.Relative);
            var result = ExecuteRequest<StreamInfo>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public List<RoomMember> GetRoomMembers(string streamId)
        {
            var requestUri = new Uri(PodConstants.GetRoomMembers.Replace("{id}",streamId), UriKind.Relative);
            var result = ExecuteRequest<List<RoomMember>>(HttpMethod.Get, requestUri);
            return result.ParsedObject;
        }

        public bool ActivateRoom(string streamId)
        {
            return SetActiveRoom(streamId, true);
        }

        public bool DeactivateRoom(string streamId)
        {
            return SetActiveRoom(streamId, false);
        }

        private bool SetActiveRoom(string streamId, bool active)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("active", active.ToString());
            var requestUri = PodConstants.SetActive.Replace("{id}", streamId) + requestParams.Query;
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, new Uri(requestUri, UriKind.Relative));
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public bool PromoteUserToOwner(string streamId, long userId) 
        {
            var requestUri = new Uri(PodConstants.PromoteOwner.Replace("{id}", streamId), UriKind.Relative);
            NumericId id = new NumericId();
            id.Id = userId;
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public bool DemoteUserFromOwner(string streamId, long userId)
        {
            var requestUri = new Uri(PodConstants.DemoteOwner.Replace("{id}", streamId), UriKind.Relative);
            NumericId id = new NumericId();
            id.Id = userId;
            var result = ExecuteRequest<SimpleResponse>(HttpMethod.Post, requestUri);
            return result.HttpResponse.IsSuccessStatusCode;
        }

        public RoomSearchResult SearchRooms(RoomSearchQuery query, int? skip, int? limit)
        {
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("skip", skip.ToString());
            requestParams.AddParameter("limit", limit.ToString());
            var requestUri = PodConstants.SearchRooms + requestParams.Query;
            var result = ExecuteRequest<RoomSearchResult>(HttpMethod.Post, new Uri(requestUri, UriKind.Relative), query);
            return result.ParsedObject;
        }

        public List<StreamListItem> GetUserStreams(List<string> streamTypes = null, bool? includeInactiveStreams = null, int? skip = null, int? limit = null) 
        {
            var requestObject = new
            {
                streamTypes = streamTypes,
                includeInactiveStreams = includeInactiveStreams
            };
            var requestParams = new QueryBuilder();
            requestParams.AddParameter("skip", skip);
            requestParams.AddParameter("limit", limit);
            var requestUri = PodConstants.ListUserStreams + requestParams.Query;
            var result = ExecuteRequest<List<StreamListItem>>(HttpMethod.Post, new Uri(requestUri, UriKind.Relative), requestObject);
            return result.ParsedObject;
        }

        public StreamListItem GetUserWallStream() 
        {
            List<String> streamTypes = new List<String>();
            streamTypes.Add("POST");
            return GetUserStreams(streamTypes, false)[0];
        }
    }
}