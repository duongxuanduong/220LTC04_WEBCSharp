namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_customer()
        {
            tbl_order = new HashSet<tbl_order>();
        }

        [Key]
        public int customer_id { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_name { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_email { get; set; }

        [Required]
        [StringLength(50)]
        public string customer_password { get; set; }

        [StringLength(255)]
        public string customer_phone { get; set; }

        public int customer_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_order> tbl_order { get; set; }
    }
}
