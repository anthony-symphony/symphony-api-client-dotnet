using System.ComponentModel;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SymConfig
    {
        [JsonProperty("sessionAuthHost")]
        public string SessionAuthHost { get; set; }

        [JsonProperty("sessionAuthPort", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(443)]
        public int SessionAuthPort { get; set; }

        [JsonProperty("keyAuthHost")]
        public string KeyAuthHost { get; set; }

        [JsonProperty("keyAuthPort", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(443)]
        public int KeyAuthPort { get; set; }

        [JsonProperty("podHost")]
        public string PodHost { get; set; }

        [JsonProperty("podPort", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(443)]
        public int PodPort { get; set; }

        [JsonProperty("agentHost")]
        public string AgentHost { get; set; }

        [JsonProperty("agentPort", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(443)]
        public int AgentPort { get; set; }

        [JsonProperty("botCertPath")]
        public string BotCertPath { get; set; }

        [JsonProperty("botCertName")]
        public string BotCertName { get; set; }

        [JsonProperty("botCertPassword")]
        public string BotCertPassword { get; set; }

        [JsonProperty("botEmailAddress")]
        public string BotEmailAddress { get; set; }

        [JsonProperty("appCertPath")]
        public string AppCertPath { get; set; }

        [JsonProperty("appCertName")]
        public string AppCertName { get; set; }

        [JsonProperty("appCertPassword")]
        public string AppCertPassword { get; set; }

        [JsonProperty("authTokenRefreshPeriod")]
        public string AuthTokenRefreshPeriod { get; set; }

        [JsonProperty("botPrivateKeyPath")]
        public string BotPrivateKeyPath { get; set; }

        [JsonProperty("botPrivateKeyName")]
        public string BotPrivateKeyName { get; set; }

        [JsonProperty("botUsername")]
        public string BotUsername { get; set; }

        #region Global Proxy
        [JsonProperty("proxyURL")]
        public string ProxyURL { get; set; }

        [JsonProperty("proxyUsername")]
        public string ProxyUsername { get; set; }

        [JsonProperty("proxyPassword")]
        public string ProxyPassword { get; set; }
        #endregion

        #region Session proxy
        [JsonProperty("sessionProxyURL")]
        public string SessionProxyURL { get; set; }

        [JsonProperty("sessionProxyUsername")]
        public string SessionProxyUsername { get; set; }

        [JsonProperty("sessionProxyPassword")]
        public string SessionProxyPassword { get; set; }
        #endregion

        #region Key Manager proxy
        [JsonProperty("keyManagerProxyURL")]
        public string KeyManagerProxyURL { get; set; }

        [JsonProperty("keyManagerProxyUsername")]
        public string KeyManagerProxyUsername { get; set; }

        [JsonProperty("keyManagerProxyPassword")]
        public string KeyManagerProxyPassword { get; set; }
        #endregion

        #region Pod proxy
        [JsonProperty("podProxyURL")]
        public string PodProxyURL { get; set; }

        [JsonProperty("podProxyUsername")]
        public string PodProxyUsername { get; set; }

        [JsonProperty("podProxyPassword")]
        public string PodProxyPassword { get; set; }
        #endregion

        #region Agent proxy
        [JsonProperty("agentProxyURL")]
        public string AgentProxyURL { get; set; }

        [JsonProperty("agentProxyUsername")]
        public string AgentProxyUsername { get; set; }

        [JsonProperty("agentProxyPassword")]
        public string AgentProxyPassword { get; set; }
        #endregion
    }
}