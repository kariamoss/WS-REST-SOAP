using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace JCDecauxLibrary
{

    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class JCDecauxOperations : IJCDecauxOperations
    {
        String key = "0fd193fbd29d80003eca2314c7a382831b9eb03f";
        AdminStats adminStats = AdminStats.GetInstance();

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
        
        public Station[] GetStationsFromTown(String town)
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

        public Station GetAvailableVelib(string station, string town)
        {
            Cache cache = Cache.GetInstance();
            Station stationCache = null;
            if((stationCache = cache.GetStation(town, station)) == null)
            {
                Station[] stations = GetStationsFromTown(town);
                cache.AddStationsForTown(town, stations);
                foreach (Station stationF in stations)
                {
                    if (stationF.Name.ToLower().Contains(station.ToLower()))
                    {
                        return stationF;
                    }
                }
            }
            else
            {
                adminStats.AddRequest("GetAvailableVelibFrom" + town + "For" + station, true);
            }
            
            return stationCache;
        }
    }
}
