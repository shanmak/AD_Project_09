using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Department
    {
        [DataMember]
        public string Department_ID;

        [DataMember]
        public string Department_Name;

        [DataMember]
        public string Department_Head;

        [DataMember]
        public int? Phone_Num;

        [DataMember]
        public int? Fax_num;

        [DataMember]
        public string Collection_Point;

        [DataMember]
        public string Representative_ID;

        public WCF_Department(string department_ID, string department_Name, string department_Head, int? phone_Num, int? Faxnumber, string collection_Point, string representative_ID)
        {
            this.Department_ID = department_ID;
            this.Department_Name = department_Name;
            this.Department_Head = department_Head;
            this.Phone_Num = phone_Num;
            this.Collection_Point = collection_Point;
            this.Representative_ID = representative_ID;
            this.Fax_num = Faxnumber;
        }
    }
}