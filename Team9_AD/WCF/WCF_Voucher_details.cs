using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Voucher_details
    {
        [DataMember]
        public int ID;

        [DataMember]
        public string Employee_ID;

        [DataMember]
        public string Approve_ID;

        [DataMember]
        public int? Damage_ID;

        [DataMember]
        public DateTime? Voucher_Date;

        [DataMember]
        public int? Amount;

        public WCF_Voucher_details(int iD, string employee_ID, string approve_ID, int? damage_ID, DateTime? voucher_Date, int? amount)
        {
            this.ID = iD;
            this.Employee_ID = employee_ID;
            this.Approve_ID = approve_ID;
            this.Damage_ID = damage_ID;
            this.Voucher_Date = voucher_Date;
            this.Amount = amount;
        }
    }
}