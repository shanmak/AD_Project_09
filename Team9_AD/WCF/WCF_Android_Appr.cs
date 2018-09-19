using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Android_Appr
    {
        [DataMember]
        public String Request_id;

        [DataMember]
        public int Quantity;

        [DataMember]
        public String Status;

        [DataMember]
        public String Comments;

        [DataMember]
        public String Description;

        [DataMember]
        public String HOD_ID;

        [DataMember]
        public String Department_ID;

        public WCF_Android_Appr(string request_id, int quantity, string status, string comments, string description, string hOD_ID, string department_ID)
        {
            Request_id = request_id;
            Quantity = quantity;
            Status = status;
            Comments = comments;
            Description = description;
            HOD_ID = hOD_ID;
            Department_ID = department_ID;
        }
    }
}