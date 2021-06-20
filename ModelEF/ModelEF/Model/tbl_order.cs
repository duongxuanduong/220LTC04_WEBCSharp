namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_order()
        {
            tbl_order_detail = new HashSet<tbl_order_detail>();
        }

        [Key]
        public int order_id { get; set; }

        public int? customer_id { get; set; }

        public decimal order_total { get; set; }

        public int order_status { get; set; }

        [Required]
        [StringLength(255)]
        public string order_address { get; set; }

        [Required]
        [StringLength(50)]
        public string order_time { get; set; }

        public virtual tbl_customer tbl_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_order_detail> tbl_order_detail { get; set; }
    }
}
