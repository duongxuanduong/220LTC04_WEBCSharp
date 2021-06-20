namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_brand()
        {
            tbl_product = new HashSet<tbl_product>();
        }

        [Key]
        public int brand_id { get; set; }

        [Required]
        [StringLength(255)]
        public string brand_name { get; set; }

        [Required]
        [StringLength(255)]
        public string brand_des { get; set; }

        public int brand_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_product> tbl_product { get; set; }
    }
}
