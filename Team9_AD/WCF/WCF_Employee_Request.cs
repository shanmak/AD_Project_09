using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Employee_Request
    {
        [DataMember]
        public int Request_ID;

        [DataMember]
        public string Department_ID;

        [DataMember]
        public string Employee_ID;

        [DataMember]
        public DateTime? Date_of_Request;

        [DataMember]
        public string Status;

        [DataMember]
        public string Employee_Name;

        public WCF_Employee_Request(int request_ID, string department_ID, string employee_ID, DateTime? date_of_Request, string status, string employeeName)
        {
            Request_ID = request_ID;
            Department_ID = department_ID;
            Employee_ID = employee_ID;
            Date_of_Request = date_of_Request;
            Status = status;
            Employee_Name = employeeName;
        }
    }
}