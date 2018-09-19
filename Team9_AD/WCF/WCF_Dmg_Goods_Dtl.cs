using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team9_AD.WCF
{
    [DataContract]
    public class WCF_Dmg_Goods_Dtl
    {
        [DataMember]
        public int Dmg_ID;

        [DataMember]
        public string Item_number;

        [DataMember]
        public int? Damage_Qnty;

        [DataMember]
        public string Location;

        public WCF_Dmg_Goods_Dtl(int dmg_ID, string item_number, int? damage_Qnty, string location)
        {
            this.Dmg_ID = dmg_ID;
            this.Item_number = item_number;
            this.Damage_Qnty = damage_Qnty;
            this.Location = location;
        }
    }
}