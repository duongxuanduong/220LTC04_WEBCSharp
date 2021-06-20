using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Model
{
    public partial class DuongXuanDuongContext : DbContext
    {
        public DuongXuanDuongContext()
            : base("name=DuongXuanDuongContext")
        {
        }

        public virtual DbSet<tbl_admin> tbl_admin { get; set; }
        public virtual DbSet<tbl_brand> tbl_brand { get; set; }
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_customer> tbl_customer { get; set; }
        public virtual DbSet<tbl_order> tbl_order { get; set; }
        public virtual DbSet<tbl_order_detail> tbl_order_detail { get; set; }
        public virtual DbSet<tbl_product> tbl_product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_admin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.customer_password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_customer>()
                .Property(e => e.customer_phone)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_order>()
                .Property(e => e.order_total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbl_order>()
                .Property(e => e.order_time)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_order_detail>()
                .Property(e => e.product_price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<tbl_product>()
                .Property(e => e.product_price)
                .HasPrecision(10, 2);
        }
    }
}
