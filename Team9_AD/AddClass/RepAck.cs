using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD.AddClass
{
    public class RepAck
    {

     
        public string Category;
    
        public string Discription;
    
        public int? RequestQuantity;
      
        public int? DeliveredQuantity;

        public RepAck(string category, string discription, int? requestQuantity, int? deliveredQuantity)
        {
            Category = category;
            Discription = discription;
            RequestQuantity = requestQuantity;
            DeliveredQuantity = deliveredQuantity;
        }
    }
}