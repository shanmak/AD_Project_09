using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Wrehse_Trans
    {
        [DataMember]
        public int Trans_ID;

        [DataMember]
        public DateTime? Trans_Date;

        [DataMember]
        public string Employee_ID;

        public WCF_Wrehse_Trans(int trans_ID, DateTime? trans_Date, string employee_ID)
        {
            this.Trans_ID = trans_ID;
            this.Trans_Date = trans_Date;
            this.Employee_ID = employee_ID;
        }
    }
}