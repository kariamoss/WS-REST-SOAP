using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDecauxLibrary
{
    public interface IJCDecauxServiceEvent
    {
        [OperationContract(IsOneWay = true)]
        void GotStationsFromTown(string town, Station[] stationsResult);

        [OperationContract(IsOneWay = true)]
        void GotStation(string station, string town, Station stationResult);

        [OperationContract(IsOneWay = true)]
        void GetStationsFinished();

        [OperationContract(IsOneWay = true)]
        void GetStationFinished();
    }
}
