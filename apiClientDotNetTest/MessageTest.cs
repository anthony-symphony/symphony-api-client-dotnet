using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Authentication;
using Microsoft.Extensions.Configuration;

namespace apiClientDotNetTest
{
    [TestClass]
    public class MessageTest
    {
        private static SymBotClient botClient = null;
        private static string attachmentTestPath = null;
        private static IConfigurationRoot config;

        [ClassInitialize]
        public static void Setup(TestContext conext)
        {
            // Load integration test settings
            var integrationConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "integration.parameters.json");
            config = new ConfigurationBuilder().AddJsonFile(integrationConfigPath).Build();

            // Create SymBotClient
            var symConfigLoader = new SymConfigLoader();
            attachmentTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "AttachmentTest.txt");
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            var symConfig = symConfigLoader.loadFromFile(configPath);
            var botAuth = new SymBotRSAAuth(symConfig);
            botAuth.authenticate();
            botClient = SymBotClient.initBot(symConfig, botAuth);        
        }
     
        [TestMethod]
        public void SearchRoom()
        {
            var streamClient = botClient.getStreamsClient();
            var roomSearchQuery = new RoomSearchQuery
            {
                Query = config.GetSection("test_room_name").Value,
                Active = true,
                IsPrivate = true
            };
            var result = streamClient.searchRooms(roomSearchQuery, 0, 0);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 1);
        }

        [TestMethod]
        public void GetUserIdByUserName()
        {
            var userClient = botClient.getUsersClient();
            var user = userClient.getUserFromUsername(config.GetSection("test_username").Value);
            Assert.IsNotNull(user);
            Assert.AreEqual(config.GetSection("test_displayname").Value, user.DisplayName);
        }

        [TestMethod]
        public void ListUserStreamsAndSendMessage()
        {
            var streamClient = botClient.getStreamsClient();
            var streamTypes = new List<string>
            {
                "IM",
                "ROOM"
            };
            var result = streamClient.getUserStreams(streamTypes,false);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 1);

            MessageRoomTest(result[0].Id);
        }

        public void MessageRoomTest(string streamId)
        {
            var fileStream = File.OpenRead(attachmentTestPath);
            var attachments = new List<FileStream>
            {
                fileStream
            };
            var message = new OutboundMessage
            {
                Message = "<messageML>Hello world! From .NET SDK Integration Test.</messageML>"
            };
            message.Attachments = attachments;
            var stream = new apiClientDotNet.Models.Stream
            {
                StreamId = streamId
            };

            var messageClient = new MessageClient(botClient);
            var resp = messageClient.sendMessage(stream.StreamId, message, false);
            Assert.IsNotNull(resp.MessageId);
        }
    }
}
