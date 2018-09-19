using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Disbursement_List_dtl
    {
        [DataMember]
        public int Disburse_ID;

        [DataMember]
        public string Item_number;

        [DataMember]
        public string Discription;

        [DataMember]
        public int? Quantity;

        public WCF_Disbursement_List_dtl(int disburse_ID, string item_number, string discription, int? quantity)
        {
            this.Disburse_ID = disburse_ID;
            this.Item_number = item_number;
            this.Discription = discription;
            this.Quantity = quantity;
        }
    }
}