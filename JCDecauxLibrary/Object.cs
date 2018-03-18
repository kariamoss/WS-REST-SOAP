using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JCDecauxLibrary
{
    [DataContract]
    public class Town
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class Station
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Available_bike_stands { get; set; }
        [DataMember]
        public int Available_bikes { get; set; }
    }
}
