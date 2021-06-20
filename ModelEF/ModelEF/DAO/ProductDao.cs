using ModelEF.Model;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelEF.DAO
{
    public class ProductDao
    {
        private DuongXuanDuongContext db;
        public ProductDao()
        {
            db = new DuongXuanDuongContext();
        }
        public List<ProductModel> ListAll()
        {
            var list_product = from s in db.tbl_product
                               join d in db.tbl_brand
                               on s.brand_id equals d.brand_id
                               join c in db.tbl_category
                               on s.category_id equals c.category_id
                               orderby s.product_quantity descending
                               orderby s.product_price ascending
                               select new ProductModel //Tra ve 1 custom class
                               {
                                   product_id=s.product_id,
                                   brand_name = d.brand_name,
                                   category_name=c.category_name,
                                   product_name = s.product_name,
                                   product_des = s.product_des,
                                   product_price = s.product_price,
                                   product_image = s.product_image,
                                   product_status = s.product_status,
                                   product_quantity = s.product_quantity
                               };
            return list_product.ToList();
        }
        public List<tbl_product> ListAll1()
        {
            return db.tbl_product.ToList();
        }
        public List<tbl_product> ListWhereAll(string keySearch)
        {
            var list_product = from s in db.tbl_product
                               join d in db.tbl_brand
                               on s.brand_id equals d.brand_id
                               join c in db.tbl_category
                               on s.category_id equals c.category_id
                               select new ProductModel //Tra ve 1 custom class
                               {
                                   product_id = s.product_id,
                                   brand_name = d.brand_name,
                                   category_name = c.category_name,
                                   product_name = s.product_name,
                                   product_des = s.product_des,
                                   product_price = s.product_price,
                                   product_image = s.product_image,
                                   product_status = s.product_status,
                                    product_quantity = s.product_quantity
                               };
   
            if (!string.IsNullOrEmpty(keySearch))
                return db.tbl_product.Where(x => x.product_name.Contains(keySearch)).ToList();
            return db.tbl_product.ToList();
        }
        public tbl_product FindId(System.Int32 product_id)
        {
            return db.tbl_product.Find(product_id);
        }
        public bool Delete(System.Int32 product_id)
        {
            try
            {
                var product = db.tbl_product.Find(product_id);
                db.tbl_product.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProductModel> ListWhereCategory(int id, int limit)
        {
            var list_product = from s in db.tbl_product
                               join d in db.tbl_brand
                               on s.brand_id equals d.brand_id
                               join c in db.tbl_category
                               on s.category_id equals c.category_id
                               select new ProductModel //Tra ve 1 custom class
                               {
                                   product_id = s.product_id,
                                   brand_name = d.brand_name,
                                   category_name = c.category_name,
                                   brand_id = d.brand_id,
                                   category_id = c.category_id,
                                   product_name = s.product_name,
                                   product_des = s.product_des,
                                   product_price = s.product_price,
                                   product_image = s.product_image,
                                   product_status = s.product_status,
                                   product_quantity = s.product_quantity
                               };
            return list_product.Where(x => x.category_id.ToString().Contains(id.ToString())).Take(limit).ToList();
        }
        public List<ProductModel> ListWhereBrand(int id, int limit)
        {
            var list_product = from s in db.tbl_product
                               join d in db.tbl_brand
                               on s.brand_id equals d.brand_id
                               join c in db.tbl_category
                               on s.category_id equals c.category_id
                               select new ProductModel //Tra ve 1 custom class
                               {
                                   product_id = s.product_id,
                                   brand_name = d.brand_name,
                                   category_name = c.category_name,
                                   brand_id = d.brand_id,
                                   category_id = c.category_id,
                                   product_name = s.product_name,
                                   product_des = s.product_des,
                                   product_price = s.product_price,
                                   product_image = s.product_image,
                                   product_status = s.product_status,
                                   product_quantity = s.product_quantity
                               };
            return list_product.Where(x => x.brand_id.ToString().Contains(id.ToString())).Take(limit).ToList();
        }
        public List<ProductModel> ListLimit(int id)
        {
            var list_product = from s in db.tbl_product
                               join d in db.tbl_brand
                               on s.brand_id equals d.brand_id
                               join c in db.tbl_category
                               on s.category_id equals c.category_id
                               select new ProductModel //Tra ve 1 custom class
                               {
                                   product_id = s.product_id,
                                   brand_name = d.brand_name,
                                   category_name = c.category_name,
                                   brand_id = d.brand_id,
                                   category_id = c.category_id,
                                   product_name = s.product_name,
                                   product_des = s.product_des,
                                   product_price = s.product_price,
                                   product_image = s.product_image,
                                   product_status = s.product_status,
                                   product_quantity = s.product_quantity
                               };
            return list_product.Take(id).ToList();
        }
    }
}
