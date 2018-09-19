using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.HodClass
{
    [DataContract]
    public class EmplyReqDetails
    {
        [DataMember]
        string Category { get; set; }
        [DataMember]
        string Description { get; set; }
        [DataMember]
        int? Quantity { get; set; }

        [DataMember]
        string Comments { get; set; }
        [DataMember]
        string Status { get; set; }

        public EmplyReqDetails(string category, string description, int? quantity, string comments, string status)
        {
            Category = category;
            Description = description;
            Quantity = quantity;
            Comments = comments;
            Status = status;
        }
    }
}