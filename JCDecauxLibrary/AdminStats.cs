using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JCDecauxLibrary
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public String Content { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Boolean IsCached { get; set; }

        public Request(string content, DateTime date, bool isCached)
        {
            Content = content;
            Date = date;
            IsCached = isCached;
        }
    }

    [DataContract]
    public class AdminStats
    {
        [DataMember]
        public int NbRequests { get; set; }
        [DataMember]
        public int NbRequestsOnCache { get; set; }
        [DataMember]
        public int TimeCachedSec { get; set; }
        [DataMember]
        public Request[] Requests { get; set; }
        [DataMember]
        public int TimeForRequests { get; set; }

        private List<Request> AllRequests { get; set; }
        private static AdminStats instance;
        public AdminStats()
        {
            NbRequests = 0;
            NbRequestsOnCache = 0;
            TimeCachedSec = 120;
            TimeForRequests = 240;
            Requests = null;
            AllRequests = new List<Request>();
        }

        public static AdminStats GetInstance()
        {
            if (instance == null)
            {
                instance = new AdminStats();
            }
            
            return instance;
        }

        /**
         * Build requests to send based on TimeForRequests set
         **/
        public AdminStats Build()
        {
            var Req = new List<Request>();
            if (AllRequests == null) return this;
            for (int i = 0; i < AllRequests.Count; i++)
            {
                if (AllRequests[i].Date.AddSeconds(TimeForRequests) >= DateTime.Now)
                {
                    Req.Add(AllRequests[i]);
                }
            }
            Requests = Req.ToArray();
            return this;
        }

        private void AddRequest() { NbRequests++; }

        private void AddRequestCache() { NbRequestsOnCache++; }

        public void AddRequest(String Request, Boolean IsCached) {
            AllRequests.Add(new Request(Request, DateTime.Now, IsCached));
            if (IsCached)
            {
                AddRequestCache();
            }
            else
            {
                AddRequest();
            }
        }
    }
}
