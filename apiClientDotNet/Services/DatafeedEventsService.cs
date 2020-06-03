using System;
using System.Collections.Generic;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Listeners;
using System.Threading.Tasks;

namespace apiClientDotNet.Services
{
    public class DatafeedEventsService
    {

        static bool StopLoop = false;
        private List<IRoomListener> RoomListeners;
        private List<IIMListener> IMListeners;
        private List<IConnectionListener> ConnectionListeners;
	    private List<IElementsActionListener> ElementsActionListeners;
        private DatafeedClient DatafeedClient;
        private SymBotClient BotClient;
        public Datafeed Datafeed;
        public String DatafeedId
        {
            get { return Datafeed.DatafeedId; }
            set { Datafeed.DatafeedId = value; }
        }
        public string datafeedId
        {
            get { return Datafeed.DatafeedId; }
            set { Datafeed.DatafeedId = value; }
        }

        public DatafeedEventsService(SymBotClient client)
        {
            BotClient = client;
            RoomListeners = new List<IRoomListener>();
            IMListeners = new List<IIMListener>();
            ConnectionListeners = new List<IConnectionListener>();
	        ElementsActionListeners = new List<IElementsActionListener>();
            DatafeedClient = client.GetDatafeedClient();
            Datafeed = DatafeedClient.CreateDatafeed();
        }

        public DatafeedClient Init()
        {
            DatafeedClient = new DatafeedClient(BotClient);
            return DatafeedClient;
        }

        public void StopGettingEventsFromDatafeed()
        {
            StopLoop = true;
        }

        public void GetEventsFromDatafeed()
        {
            Task.Run(() => StartReadingDatafeed()).Wait();
        }

        public Task GetEventsFromDatafeedAsync()
        {
            return Task.Run(() => StartReadingDatafeed());
        }

        private async Task StartReadingDatafeed()
        {
            while (!StopLoop)
            {
                List<DatafeedEvent> events = new List<DatafeedEvent>();
                try
                {
                    events = await Task.Run(() => GetEvents(Datafeed, DatafeedClient));
                    _ = Task.Run(() => HandleEvents(events));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static List<DatafeedEvent> GetEvents(Datafeed datafeed, DatafeedClient datafeedClient)
        {
            List<DatafeedEvent> events = datafeedClient.GetEventsFromDatafeed(datafeed);
            return events;
        }

        private void HandleEvents(List<DatafeedEvent> datafeedEvents)
        {
            foreach (DatafeedEvent eventv4 in datafeedEvents)
            {
                if(eventv4.Initiator.User.UserId != BotClient.GetBotUserInfo().Id)
                {
                    switch (eventv4.Type)
                    {
                        case "MESSAGESENT":

                            MessageSent messageSent = eventv4.Payload.MessageSent;
                            if (messageSent.Message.Stream.StreamType.Equals("ROOM"))
                            {
                                foreach (IRoomListener listener in RoomListeners)
                                {
                                    listener.OnRoomMessage(messageSent.Message);
                                }
                            }
                            else
                            {
                                foreach (IIMListener listener in IMListeners)
                                {
                                    listener.OnIMMessage(messageSent.Message);
                                }
                            }
                            break;
                        case "INSTANTMESSAGECREATED":

                            foreach (IIMListener listeners in IMListeners)
                            {
                                listeners.OnIMCreated(eventv4.Payload.InstantMessageCreated.Stream);
                            }
                            break;

                        case "ROOMCREATED":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnRoomCreated(eventv4.Payload.RoomCreated);
                            }
                            break;

                        case "ROOMUPDATED":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnRoomUpdated(eventv4.Payload.RoomUpdated);
                            }
                            break;

                        case "ROOMDEACTIVATED":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnRoomDeactivated(eventv4.Payload.RoomDeactivated);
                            }
                            break;

                        case "ROOMREACTIVATED":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnRoomReactivated(eventv4.Payload.RoomReactivated.Stream);
                            }
                            break;

                        case "USERJOINEDROOM":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnUserJoinedRoom(eventv4.Payload.UserJoinedRoom);
                            }
                            break;

                        case "USERLEFTROOM":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnUserLeftRoom(eventv4.Payload.UserLeftRoom);
                            }
                            break;

                        case "ROOMMEMBERPROMOTEDTOOWNER":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnRoomMemberPromotedToOwner(eventv4.Payload.RoomMemberPromotedToOwner);
                            }
                            break;

