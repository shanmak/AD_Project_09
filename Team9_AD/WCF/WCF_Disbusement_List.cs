using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Disbusement_List
    {
        [DataMember]
        public int Disburse_ID;

        [DataMember]
        public string Department_ID;

        [DataMember]
        public DateTime? Disburse_date;

        [DataMember]
        public string Status;

        public WCF_Disbusement_List(int disburse_ID, string department_ID, DateTime? disburse_date)
        {
            this.Disburse_ID = disburse_ID;
            this.Department_ID = department_ID;
            this.Disburse_date = disburse_date;
        }
    }
}