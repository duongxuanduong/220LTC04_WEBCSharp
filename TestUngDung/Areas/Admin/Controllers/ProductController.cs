using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        DuongXuanDuongContext db = new DuongXuanDuongContext();

        public ActionResult Index()
        {
            if (Session["USER_SESSION"] != null)
            {
                var product = new ProductDao();
                var model = product.ListAll();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //public ActionResult Index(string searchString)
        //{
        //    var product = new ProductDao();
        //    var model = product.ListWhereAll(searchString);
        //    ViewBag.searchString = searchString;
        //    return View(model);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["USER_SESSION"] != null)
            {
                var brands = new BrandDao();
                var brand = brands.ListAll();
                var categorys = new CategoryDao();
                var category = categorys.ListAll();
                ViewBag.Category = category;
                ViewBag.Brand = brand;
                setViewBag();

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_product sp, HttpPostedFileBase product_image)
        {

           
                if (product_image != null && product_image.ContentLength > 0)
                {
                    int id = int.Parse(db.tbl_product.ToList().Last().product_id.ToString());

                    string _FileName =Path.GetFileName( product_image.FileName);
                    int index = Path.GetFileName(product_image.FileName).IndexOf('.');
                    _FileName = "sp" + id.ToString() + "." + Path.GetFileName(product_image.FileName).Substring(index + 1);

                    string _path =Path.Combine( Server.MapPath("~/Upload/sanpham/"+ _FileName));
                    product_image.SaveAs(_path);

                    //tbl_product unv = db.tbl_product.FirstOrDefault(x => x.product_id == id);
                    sp.product_image = _FileName;
                    
                    //db.SaveChanges();
                }
                setViewBag();
                if (ModelState.IsValid)
                {
                    db.tbl_product.Add(sp);
                    db.SaveChanges();
                    SetAlert("Thêm Sản Phẩm Thành Công", "success");
                    return RedirectToAction("Index");
                }
            setViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Detail(System.Int32 id)
        {
            //var product = new ProductDao();
            //var result = product.FindId(id);
            if (Session["USER_SESSION"] != null)
            {
                tbl_product result = db.tbl_product.FirstOrDefault(x => x.product_id == id);

                if (result != null)
                {

                    var categorys = new CategoryDao();
                    var category = categorys.ListAll();
                    ViewBag.Category = category;
                    var brands = new BrandDao();
                    var brand = brands.ListAll();
                    ViewBag.Brand = brand;
                    return View(result);
                }
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
            //var product = new ProductDao();
            //var result = product.FindId(id);
            if (Session["USER_SESSION"] != null)
            {
                tbl_product result = db.tbl_product.FirstOrDefault(x => x.product_id == id);

                if (result != null)
                {

                    var categorys = new CategoryDao();
                    var category = categorys.ListAll();
                    ViewBag.Category = category;
                    var brands = new BrandDao();
                    var brand = brands.ListAll();
                    ViewBag.Brand = brand;
                    return View(result);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_product sp, HttpPostedFileBase product_image)
        {
            tbl_product unv = db.tbl_product.FirstOrDefault(x => x.product_id == sp.product_id);

            if(unv!=null)
            {
                unv.brand_id = sp.brand_id;
                unv.category_id = sp.category_id;
                unv.product_name = sp.product_name;
                unv.product_des = sp.product_des;
                unv.product_price = sp.product_price;
                unv.product_status = sp.product_status;
                unv.product_quantity = sp.product_quantity;
                
                if (product_image != null && product_image.ContentLength > 0)
                {
                    int id = sp.product_id;

                    string _FileName = "";
                    int index = Path.GetFileName(product_image.FileName).IndexOf('.');
                    _FileName = "udsp" + id.ToString() + "." + Path.GetFileName(product_image.FileName).Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/sanpham/" + _FileName));
                    product_image.SaveAs(_path);
                    unv.product_image = _FileName;
                }
            }    
            
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                SetAlert("Cập Nhật Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var product = new ProductDao();
            bool middle = product.Delete(id);
            return Json(middle, JsonRequestBehavior.AllowGet);
        }
        public void setViewBag(int? selectedID = null)
        {
            var daoBrand = new BrandDao();
            ViewBag.brand_id = new SelectList(daoBrand.ListAll(), "brand_id", "brand_name", selectedID);
            var daoCate = new CategoryDao();
            ViewBag.category_id = new SelectList(daoCate.ListAll(), "category_id", "category_name", selectedID);
        }
    }
}