using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Activation;

namespace JCDecauxLibrary
{

    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class JCDecauxOperations : IJCDecauxOperations
    {
        public Town[] GetTowns(String key)
        {
            WebRequest request = WebRequest.Create
                ("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + key);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(dataStream);
            
            String res = stream.ReadToEnd();
            return JsonConvert.DeserializeObject<Town[]>(res);
        }
        
        public Station[] GetStationsFromTown(String key, String town)
        {
            try
            {
                WebRequest request = WebRequest.Create
                    ("https://api.jcdecaux.com/vls/v1/stations?contract=" + town + "&apiKey=" + key);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader stream = new StreamReader(dataStream);

                String res = stream.ReadToEnd();
                return JsonConvert.DeserializeObject<Station[]>(res);
            }catch(Exception e)
            {
                return null;
            }
        }

        public Station GetAvailableVelib(string key, string station, string town)
        {
            Station[] stations = GetStationsFromTown(key, town);
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            foreach (Station stationF in stations)
            {
                if (stationF.Name.ToLower().Contains(station.ToLower())){
                    return stationF;
                }
            }
            return null;
        }
    }
}
