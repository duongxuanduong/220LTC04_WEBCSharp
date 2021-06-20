using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelEF.ViewModel
{
    public class ProductModel
    {
        [Required]
        public int product_id { get; set; }
        public int brand_id { get; set; }
        public int category_id { get; set; }
        public string brand_name { get; set; }
        public string category_name { get; set; }
        public string product_name { get; set; }
        public string product_des { get; set; }
        public decimal product_price { get; set; }
        public string product_image { get; set; }
        public int product_status { get; set; }
        public int product_quantity { get; set; }

    }
}