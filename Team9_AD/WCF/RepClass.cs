using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class RepClass
    {
        [DataMember]
        public string Category;
        [DataMember]
        public string Discription;
        [DataMember]
        public int? RequestQuantity;
        [DataMember]
        public int? DeliveredQuantity;

        public RepClass(string category, string discription, int? requestQuantity, int? deliveredQuantity)
        {
            Category = category;
            Discription = discription;
            RequestQuantity = requestQuantity;
            DeliveredQuantity = deliveredQuantity;
        }
    }
}