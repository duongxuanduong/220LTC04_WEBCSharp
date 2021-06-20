using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            var dao = new UserDao();
            var result = dao.login(user.username, Encryptor.EncryptMD5( user.password));
            
            if(result ==1)
            {
                //ModelState.AddModelError("", "Đăng nhập thành công");
                Session.Add(Constants.USER_SESSION, user.username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
               ModelState.AddModelError("", "Kiểm tra lại tài khoản và mật khẩu");
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            ModelState.AddModelError("", "Đăng xuất thành công");
            return View("Index");
        }
    }
}