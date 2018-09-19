using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD.AddClass
{
    public class Android_Appr
    {

        
        public String Request_id;

        
        public int Quantity;

        
        public String Status;

        
        public String Comments;

        
        public String Description;

       
        public String HOD_ID;

        
        public String Department_ID;

        public Android_Appr(string request_id, int quantity, string status, string comments, string description, string hOD_ID, string department_ID)
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