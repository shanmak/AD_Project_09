using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Approver
    {
        [DataMember]
        public int ID;

        [DataMember]
        public string Department_ID;

        [DataMember]
        public string Employee_ID;

        [DataMember]
        public DateTime? Start_Date;

        [DataMember]
        public DateTime? End_Date;

        [DataMember]
        public string Status;

        public WCF_Approver(int iD, string department_ID, string employee_ID, DateTime? start_Date, DateTime? end_Date, string status)
        {
            this.ID = iD;
            this.Department_ID = department_ID;
            this.Employee_ID = employee_ID;
            this.Start_Date = start_Date;
            this.End_Date = end_Date;
            this.Status = status;
        }
    }
}