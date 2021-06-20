using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        // GET: Admin/Brand
        public ActionResult Index(string searchString)
        {
            if (Session["USER_SESSION"] != null)
            {
                var category = new CategoryDao();
                var model = category.ListWhereAll(searchString);
                ViewBag.searchString = searchString;
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

        public ActionResult Create(tbl_category model)
        {

            if (ModelState.IsValid)
            {
                var category = new CategoryDao();
                if (category.FindName(model.category_name))
                {
                    SetAlert("Danh Mục Đã Tồn Tại!!!", "warning");
                    return RedirectToAction("Create", "Category");
                }
                //var user = dao.FindId(model.admin_id);
                string result = category.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetAlert("Thêm danh mục thất bại", "error");
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
                var category = new CategoryDao();
                var result = category.FindId(id);
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

        public ActionResult Edit(tbl_category model)
        {
            var category = new CategoryDao();
            string result = category.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật danh mục thành công", "success");
                return RedirectToAction("Index", "Category");
            }
            else
            {
                SetAlert("Cập nhật danh mục thất bại", "error");
                //return RedirectToAction("Create", "User");
            }
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var category = new CategoryDao();
            bool middle = category.Delete(id);
            return Json(middle, JsonRequestBehavior.AllowGet);
        }
    }
}