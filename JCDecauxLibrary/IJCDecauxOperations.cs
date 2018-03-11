using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace JCDecauxLibrary
{
    [ServiceContract]
    public interface IJCDecauxOperations
    {
        [OperationContract]
        //[AspNetCacheProfile("CacheFor60Seconds")]
        String GetContracts(String key);
        
        [OperationContract]
        //[AspNetCacheProfile("CacheFor60Seconds")]
        String GetStationsFromTown(String key, String town);
    }
}
