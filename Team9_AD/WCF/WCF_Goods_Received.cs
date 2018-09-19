using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Goods_Received
    {
        [DataMember]
        public string Received_Code;

        [DataMember]
        public string Item_Number;

        [DataMember]
        public string Category;

        [DataMember]
        public string Description;

        [DataMember]
        public int? Quantity_Recevied;

        [DataMember]
        public string Supplier_ID;

        [DataMember]
        public DateTime? Received_Date;

        public WCF_Goods_Received(string received_Code, string item_Number, string category, string description, int? quantity_Recevied, string supplier_ID, DateTime? received_Date)
        {
            this.Received_Code = received_Code;
            this.Item_Number = item_Number;
            this.Category = category;
            this.Description = description;
            this.Quantity_Recevied = quantity_Recevied;
            this.Supplier_ID = supplier_ID;
            this.Received_Date = received_Date;
        }
    }
}