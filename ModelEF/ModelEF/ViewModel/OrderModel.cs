using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModel
{
    public class OrderModel
    {
        [Required]
        public int order_id { get; set; }
        public string customer_name { get; set; }
        public decimal order_total { get; set; }
        public int order_status { get; set; }
    }
}
