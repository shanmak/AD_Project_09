using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Supplier
    {
        [DataMember]
        public string Supplier_ID;

        [DataMember]
        public string Supplier_Name;

        [DataMember]
        public string Contact_Name;

        [DataMember]
        public int? Phone_Num;

        [DataMember]
        public int? Fax_Num;

        [DataMember]
        public string Address;

        public WCF_Supplier(string supplier_ID, string supplier_Name, string contact_Name, int? phone_Num, int? fax_Num, string address)
        {
            this.Supplier_ID = supplier_ID;
            this.Supplier_Name = supplier_Name;
            this.Contact_Name = contact_Name;
            this.Phone_Num = phone_Num;
            this.Fax_Num = fax_Num;
            this.Address = address;
            
        }
    }
}