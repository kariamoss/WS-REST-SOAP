using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace JCDecauxLibrary
{
    [ServiceContract(CallbackContract = typeof(IJCDecauxServiceEvent))]
    public interface IJCDecauxOperations
    {
        [OperationContract]
        Town[] GetTowns();
        
        [OperationContract]
        void GetStationsFromTown(string town);

        [OperationContract]
        void GetStation(string station, string town);

        [OperationContract]
        void SubscribeGetStationsFromTownEvent();

        [OperationContract]
        void SubscribeGetStationsFromTownFinishedEvent();

        [OperationContract]
        void SubscribeGetStationEvent();

        [OperationContract]
        void SubscribeGetStationFinishedEvent();
    }
}
