using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Invent_Pur_Dtl
    {
        [DataMember]
        public int Purchase_ID;

        [DataMember]
        public string Item_number;

        [DataMember]
        public string Description;

        [DataMember]
        public int? Quantity;

        public WCF_Invent_Pur_Dtl(int purchase_ID, string item_number, string description, int? quantity)
        {
            this.Purchase_ID = purchase_ID;
            this.Item_number = item_number;
            this.Description = description;
            this.Quantity = quantity;
        }
    }
}