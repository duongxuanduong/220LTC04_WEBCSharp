using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class BrandDao
    {
        private DuongXuanDuongContext db;
        public BrandDao()
        {
            db = new DuongXuanDuongContext();
        }
        public List<tbl_brand> ListAll()
        {
            return db.tbl_brand.Where(x => x.brand_status == 1).ToList();
        }
        public List<tbl_brand> ListWhereAll(string keySearch)
        {
            if (!string.IsNullOrEmpty(keySearch))
                return db.tbl_brand.Where(x => x.brand_name.Contains(keySearch)).ToList();
            return db.tbl_brand.ToList();
        }
        public bool FindName(string brandname)
        {
            return db.tbl_brand.Any(x => x.brand_name == brandname);
        }
        public string Insert(tbl_brand entityBrand)
        {
            //var user = FindId(entityUser.admin_id);
            db.tbl_brand.Add(entityBrand);
            db.SaveChanges();
            return entityBrand.brand_name;
        }
        public tbl_brand FindId(System.Int32 brand_id)
        {
            return db.tbl_brand.Find(brand_id);
        }
        public string Update(tbl_brand entityBrand)
        {
            var brand = FindId(entityBrand.brand_id);
            if (brand != null)
            {
                brand.brand_name =entityBrand.brand_name ;
                brand.brand_des = entityBrand.brand_des;
                brand.brand_status = entityBrand.brand_status;

            }
            db.SaveChanges();
            return entityBrand.brand_name;
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var brand = db.tbl_brand.Find(id);
                db.tbl_brand.Remove(brand);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
