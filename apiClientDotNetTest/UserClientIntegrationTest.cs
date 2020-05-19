using apiClientDotNet;
using apiClientDotNet.Authentication;
using apiClientDotNet.Clients;
using apiClientDotNet.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace apiClientDotNetTest
{
    [TestClass]
    public class UserClientIntegrationTest
    {
        private static SymBotClient symBotClient;
        private static IConfigurationRoot config;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            // Load integration test settings
            var integrationConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "integration.parameters.json");
            config = new ConfigurationBuilder().AddJsonFile(integrationConfigPath).Build();

            // Create SymBotClient
            var symConfig = new SymConfig();
            var symConfigLoader = new SymConfigLoader();
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            symConfig = symConfigLoader.loadFromFile(configPath);
            var botAuth = new SymBotRSAAuth(symConfig);
            botAuth.Authenticate();
            symBotClient = SymBotClient.InitBot(symConfig, botAuth);
        }

        [TestMethod]
        public void GetUsersV3_forGivenListOfEmails_correctlyReturnListOfUsers()
        {
            var emails = config.GetSection(this.GetType().Name).GetSection("test_email_addresses").Value;
            var emailList = emails.Split(",");
            var sut = new UserClient(symBotClient);

            List<UserInfo> listUserInfo = sut.GetUsersByEmail(new List<string>(emailList), false);

            Assert.IsNotNull(listUserInfo);
            Assert.AreEqual(3, listUserInfo.Count);
            Assert.IsFalse(String.IsNullOrEmpty(listUserInfo[0].DisplayName));
            Assert.IsFalse(String.IsNullOrEmpty(listUserInfo[0].Username));

            Assert.IsFalse(String.IsNullOrEmpty(listUserInfo[1].DisplayName));
            Assert.IsFalse(String.IsNullOrEmpty(listUserInfo[1].Username));

            Assert.IsFalse(String.IsNullOrEmpty(listUserInfo[2].DisplayName));
            Assert.IsFalse(String.IsNullOrEmpty(listUserInfo[2].Username));
        }

        [TestMethod]
        public void SearchUsers_forGivenSearchQuery_correctlyReturnsListOfUsers()
        {
            var query = config.GetSection(this.GetType().Name).GetSection("test_search_user_query").Value;
            var sut = new UserClient(symBotClient);

            UserSearchResult searchUsers = sut.SearchUsers(query, null, false, 0, 10);

            Assert.IsNotNull(searchUsers);
            Assert.IsTrue(searchUsers.Users.Count >= 1);
        }
    }
}
