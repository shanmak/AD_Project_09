using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Employee
    {
        [DataMember]
        public string Employee_ID;

        [DataMember]
        public string Employee_Name;

        [DataMember]
        public string Department_ID;

        [DataMember]
        public string Employee_Role;

        [DataMember]
        public string Password;

        [DataMember]
        public string Email;

        public WCF_Employee(string employee_ID, string employee_Name, string department_ID, string employee_Role, string password, string email)
        {
            this.Employee_ID = employee_ID;
            this.Employee_Name = employee_Name;
            this.Department_ID = department_ID;
            this.Employee_Role = employee_Role;
            this.Password = password;
            this.Email = email;
        }

       
    }
}