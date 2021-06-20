using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private DuongXuanDuongContext db;
        public CategoryDao()
        {
            db = new DuongXuanDuongContext();
        }
        public List<tbl_category> ListAll()
        {
            return db.tbl_category.Where(x => x.category_status == 1).ToList();
        }
        public List<tbl_category> ListWhereAll(string keySearch)
        {
            if (!string.IsNullOrEmpty(keySearch))
                return db.tbl_category.Where(x => x.category_name.Contains(keySearch)).ToList();
            return db.tbl_category.ToList();
        }
        public bool FindName(string categoryname)
        {
            return db.tbl_category.Any(x => x.category_name == categoryname);
        }
        public string Insert(tbl_category entityCategory)
        {
            //var user = FindId(entityUser.admin_id);
            db.tbl_category.Add(entityCategory);
            db.SaveChanges();
            return entityCategory.category_name;
        }
        public tbl_category FindId(System.Int32 category_id)
        {
            return db.tbl_category.Find(category_id);
        }
        public string Update(tbl_category entityCategory)
        {
            var category = FindId(entityCategory.category_id);
            if (category != null)
            {
                category.category_name = entityCategory.category_name;
                category.category_des = entityCategory.category_des;
                category.category_status = entityCategory.category_status;
            }
            db.SaveChanges();
            return entityCategory.category_name;
        }
        public bool Delete(System.Int32 category_id)
        {
            try
            {
                var category = db.tbl_category.Find(category_id);
                db.tbl_category.Remove(category);
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
