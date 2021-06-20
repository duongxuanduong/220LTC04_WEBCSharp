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
    public class BrandController : BaseController
    {
        // GET: Admin/Brand
        public ActionResult Index(string searchString)
        {
            if (Session["USER_SESSION"] != null)
            {
                var brand = new BrandDao();
                var model = brand.ListWhereAll(searchString);
                ViewBag.searchString = searchString;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult Create(string user)
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

        public ActionResult Create(tbl_brand model)
        {

            if (ModelState.IsValid)
            {
                var brand = new BrandDao();
                if (brand.FindName(model.brand_name))
                {
                    SetAlert("Thương Hiệu Đã Tồn Tại!!!", "warning");
                    return RedirectToAction("Create", "Brand");
                }
                //var user = dao.FindId(model.admin_id);
                string result = brand.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm thương hiệu thành công", "success");
                    return RedirectToAction("Index", "Brand");
                }
                else
                {
                    SetAlert("Thêm thương hiệu thất bại", "error");
                    //return RedirectToAction("Create", "User");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            if (Session["USER_SESSION"] != null)
            {
                var brand = new BrandDao();
                var result = brand.FindId(id);
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

        public ActionResult Edit(tbl_brand model)
        {
            var brand = new BrandDao();
            string result = brand.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật thương hiệu thành công", "success");
                return RedirectToAction("Index", "Brand");
            }
            else
            {
                SetAlert("Cập nhật thương hiệu thất bại", "error");
                //return RedirectToAction("Create", "User");
            }
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var brand = new BrandDao();
            bool middle = brand.Delete(id);
            return Json(middle, JsonRequestBehavior.AllowGet);
        }
    }
}