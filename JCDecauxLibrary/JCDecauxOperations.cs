using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceModel;

namespace JCDecauxLibrary
{

    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class JCDecauxOperations : IJCDecauxOperations
    {
        String key = "0fd193fbd29d80003eca2314c7a382831b9eb03f";
        AdminStats adminStats = AdminStats.GetInstance();
        static Action<String, Station[]> m_EventTownB = delegate { };
        static Action m_EventTownE = delegate { };
        static Action<String, String, Station> m_EventStationB = delegate { };
        static Action m_EventStationE = delegate { };

        public Town[] GetTowns()
        {
            adminStats.AddRequest("GetTowns", false);
            WebRequest request = WebRequest.Create
                ("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + key);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(dataStream);
            
            String res = stream.ReadToEnd();
            return JsonConvert.DeserializeObject<Town[]>(res);
        }
        
        private Station[] GetStationsFromTownIntern(String town)
        {
            Cache cache = Cache.GetInstance();
            Station[] stations = null;
            if((stations = cache.GetStations(town)) == null)
            {
                adminStats.AddRequest("GetStationFromTown"+town, false);
                try
                {
                    WebRequest request = WebRequest.Create
                        ("https://api.jcdecaux.com/vls/v1/stations?contract=" + town + "&apiKey=" + key);
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader stream = new StreamReader(dataStream);

                    String res = stream.ReadToEnd();
                    stations = JsonConvert.DeserializeObject<Station[]>(res);
                    cache.AddStationsForTown(town, stations);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                adminStats.AddRequest("GetStationFromTown" + town, true);
            }

            return stations;
            
        }

        public void GetStationsFromTown(String town)
        {
            Cache cache = Cache.GetInstance();
            Station[] stations = null;
            if ((stations = cache.GetStations(town)) == null)
            {
                adminStats.AddRequest("GetStationFromTown" + town, false);
                try
                {
                    WebRequest request = WebRequest.Create
                        ("https://api.jcdecaux.com/vls/v1/stations?contract=" + town + "&apiKey=" + key);
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader stream = new StreamReader(dataStream);

                    String res = stream.ReadToEnd();
                    stations = JsonConvert.DeserializeObject<Station[]>(res);
                    cache.AddStationsForTown(town, stations);
                }
                catch (Exception)
                {
                    stations = null;
                }
            }
            else
            {
                adminStats.AddRequest("GetStationFromTown" + town, true);
            }

            m_EventTownB(town, stations);
            m_EventTownE();
        }

        public void GetStation(string station, string town)
        {
            Cache cache = Cache.GetInstance();
            Station stationCache = null;
            if((stationCache = cache.GetStation(town, station)) == null)
            {
                Station[] stations = GetStationsFromTownIntern(town);
                if (stations == null)
                {
                    m_EventStationB(station, town, stationCache);
                    m_EventStationE();
                    return;
                }
                cache.AddStationsForTown(town, stations);
                foreach (Station stationF in stations)
                {
                    if (stationF.Name.ToLower().Contains(station.ToLower()))
                    {
                        m_EventStationB(station, town, stationF);
                        m_EventStationE();
                    }
                }
            }
            else
            {
                adminStats.AddRequest("GetAvailableVelibFrom" + town + "For" + station, true);
            }

            m_EventStationB(station, town, stationCache);
            m_EventStationE();
        }

        public void SubscribeGetStationsFromTownEvent()
        {
            IJCDecauxServiceEvent subscriber =
           OperationContext.Current.GetCallbackChannel<IJCDecauxServiceEvent>();
            m_EventTownB += subscriber.GotStationsFromTown;
        }

        public void SubscribeGetStationsFromTownFinishedEvent()
        {
            IJCDecauxServiceEvent subscriber =
           OperationContext.Current.GetCallbackChannel<IJCDecauxServiceEvent>();
            m_EventTownE += subscriber.GetStationsFinished;
        }

        public void SubscribeGetStationEvent()
        {
            IJCDecauxServiceEvent subscriber =
           OperationContext.Current.GetCallbackChannel<IJCDecauxServiceEvent>();
            m_EventStationB += subscriber.GotStation;
        }

        public void SubscribeGetStationFinishedEvent()
        {
            IJCDecauxServiceEvent subscriber =
           OperationContext.Current.GetCallbackChannel<IJCDecauxServiceEvent>();
            m_EventStationE += subscriber.GetStationFinished;
        }
    }
}
