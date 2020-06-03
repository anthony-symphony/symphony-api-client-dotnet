using apiClientDotNet;
using apiClientDotNet.Authentication;
using apiClientDotNet.Listeners;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace apiClientDotNetTest
{
    /// <summary>
    /// The scope of this test is to simulate a real scenario of reading the data feed.
    /// In the test we have two bots. Bot one sends a message to bot two.
    /// 
    /// TODO: at this moment the test is BLOCKED because the SymBotClient keeps singleton SymBotClient instance.
    /// and we cannot send a message from one BOT to another.
    /// </summary>
    [TestClass]
    public class RequestResponseTest
    {
        [TestMethod]
        public void ChatBotTest()
        {
            var symConfigLoader = new SymConfigLoader();
            var configPathOne = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            var symConfigOne = symConfigLoader.loadFromFile(configPathOne);
            var botAuthOne = new SymBotRSAAuth(symConfigOne);
            botAuthOne.Authenticate();
            var botClientOne = SymBotClient.InitBot(symConfigOne, botAuthOne);

            // create data feed with bot One
            var datafeedEventsServiceBotOne = new DatafeedEventsService(botClientOne);
            var botLogic = new BotLogic(datafeedEventsServiceBotOne);
            datafeedEventsServiceBotOne.addRoomListener(botLogic);
            
            // Send message using bot two in a room where bot one is also added
            SendMessageAsync();

            // start reading the data feed and stop when the first message is received
            datafeedEventsServiceBotOne.getEventsFromDatafeed();
        }

        private void SendMessageAsync()
        {
            var task = new Task(() =>
            {

                var symConfigLoader = new SymConfigLoader();
                var configPathTwo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "testConfigPsdevTwo.json");
                var symConfigTwo = symConfigLoader.loadFromFile(configPathTwo);
                var botAuthTwo = new SymBotRSAAuth(symConfigTwo);
                botAuthTwo.Authenticate();
                var botClientTwo = SymBotClient.InitBot(symConfigTwo, botAuthTwo);

                // Find one BOT stream id
                var streamClient = botClientTwo.GetStreamsClient();
                var streamTypes = new List<string>
                {
                    "ROOM"
                };
                var result = streamClient.GetUserStreams(streamTypes, false);
                // Send to that stream a messages
                var message = new OutboundMessage
                {
                    Message = "<messageML>Hello world! From .NET SDK Integration Test.</messageML>"
                };
                var stream = new apiClientDotNet.Models.Stream
                {
                    StreamId = result[0].Id
                };
                var messageClient = new MessageClient(botClientTwo);
                messageClient.SendMessage(stream.StreamId, message, false);
            }, TaskCreationOptions.AttachedToParent);

            task.Start();
        }

        public class BotLogic : IRoomListener
        {
            DatafeedEventsService datafeedEventsService;
            public BotLogic(DatafeedEventsService datafeedEventsService)
            {
                this.datafeedEventsService = datafeedEventsService;
            }

            public void OnRoomMessage(InboundMessage message)
            {
                datafeedEventsService.stopGettingEventsFromDatafeed();
                Assert.IsNotNull(message);
            }
            public void OnRoomCreated(RoomCreated roomCreated) { }
            public void OnRoomDeactivated(RoomDeactivated roomDeactivated) { }
            public void OnRoomMemberDemotedFromOwner(RoomMemberDemotedFromOwner roomMemberDemotedFromOwner) { }
            public void OnRoomMemberPromotedToOwner(RoomMemberPromotedToOwner roomMemberPromotedToOwner) { }
            public void OnRoomReactivated(apiClientDotNet.Models.Stream stream) { }
            public void OnRoomUpdated(RoomUpdated roomUpdated) { }
            public void OnUserJoinedRoom(UserJoinedRoom userJoinedRoom) { }
            public void OnUserLeftRoom(UserLeftRoom userLeftRoom) { }
        }


    }
}
