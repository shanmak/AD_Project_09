using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_DamageUpdate
    {
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int? Quantity { get; set; }

        [DataMember]
        public string Employee_ID { get; set; }


    }
}