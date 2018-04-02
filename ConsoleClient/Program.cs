using ConsoleClient.JCDecauxLibrary;
using System;

namespace ConsoleClient
{
    class Program
    {
        static JCDecauxOperationsClient client = new JCDecauxOperationsClient();

        static void Help()
        {
            Console.WriteLine("Donnez dans un premier temps la ville où JCDecaux est implémenté \n" +
                "Puis rentrez la station voulue \n" +
                "Vous pouvez à tout moment quitter l'application avec la commande quit\n" +
                "Vous pouvez afficher ce message avec la commande help");
        }

        static bool ShowTowns(String town)
        {
            Station[] stations = null;
            try
            {
                stations = client.GetStationsFromTown(town);
            }
            catch (Exception)
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
            else
            {
                Console.WriteLine("La ville n'existe pas");
                return false;
            }
        }

        static bool ShowStations(String town, String station)
        {
            Station stationRes = client.GetAvailableVelib(station, town);

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
                    else if (town == "help") Help();
                    else
                    {
                        if (ShowTowns(town)) break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Donnez le nom d'une station");
                    station = Console.ReadLine();
                    if (station == "quit") return;
                    else if (station == "help") Help();
                    else
                    {
                        if (ShowStations(town, station)) break;
                    }
                }
            }
        }
    }
}
