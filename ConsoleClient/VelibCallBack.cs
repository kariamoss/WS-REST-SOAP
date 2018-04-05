using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient.JCDecauxServiceRef;

namespace ConsoleClient
{
    class VelibCallBack : JCDecauxServiceRef.IJCDecauxOperationsCallback
    {
        public void GetStationFinished()
        {
            Console.WriteLine(">");
        }

        public void GetStationsFinished()
        {
            Console.WriteLine(">");
        }

        public void GotStation(string station, string town, Station stationResult)
        {
            if (stationResult == null)
            {
                Console.WriteLine("La station n'existe pas");
            }
            else
            {
                Console.WriteLine("" + "Il y a " + stationResult.Available_bikes + " vélos disponibles." + Environment.NewLine
            + "On peut encore y ranger " + stationResult.Available_bike_stands + " vélos.");
            }
        }

        public void GotStationsFromTown(string town, Station[] stationsResult)
        {
            try
            {
                foreach (Station o in stationsResult)
                {
                    Console.WriteLine(o.Name);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("La ville n'existe pas");
            }
        }
    }
}
