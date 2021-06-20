using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        /*public ActionResult Index()
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model);
        }*/
        public ActionResult Index(string searchString)
        {
            if (Session["USER_SESSION"] != null)
            {
                var user = new UserDao();
                var model = user.ListWhereAll(searchString);
                ViewBag.searchString = searchString;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        /*[HttpGet]
        public ActionResult Create()
        {
            return View();
        }*/
        [HttpGet]
        public ActionResult Create(string user)
        {
            if (Session["USER_SESSION"] != null)
            {
                var dao = new UserDao();
                //var result = dao.FindId(user);
                //if (result!= null)
                //return View(result);
                return View();
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

                var dao = new UserDao();
                var result = dao.FindId(id);
                if (result != null)
                    return View(result);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]

        public ActionResult Create(tbl_admin model)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.Find(model.username))
                {
                    SetAlert("Tên Đăng Nhập Đã Tồn Tại!!!", "warning");
                    return RedirectToAction("Create", "User");
                }
                //var user = dao.FindId(model.admin_id);
                var pass = Encryptor.EncryptMD5(model.password);
                model.password = pass;
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm tài khoản thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Thêm tài khoản thất bại", "error");
                    //return RedirectToAction("Create", "User");
                }
            }
            return View();
        }
        [HttpPost]

        public ActionResult Edit(tbl_admin model)
        {
            var dao = new UserDao();
            var pass = Encryptor.EncryptMD5(model.password);
            model.password = pass;
            string result = dao.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật tài khoản thành công", "success");
                return RedirectToAction("Index", "User");
            }
            else
            {
                SetAlert("Cập nhật tài khoản thất bại", "error");
                //return RedirectToAction("Create", "User");
            }
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var user = new UserDao();
            bool middle = user.Delete(id);
            return Json(middle, JsonRequestBehavior.AllowGet);
        }
    }
}