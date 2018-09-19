using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Store_Request_items
    {
        [DataMember]
        public int StoreRequest_ID;
        [DataMember]
        public string Item_Number;

        [DataMember]
        public string Description;

        [DataMember]
        public int? Req_Quantity;

        [DataMember]
        public int? Delv_Quantity;

        [DataMember]
        public int? Pend_Quantity;

        [DataMember]
        public string Status;

        public WCF_Store_Request_items(int storeRequest_ID,string item_Number, string description, int? req_Quantity, int? delv_Quantity, int? pend_Quantity, string status)
        {
            this.StoreRequest_ID = storeRequest_ID;
            this.Item_Number = item_Number;
            this.Description = description;
            this.Req_Quantity = req_Quantity;
            this.Delv_Quantity = delv_Quantity;
            this.Pend_Quantity = pend_Quantity;
            this.Status = status;
        }
    }
}