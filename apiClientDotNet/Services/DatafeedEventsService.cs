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
                if(eventv4.initiator.user.userId != BotClient.GetBotUserInfo().id)
                {
                    switch (eventv4.type)
                    {
                        case "MESSAGESENT":

                            MessageSent messageSent = eventv4.payload.messageSent;
                            if (messageSent.message.stream.streamType.Equals("ROOM"))
                            {
                                foreach (RoomListener listener in RoomListeners)
                                {
                                    listener.onRoomMessage(messageSent.message);
                                }
                            }
                            else
                            {
                                foreach (IMListener listener in IMListeners)
                                {
                                    listener.onIMMessage(messageSent.message);
                                }
                            }
                            break;
                        case "INSTANTMESSAGECREATED":

                            foreach (IMListener listeners in IMListeners)
                            {
                                listeners.onIMCreated(eventv4.payload.instantMessageCreated.stream);
                            }
                            break;

                        case "ROOMCREATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onRoomCreated(eventv4.payload.roomCreated);
                            }
                            break;

                        case "ROOMUPDATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onRoomUpdated(eventv4.payload.roomUpdated);
                            }
                            break;

                        case "ROOMDEACTIVATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onRoomDeactivated(eventv4.payload.roomDeactivated);
                            }
                            break;

                        case "ROOMREACTIVATED":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onRoomReactivated(eventv4.payload.roomReactivated.stream);
                            }
                            break;

                        case "USERJOINEDROOM":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onUserJoinedRoom(eventv4.payload.userJoinedRoom);
                            }
                            break;

                        case "USERLEFTROOM":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onUserLeftRoom(eventv4.payload.userLeftRoom);
                            }
                            break;

                        case "ROOMMEMBERPROMOTEDTOOWNER":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onRoomMemberPromotedToOwner(eventv4.payload.roomMemberPromotedToOwner);
                            }
                            break;

                        case "ROOMMEMBERDEMOTEDFROMOWNER":

                            foreach (RoomListener listener in RoomListeners)
                            {
                                listener.onRoomMemberDemotedFromOwner(eventv4.payload.roomMemberDemotedFromOwner);
                            }
                            break;

                        case "CONNECTIONACCEPTED":

                            foreach (ConnectionListener listener in ConnectionListeners)
                            {
                                listener.onConnectionAccepted(eventv4.payload.connectionAccepted.fromUser);
                            }
                            break;

                        case "CONNECTIONREQUESTED":

                            foreach (ConnectionListener listener in ConnectionListeners)
                            {
                                listener.onConnectionRequested(eventv4.payload.connectionRequested.toUser);
                            }
                            break;

			            case "SYMPHONYELEMENTSACTION":
                            var StreamID = eventv4.payload.symphonyElementsAction.formStream.streamId.ToString();
                            StreamID = StreamID.Replace("=","");
                            StreamID = StreamID.Replace("/","_");
                            StreamID = StreamID.Replace("+","-");

                            SymphonyElementsAction symphonyElementsAction = eventv4.payload.symphonyElementsAction;
			                User user = eventv4.initiator.user;
                            foreach (ElementsActionListener listener in ElementsActionListeners)
                            {
                                listener.onFormMessage(user, StreamID, symphonyElementsAction);
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
