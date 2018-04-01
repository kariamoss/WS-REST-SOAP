using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDecauxLibrary
{
    [ServiceContract]
    public interface IJCDecauxAdmin
    {
        [OperationContract]
        AdminStats GetStats();

        [OperationContract]
        AdminStats SetTimeCache(int timeCache);

        [OperationContract]
        AdminStats SetTimeForRequests(int timeForRequests);
    }
}
