using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Wrehse_Trans_Dtl
    {
        [DataMember]
        public int Trans_ID;

        [DataMember]
        public string Item_number;

        [DataMember]
        public string Supplier_ID;

        [DataMember]
        public int? Retrived_Qunty;

        public WCF_Wrehse_Trans_Dtl(int trans_ID, string item_number, string supplier_ID, int? retrived_Qunty)
        {
            this.Trans_ID = trans_ID;
            this.Item_number = item_number;
            this.Supplier_ID = supplier_ID;
            this.Retrived_Qunty = retrived_Qunty;
        }
    }
}