using System;
using System.IO;
using System.Net;
using System.ServiceModel.Activation;

namespace JCDecauxLibrary
{

    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class JCDecauxOperations : IJCDecauxOperations
    {
        public String GetContracts(String key)
        {
            Console.WriteLine("Got those contracts");
            WebRequest request = WebRequest.Create
                ("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + key);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(dataStream);

            return stream.ReadToEnd();
        }
        
        public String GetStationsFromTown(String key, String town)
        {
            Console.WriteLine("Got those stations");
            WebRequest request = WebRequest.Create
                ("https://api.jcdecaux.com/vls/v1/stations?contract=" + town + "&apiKey=" + key);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader stream = new StreamReader(dataStream);

            return stream.ReadToEnd();
        }
    }
}
