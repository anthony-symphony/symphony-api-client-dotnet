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
        private List<RoomListener> RoomListeners;
        private List<IMListener> IMListeners;
        private List<ConnectionListener> ConnectionListeners;
	    private List<ElementsActionListener> ElementsActionListeners;
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
            RoomListeners = new List<RoomListener>();
            IMListeners = new List<IMListener>();
            ConnectionListeners = new List<ConnectionListener>();
	        ElementsActionListeners = new List<ElementsActionListener>();
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
                                foreach (RoomListener listener in RoomListeners)
                                {
                                    listener.OnRoomMessage(messageSent.Message);
                                }
                            }
                            else
                            {
                                foreach (IMListener listener in IMListeners)
                                {
                                    listener.OnIMMessage(messageSent.Message);
                                }
                            }
                            break;
                        case "INSTANTMESSAGECREATED":

                            foreach (IMListener listeners in IMListeners)
                            {
                                listeners.OnIMCreated(eventv4.Payload.InstantMessageCreated.Stream);
                            }
                            break;

                        case "ROOMCREATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnRoomCreated(eventv4.Payload.RoomCreated);
                            }
                            break;

                        case "ROOMUPDATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnRoomUpdated(eventv4.Payload.RoomUpdated);
                            }
                            break;

                        case "ROOMDEACTIVATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnRoomDeactivated(eventv4.Payload.RoomDeactivated);
                            }
                            break;

                        case "ROOMREACTIVATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnRoomReactivated(eventv4.Payload.RoomReactivated.Stream);
                            }
                            break;

                        case "USERJOINEDROOM":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnUserJoinedRoom(eventv4.Payload.UserJoinedRoom);
                            }
                            break;

                        case "USERLEFTROOM":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnUserLeftRoom(eventv4.Payload.UserLeftRoom);
                            }
                            break;

                        case "ROOMMEMBERPROMOTEDTOOWNER":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnRoomMemberPromotedToOwner(eventv4.Payload.RoomMemberPromotedToOwner);
                            }
                            break;

                        case "ROOMMEMBERDEMOTEDFROMOWNER":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.OnRoomMemberDemotedFromOwner(eventv4.Payload.RoomMemberDemotedFromOwner);
                            }
                            break;

                        case "CONNECTIONACCEPTED":

                            foreach (ConnectionListener listener in ConnectionListeners)
                            {
                                listener.OnConnectionAccepted(eventv4.Payload.ConnectionAccepted.FromUser);
                            }
                            break;

                        case "CONNECTIONREQUESTED":

                            foreach (ConnectionListener listener in ConnectionListeners)
                            {
                                listener.OnConnectionRequested(eventv4.Payload.ConnectionRequested.ToUser);
                            }
                            break;

			            case "SYMPHONYELEMENTSACTION":
                            var streamID = eventv4.Payload.SymphonyElementsAction.FormStream.StreamId.ToString();
                            SymphonyElementsAction symphonyElementsAction = eventv4.Payload.SymphonyElementsAction;
			                User user = eventv4.Initiator.User;
                            foreach (ElementsActionListener listener in ElementsActionListeners)
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

        public void AddRoomListener(RoomListener listener)
        {
            RoomListeners.Add(listener);
        }

        public void RemoveRoomListener(RoomListener listener)
        {
            RoomListeners.Remove(listener);
        }

        public void AddIMListener(IMListener listener)
        {
            IMListeners.Add(listener);
        }

        public void RemoveIMListener(IMListener listener)
        {
            IMListeners.Remove(listener);
        }

        public void AddConnectionsListener(ConnectionListener listener)
        {
            ConnectionListeners.Add(listener);
        }

        public void RemoveConnectionsListener(ConnectionListener listener)
        {
            ConnectionListeners.Remove(listener);
        }

        public void AddElementsActionListener(ElementsActionListener listener)
        {
            ElementsActionListeners.Add(listener);
        }

        public void RemoveElementsActionListener(ElementsActionListener listener)
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
        public void addRoomListener(RoomListener listener)
        {
            AddRoomListener(listener);
        }

        public void removeRoomListener(RoomListener listener)
        {
            RemoveRoomListener(listener);
        }

        public void addIMListener(IMListener listener)
        {
            AddIMListener(listener);
        }

        public void removeIMListener(IMListener listener)
        {
            RemoveIMListener(listener);
        }

        public void addConnectionsListener(ConnectionListener listener)
        {
            AddConnectionsListener(listener);
        }

        public void removeConnectionsListener(ConnectionListener listener)
        {
            RemoveConnectionsListener(listener);
        }

        public void addElementsActionListener(ElementsActionListener listener)
        {
            AddElementsActionListener(listener);
        }

        public void removeElementsActionListener(ElementsActionListener listener)
        {
            RemoveElementsActionListener(listener);
        }
    }
}
