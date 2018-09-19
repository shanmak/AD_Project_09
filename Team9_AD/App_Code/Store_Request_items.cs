namespace Team9_AD.App_Code
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_Request_items
    {
        [Key]
        [Column(Order = 0)]
       
        public int StoreRequest_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Item_Number { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Req_Quantity { get; set; }

        public int? Delv_Quantity { get; set; }

        public int? Pend_Quantity { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual Store_Request Store_Request { get; set; }
    }
}
