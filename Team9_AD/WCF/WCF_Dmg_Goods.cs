using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Dmg_Goods
    {
        [DataMember]
        public int Dmg_ID;

        [DataMember]
        public string Employee_ID;

        [DataMember]
        public DateTime? Dmg_Date;

        public WCF_Dmg_Goods(int dmg_ID, string employee_ID, DateTime? dmg_Date)
        {
            this.Dmg_ID = dmg_ID;
            this.Employee_ID = employee_ID;
            this.Dmg_Date = dmg_Date;
        }
    }
}