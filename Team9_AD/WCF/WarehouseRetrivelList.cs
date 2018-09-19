using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WarehouseRetrivelList
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

        public WarehouseRetrivelList(string Item_Number, string Category, string Description, string Bin_number, int Req_Qunty, int Available)
        {
            this.Item_Number = Item_Number;
            this.Category = Category;
            this.Description = Description;
            this.Bin_number = Bin_number;
            this.Req_Qunty = Req_Qunty;
            this.Available = Available;
        }

    }
}