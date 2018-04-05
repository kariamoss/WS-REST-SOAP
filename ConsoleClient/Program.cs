using ConsoleClient.JCDecauxServiceRef;
using System;
using System.ServiceModel;

namespace ConsoleClient
{
    class Program
    {
        static VelibCallBack callBack = new VelibCallBack();
        static InstanceContext iCntxt = new InstanceContext(callBack);

        static JCDecauxServiceRef.JCDecauxOperationsClient client = new JCDecauxServiceRef.JCDecauxOperationsClient(iCntxt);


        static void Help()
        {
            Console.WriteLine("Donnez dans un premier temps la ville où JCDecaux est implémenté \n" +
                "Puis rentrez la station voulue \n" +
                "Vous pouvez à tout moment quitter l'application avec la commande quit\n" +
                "Vous pouvez afficher ce message avec la commande help");
        }

        static Boolean ShowTowns(String town)
        {
            client.GetStationsFromTown(town);
            return true;
        }

        static void ShowStations(String town, String station)
        {
            client.GetStation(station, town);
        }

        static void Main(string[] args)
        {
            client.SubscribeGetStationsFromTownEvent();
            client.SubscribeGetStationEvent();
            client.SubscribeGetStationFinishedEvent();
            client.SubscribeGetStationsFromTownFinishedEvent();

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
                        ShowStations(town, station);
                        break;
                    }
                }
            }
        }
    }
}
