using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        DuongXuanDuongContext db = new DuongXuanDuongContext();
        public ActionResult Index(string searchString)
        {
            if (Session["USER_SESSION"] != null)
            {
                var order = new OrderDao();
                var model = order.ListWhereAll(searchString);
                ViewBag.searchString = searchString;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            if (Session["USER_SESSION"] != null)
            {
                var order = new OrderDao();
                var result = order.FindId(id);
                
                if(result.order_status == 1)
                {
                    result.order_status = 0;
                }
                else
                {
                    result.order_status = 1;
                }
                string a = order.Update(result);
                if (!string.IsNullOrEmpty(a))
                {
                    SetAlert("Thay đổi thành công", "success");
                    return RedirectToAction("Index", "Order");
                }
                else
                {
                    SetAlert("Thay đổi thất bại", "error");
                    return RedirectToAction("Index", "Order");
                }

                //if (result != null)
                //    return View(result);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult Detail(System.Int32 id)
        {
            if (Session["USER_SESSION"] != null)
            {
                var order = new OrderDao();
                var result = order.FindDetail(id);
                if (result != null)
                    return View(result);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

    }
}