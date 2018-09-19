using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Store_Request
    {
        [DataMember]
        public int StoreRequest_ID;

        [DataMember]
        public string Department_ID;

        [DataMember]
        public string Employee_ID;

        [DataMember]
        public DateTime? Request_Date;

        [DataMember]
        public string Status;

        public WCF_Store_Request(int storeRequest_ID, string department_ID, string employee_ID, DateTime? request_Date,string Status)
        {
            this.StoreRequest_ID = storeRequest_ID;
            this.Department_ID = department_ID;
            this.Employee_ID = employee_ID;
            this.Request_Date = request_Date;
            this.Status = Status;
        }
    }
}