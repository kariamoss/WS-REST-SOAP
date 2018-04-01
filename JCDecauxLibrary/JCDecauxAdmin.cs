using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDecauxLibrary
{
    class JCDecauxAdmin : IJCDecauxAdmin
    {
        public AdminStats GetStats()
        {
            AdminStats a = AdminStats.GetInstance();
            return a.Build();
        }

        public AdminStats SetTimeCache(int timeCache)
        {
            AdminStats.GetInstance().TimeCachedSec = timeCache;
            return AdminStats.GetInstance().Build();
        }

        public AdminStats SetTimeForRequests(int timeForRequests)
        {
            AdminStats.GetInstance().TimeForRequests = timeForRequests;
            return AdminStats.GetInstance().Build();
        }
    }
}
