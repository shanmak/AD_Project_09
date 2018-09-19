using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Inventory
    {
        [DataMember]
        public string Item_Number;

        [DataMember]
        public string Category;

        [DataMember]
        public string Description;

        [DataMember]
        public int? Reorder_level;

        [DataMember]
        public int? Reorder_qty;

        [DataMember]
        public decimal? Price;

        [DataMember]
        public string Unit_Measure;

        [DataMember]
        public int? Quantity;

        [DataMember]
        public string Bin_number;

        [DataMember]
        public string Suppiler_ID_1;

        [DataMember]
        public string Suppiler_ID_2;

        [DataMember]
        public string Suppiler_ID_3;

        public WCF_Inventory(string item_Number, string category, string description, int? reorder_level, int? reorder_qty, decimal? price, string unit_Measure, int? quantity, string bin_number, string suppiler_ID_1, string suppiler_ID_2, string suppiler_ID_3)
        {
            this.Item_Number = item_Number;
            this.Category = category;
            this.Description = description;
            this.Reorder_level = reorder_level;
            this.Reorder_qty = reorder_qty;
            this.Price = price;
            this.Unit_Measure = unit_Measure;
            this.Quantity = quantity;
            this.Bin_number = bin_number;
            this.Suppiler_ID_1 = suppiler_ID_1;
            this.Suppiler_ID_2 = suppiler_ID_2;
            this.Suppiler_ID_3 = suppiler_ID_3;
        }
    }
}