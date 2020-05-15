using apiClientDotNet.Services;
using apiClientDotNet.Models;
using apiClientDotNet.Clients;
using apiClientDotNet.Authentication;
using System.Net;

namespace apiClientDotNet
{
    public class SymBotClient : SymClientBase
    {
        private static SymBotClient BotClient;
        private DatafeedClient DatafeedClient;
        private DatafeedEventsService DatafeedEventsService;
        private UserInfo BotUserInfo;
    
        public static SymBotClient InitBot(SymConfig config, ISymAuth symBotAuth)
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            if (BotClient == null)
            {
                BotClient = new SymBotClient(config, symBotAuth);
                return BotClient;
            }
            return BotClient;
        }

        private SymBotClient(SymConfig config, ISymAuth symBotAuth)
        {
            SymConfig = config;
            SymAuth = symBotAuth;
            InitializeBaseClient();
        }

        public DatafeedEventsService GetDatafeedEventsService()
        {
            if (DatafeedEventsService == null)
            {
               DatafeedEventsService = new DatafeedEventsService(this);
            }
            return DatafeedEventsService;
        }

        public DatafeedClient GetDatafeedClient()
        {   
            if (DatafeedClient == null)
            {
               DatafeedClient = new DatafeedClient(this);
            }
            return DatafeedClient;
        }

        public UserInfo GetBotUserInfo()
        {
            if (BotUserInfo == null)
            {
                BotUserInfo = BotClient.GetUsersClient().GetSessionUser();
            }
            return BotUserInfo;
        }

        
        #region Legacy Forwarders
        public static SymBotClient initBot(SymConfig config, ISymAuth symBotAuth)
        {
            return InitBot(config, symBotAuth);
        }
        public DatafeedEventsService getDatafeedEventsService()
        {
            return GetDatafeedEventsService();
        }
        #endregion
    }
}
