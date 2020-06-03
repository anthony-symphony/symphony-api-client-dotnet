using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Listeners;
using apiClientDotNet.Services;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Authentication;

namespace apiClientDotNetTest
{

    public class BotLogic : IRoomListener
    {
        public void OnRoomMessage(InboundMessage message)
         {
            Console.Write(message.Message);
        }
        public void OnRoomCreated(RoomCreated roomCreated) { }
        public void OnRoomDeactivated(RoomDeactivated roomDeactivated) { }
        public void OnRoomMemberDemotedFromOwner(RoomMemberDemotedFromOwner roomMemberDemotedFromOwner) { }
        public void OnRoomMemberPromotedToOwner(RoomMemberPromotedToOwner roomMemberPromotedToOwner) { }
        public void OnRoomReactivated(Stream stream) { }
        public void OnRoomUpdated(RoomUpdated roomUpdated) { }
        public void OnUserJoinedRoom(UserJoinedRoom userJoinedRoom) { }
        public void OnUserLeftRoom(UserLeftRoom userLeftRoom) { }
    }

    [TestClass]
    public class InitBotTest
    {

        [TestMethod]
        public void ForGivenRsaConfig_CanAuthenticateAndCreateDataFeed()
        {
            var symConfig = new SymConfig();
            var symConfigLoader = new SymConfigLoader();
            var configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            symConfig = symConfigLoader.loadFromFile(configPath);
            var botAuth = new SymBotRSAAuth(symConfig);
            botAuth.Authenticate();
            var botClient = SymBotClient.InitBot(symConfig, botAuth);
            DatafeedEventsService datafeedEventsService = botClient.GetDatafeedEventsService();
            Assert.IsNotNull(datafeedEventsService.datafeedId);
        }
    }
}
