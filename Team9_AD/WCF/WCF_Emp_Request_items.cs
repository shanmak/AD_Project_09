using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Emp_Request_items
    {
        [DataMember]
        public int Request_ID;

        [DataMember]
        public string Item_Number;

        [DataMember]
        public int? Quantity;

        [DataMember]
        public string Status;

        [DataMember]
        public string Comments;

        public WCF_Emp_Request_items(int request_ID, string item_Number, int? quantity, string status, string comments)
        {
            this.Request_ID = request_ID;
            this.Item_Number = item_Number;
            this.Quantity = quantity;
            this.Status = status;
            this.Comments = comments;
        }
    }
}