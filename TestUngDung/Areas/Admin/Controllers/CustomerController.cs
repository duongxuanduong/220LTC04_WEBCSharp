using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page = 1,int pageSize = 5)
        {
            if (Session["USER_SESSION"]!=null)
            {
                var customer = new CustomerDao();
                var model = customer.ListAllPaging(page,pageSize,searchString);
                //ViewBag.searchString = searchString;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["USER_SESSION"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]

        public ActionResult Create(tbl_customer model)
        {

            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if (dao.Find(model.customer_email))
                {
                    SetAlert("Khách Đã Tồn Tại!!!", "warning");
                    return RedirectToAction("Create", "Customet");
                }
                //var user = dao.FindId(model.admin_id);
                var pass = Encryptor.EncryptMD5(model.customer_password);
                model.customer_password = pass;
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm tài khoản thành công", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    SetAlert("Thêm tài khoản thất bại", "error");
                    //return RedirectToAction("Create", "User");
                }
            }
            return View();
        }


        public JsonResult Delete(System.Int32 id)
        {

            var customers = new CustomerDao();
            var customer = customers.FindId(id);
            if(customer.customer_status == 1)
            {
                bool middle = customers.Delete(id);
                return Json(middle, JsonRequestBehavior.AllowGet);
            }
            else
            {
                bool middle = false;
                return Json(middle, JsonRequestBehavior.AllowGet);
            }
        }
    }
}