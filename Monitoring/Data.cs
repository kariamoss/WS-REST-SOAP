using Monitoring.JCDecauxAdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring
{
    public class Data
    {
        AdminStats adminStats;
        JCDecauxAdminClient client;

        public Data()
        {
            client = new JCDecauxAdminClient();
        }

        public void Refresh()
        {
            adminStats = client.GetStats();
        }

        public AdminStats GetStats()
        {
            return adminStats;
        }

        public Request[] GetRequest()
        {
            return adminStats.Requests;
        }

        public int GetTimeForRequests()
        {
            return adminStats.TimeForRequests;
        }

        public int GetTimeCached()
        {
            return adminStats.TimeCachedSec;
        }

        public int GetNbRequest()
        {
            return adminStats.NbRequests;
        }

        public int GetNbRequestOnCache()
        {
            return adminStats.NbRequestsOnCache;
        }

        public AdminStats SetTimeCachedSec(int timeCached)
        {
            return client.SetTimeCache(timeCached);
        }

        public AdminStats SetTimeForRequests(int timeForRequests)
        {
            return client.SetTimeForRequests(timeForRequests);
        }
    }
}
