using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_updateWarehouseAndDamage
    {
        [DataMember]
        public string Item_Number { get; set; }

        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Bin_number { get; set; }
        [DataMember]
        public int Req_Qunty { get; set; }
        [DataMember]
        public int Available { get; set; }
        [DataMember]
        public int Collected_qunty { get; set; }
        [DataMember]
        public int Damage_qnty { get; set; }

        public WCF_updateWarehouseAndDamage(string item_Number, string category, string description, string bin_number, int req_Qunty, int available, int collected_qunty, int damage_qnty)
        {
            Item_Number = item_Number;
            Category = category;
            Description = description;
            Bin_number = bin_number;
            Req_Qunty = req_Qunty;
            Available = available;
            Collected_qunty = collected_qunty;
            Damage_qnty = damage_qnty;
        }
    }
}