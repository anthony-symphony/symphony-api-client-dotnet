using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet;
using apiClientDotNet.Models;


namespace apiClientDotNetTest
{
    [TestClass]
    public class LoadConfigFileTest
    {

        [TestMethod]
        public void ForGivenConfigFile_CorrectlyLoadsTheConfigurationProperties()
        {
            var symConfigLoader = new SymConfigLoader();
            var configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "config.json");
            var symConfig = symConfigLoader.loadFromFile(configPath);
            Assert.IsNotNull(symConfig);
            Assert.IsNotNull(symConfig.AgentHost);
            Assert.IsNotNull(symConfig.KeyAuthHost);
            Assert.IsNotNull(symConfig.PodHost);
            Assert.IsNotNull(symConfig.BotEmailAddress);
            Assert.IsNotNull(symConfig.BotPrivateKeyName);
            Assert.IsNotNull(symConfig.BotUsername);
        }
    }
}
