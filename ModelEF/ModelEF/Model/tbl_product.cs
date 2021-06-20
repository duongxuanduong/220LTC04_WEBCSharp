namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_product
    {
        [Key]
        public int product_id { get; set; }

        public int? category_id { get; set; }

        public int? brand_id { get; set; }

        [Required]
        [StringLength(255)]
        public string product_name { get; set; }

        [Required]
        [StringLength(255)]
        public string product_des { get; set; }

        public decimal product_price { get; set; }

        public int product_quantity { get; set; }

        [StringLength(255)]
        public string product_image { get; set; }

        public int product_status { get; set; }

        public virtual tbl_brand tbl_brand { get; set; }

        public virtual tbl_category tbl_category { get; set; }
    }
}
