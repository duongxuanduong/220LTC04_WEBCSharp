namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_order_detail
    {
        [Key]
        public int order_detail_id { get; set; }

        public int? order_id { get; set; }

        public int product_id { get; set; }

        [Required]
        [StringLength(255)]
        public string product_name { get; set; }

        [Required]
        [StringLength(255)]
        public string product_image { get; set; }

        public decimal product_price { get; set; }

        public int product_quantity { get; set; }

        public virtual tbl_order tbl_order { get; set; }
    }
}