                        case "ROOMMEMBERDEMOTEDFROMOWNER":

                            foreach (IRoomListener listener in RoomListeners)
                            {
                                listener.OnRoomMemberDemotedFromOwner(eventv4.Payload.RoomMemberDemotedFromOwner);
                            }
                            break;

                        case "CONNECTIONACCEPTED":

                            foreach (IConnectionListener listener in ConnectionListeners)
                            {
                                listener.OnConnectionAccepted(eventv4.Payload.ConnectionAccepted.FromUser);
                            }
                            break;

                        case "CONNECTIONREQUESTED":

                            foreach (IConnectionListener listener in ConnectionListeners)
                            {
                                listener.OnConnectionRequested(eventv4.Payload.ConnectionRequested.ToUser);
                            }
                            break;

			            case "SYMPHONYELEMENTSACTION":
                            var streamID = eventv4.Payload.SymphonyElementsAction.FormStream.StreamId.ToString();
                            SymphonyElementsAction symphonyElementsAction = eventv4.Payload.SymphonyElementsAction;
			                User user = eventv4.Initiator.User;
                            foreach (IElementsActionListener listener in ElementsActionListeners)
                            {
                                listener.OnFormMessage(user, streamID, symphonyElementsAction);
                            }
                            break;  
                        default:
                            break;
                    }
                }  
            }
        }

        public void AddRoomListener(IRoomListener listener)
        {
            RoomListeners.Add(listener);
        }

        public void RemoveRoomListener(IRoomListener listener)
        {
            RoomListeners.Remove(listener);
        }

        public void AddIMListener(IIMListener listener)
        {
            IMListeners.Add(listener);
        }

        public void RemoveIMListener(IIMListener listener)
        {
            IMListeners.Remove(listener);
        }

        public void AddConnectionsListener(IConnectionListener listener)
        {
            ConnectionListeners.Add(listener);
        }

        public void RemoveConnectionsListener(IConnectionListener listener)
        {
            ConnectionListeners.Remove(listener);
        }

        public void AddElementsActionListener(IElementsActionListener listener)
        {
            ElementsActionListeners.Add(listener);
        }

        public void RemoveElementsActionListener(IElementsActionListener listener)
        {
            ElementsActionListeners.Remove(listener);
        }


        public DatafeedClient init(SymConfig symConfig)
        {
            return Init();
        }

        public void getEventsFromDatafeed()
        {
            GetEventsFromDatafeed();
        }

        public void stopGettingEventsFromDatafeed()
        {
            StopGettingEventsFromDatafeed();
        }
        public void addRoomListener(IRoomListener listener)
        {
            AddRoomListener(listener);
        }

        public void removeRoomListener(IRoomListener listener)
        {
            RemoveRoomListener(listener);
        }

        public void addIMListener(IIMListener listener)
        {
            AddIMListener(listener);
        }

        public void removeIMListener(IIMListener listener)
        {
            RemoveIMListener(listener);
        }

        public void addConnectionsListener(IConnectionListener listener)
        {
            AddConnectionsListener(listener);
        }

        public void removeConnectionsListener(IConnectionListener listener)
        {
            RemoveConnectionsListener(listener);
        }

        public void addElementsActionListener(IElementsActionListener listener)
        {
            AddElementsActionListener(listener);
        }

        public void removeElementsActionListener(IElementsActionListener listener)
        {
            RemoveElementsActionListener(listener);
        }
    }
}
