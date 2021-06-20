using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
       private DuongXuanDuongContext db;
       public UserDao()
       {
            db = new DuongXuanDuongContext();
       }
       public int login(string username, string password)
       {
            var result = db.tbl_admin.SingleOrDefault(x => x.username.Contains(username) && x.password.Contains(password));
            if(result==null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public List<tbl_admin> ListAll()
        {
            return db.tbl_admin.ToList();
        }
        

        public bool Find(string username)
        {
            return db.tbl_admin.Any(x => x.username == username);     
        }
        public tbl_admin FindId(System.Int32 admin_id)
        {
            return db.tbl_admin.Find(admin_id);
        }
        public string Insert(tbl_admin entityUser)
        {
            //var user = FindId(entityUser.admin_id);
            db.tbl_admin.Add(entityUser);
            db.SaveChanges();
            return entityUser.username;
        }
        public string Update(tbl_admin entityUser)
        {
            var user = FindId(entityUser.admin_id);
            if(user!=null)
            {
                user.username = entityUser.username;
                if (!string.IsNullOrEmpty(entityUser.password))
                {
                    user.password = entityUser.password;
                }
            }
            db.SaveChanges();
            return entityUser.username;
        }   
        public bool Delete(System.Int32 admin_id)
        {
            try
            {
                var user = db.tbl_admin.Find(admin_id);
                db.tbl_admin.Remove(user);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public List<tbl_admin> ListWhereAll(string keySearch)
        {
            if(!string.IsNullOrEmpty(keySearch))
            return db.tbl_admin.Where(x=>x.username.Contains(keySearch)).ToList();
            return db.tbl_admin.ToList();
        }
    }
}
