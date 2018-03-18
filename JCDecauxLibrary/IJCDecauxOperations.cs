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
        Town[] GetTowns(String key);
        
        [OperationContract]
        //[AspNetCacheProfile("CacheFor60Seconds")]
        Station[] GetStationsFromTown(String key, String town);

        [OperationContract]
        //[AspNetCacheProfile("CacheFor60Seconds")]
        Station GetAvailableVelib(String key, String station, string town);
    }
}
