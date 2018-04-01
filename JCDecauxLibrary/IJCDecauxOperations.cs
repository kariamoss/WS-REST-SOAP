using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace JCDecauxLibrary
{
    [ServiceContract]
    public interface IJCDecauxOperations
    {
        [OperationContract]
        //[AspNetCacheProfile("CacheFor60Seconds")]
        Town[] GetTowns();
        
        [OperationContract]
        //[AspNetCacheProfile("CacheFor60Seconds")]
        Station[] GetStationsFromTown(String town);

        [OperationContract]
        //[AspNetCacheProfile("CacheFor60Seconds")]
        Station GetAvailableVelib(String station, string town);
    }
}
