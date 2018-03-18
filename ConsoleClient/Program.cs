using ConsoleClient.JCDecauxLibrary;
using System;

namespace ConsoleClient
{
    class Program
    {
        static String key = "0fd193fbd29d80003eca2314c7a382831b9eb03f";
        static JCDecauxOperationsClient client = new JCDecauxOperationsClient();

        static void help()
        {
            Console.WriteLine("Donnez dans un premier temps la ville où JCDecaux est implémenté \n" +
                "Puis rentrez la station voulue \n" +
                "Vous pouvez à tout moment quitter l'application avec la commande quit\n" +
                "Vous pouvez afficher ce message avec la commande help");
        }

        static bool showTowns(String town)
        {
            Station[] stations = null;
            try
            {
                stations = client.GetStationsFromTown(key, town);
            }
            catch (Exception e)
            {
                Console.WriteLine("La ville n'existe pas");
                return false;
            }

            if (stations != null)
            {
                foreach (Station o in stations)
                {
                    Console.WriteLine(o.Name);
                }
                return true;
            }
            return false;
        }

        static bool showStations(String town, String station)
        {
            Station stationRes = client.GetAvailableVelib(key, station, town);

            if (stationRes == null)
            {
                Console.WriteLine("La station n'existe pas");
                return false;
            }
            else
            {
                Console.WriteLine("" + "Il y a " + stationRes.Available_bikes + " vélos disponibles." + Environment.NewLine
            + "On peut encore y ranger " + stationRes.Available_bike_stands + " vélos.");
                return true;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string town;
                string station;
                while (true)
                {
                    Console.WriteLine("Rentrez le nom d'un ville");
                    town = Console.ReadLine();
                    if (town == "quit") return;
                    else if (town == "help") help();
                    else
                    {
                        if (showTowns(town)) break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Donnez le nom d'une station");
                    station = Console.ReadLine();
                    if (station == "quit") return;
                    else if (station == "help") help();
                    else
                    {
                        if (showStations(town, station)) break;
                    }
                }
            }
        }
    }
}
