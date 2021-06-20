using System.Web.Mvc;
using ModelEF.DAO;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var brands = new BrandDao();
            var brand = brands.ListAll();
            var categorys = new CategoryDao();
            var category = categorys.ListAll();
            var products = new ProductDao();
            var product_limit = products.ListLimit(6);
            var product_cate1 = products.ListWhereCategory(3,6);
            var product_cate2 = products.ListWhereCategory(1002,6);
            var product_brand1 = products.ListWhereBrand(1002,3);
            var product_brand2 = products.ListWhereBrand(2002,3);
            var product_brand3 = products.ListWhereBrand(2003,3);
            ViewBag.Brand = brand;
            ViewBag.Category = category;
            ViewBag.ProductLimit = product_limit;
            ViewBag.ProductCate1 = product_cate1;
            ViewBag.ProductCate2 = product_cate2;
            ViewBag.ProductBrand1 = product_brand1;
            ViewBag.ProductBrand2 = product_brand2;
            ViewBag.ProductBrand3 = product_brand3;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}