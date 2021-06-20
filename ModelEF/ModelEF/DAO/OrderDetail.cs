using ModelEF.Model;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class OrderDetailDao
    {
        private DuongXuanDuongContext db;
        public OrderDetailDao()
        {
            db = new DuongXuanDuongContext();
        }
        /* public List<OrderModel> ListAll()
         {
             var list_order = from s in db.tbl_order
                                join d in db.tbl_customer
                                on s.customer_id equals d.customer_id
                                select new OrderModel //Tra ve 1 custom class
                                {
                                    order_id = s.order_id,
                                    customer_name=d.customer_name,
                                    order_total = s.order_total,
                                    order_status = s.order_status
                                };
             return list_order.ToList();
         }*/
        public List<tbl_order> ListAll()
        {
            return db.tbl_order.ToList();
        }
        public List<OrderModel> ListWhereAll(string keySearch)
        {
            var list_where_order = from s in db.tbl_order
                                   join d in db.tbl_customer
                                   on s.customer_id equals d.customer_id
                                   where d.customer_name.Equals(keySearch)
                                   select new OrderModel //Tra ve 1 custom class
                                   {
                                       order_id = s.order_id,
                                       customer_name = d.customer_name,
                                       order_total = s.order_total,
                                       order_status = s.order_status
                                   };
            var list_order = from s in db.tbl_order
                             join d in db.tbl_customer
                             on s.customer_id equals d.customer_id
                             select new OrderModel //Tra ve 1 custom class
                             {
                                 order_id = s.order_id,
                                 customer_name = d.customer_name,
                                 order_total = s.order_total,
                                 order_status = s.order_status
                             };
            if (!string.IsNullOrEmpty(keySearch))
                return list_where_order.ToList();
            return list_order.ToList();
        }
        public tbl_order FindId(System.Int32 order_id)
        {
            return db.tbl_order.Find(order_id);
        }
        public string Update(tbl_order entityOrder)
        {
            var order = FindId(entityOrder.order_id);
            db.SaveChanges();
            return entityOrder.customer_id.ToString();
        }
    }
}
