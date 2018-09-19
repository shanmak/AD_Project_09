using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Inventory_purchase
    {
        [DataMember]
        public int Purchase_ID;

        [DataMember]
        public string Supplier_ID;

        [DataMember]
        public DateTime? Date_Order;

        
        public WCF_Inventory_purchase(int purchase_ID, string supplier_ID, DateTime? date_Order)
        {
            this.Purchase_ID = purchase_ID;
            this.Supplier_ID = supplier_ID;
            this.Date_Order = date_Order;
        }
    }
}