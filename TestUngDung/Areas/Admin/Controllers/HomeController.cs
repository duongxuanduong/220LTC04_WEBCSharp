using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;
using ModelEF.DAO;
using ModelEF.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            /* var session = (LoginModel)Session[Constants.USER_SESSION];
             if(session==null)
             {
                 return RedirectToAction("Index", "Login");
             }    */
            if (Session["USER_SESSION"] != null)
            {
                var orders = new OrderDao();
                var order = orders.ListAll();
                var customers = new CustomerDao();
                var customer = customers.ListAll();
                var products = new ProductDao();
                var product = products.ListAll1();
                ViewBag.Order = order;
                ViewBag.Customer = customer;
                ViewBag.Product = product;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login"); 
        }
    }
}