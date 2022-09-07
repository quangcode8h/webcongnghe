using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCongNghe.Models;
using System.Linq;
using WebCongNghe.Models.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace WebCongNghe.Controllers
{
    public class HomeController : Controller
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // khai báo danh class danh mục
            var Categories = new Category();
            // khai báo class danh mục con
            var SubCategories = new SubCategory();
            //khai báo class các sp
            var Products = new Products();
            // lấy danh sách danh mục
            var listCategory = Categories.getCategory();
            // lấy danh sách danh mục con
            var listSubCategory = SubCategories.getSubCategory();
            //lấy danh sách sản phẩm nổi bật
            var outstandingProducts = Products.getOutstandingProducts();
            //lấy danh sách sp khuyến mãi từ 20% trở lên
            var promotionProducts = Products.getPromotionProducts();  
            //lấy mdanh mục của điện thoại và laptop
            var listMainCategory = Categories.getCategoryOfPhoneAndLaptop();
            // Lấy ds mã danh mục con có ma dm truyền vào
            var listCodeOfSubcategory = SubCategories.getCodeOfSubCategory(listMainCategory);
            // Lấy ds một số sp ưa chuộng
            var PopularityProducts = Products.getPopularityProducts(listCodeOfSubcategory);
            // Lấy ds các sp mới 
            var NewProducts = Products.getNewProducts();
            if (!String.IsNullOrEmpty(Request.Cookies["OutOfProduct"]))
            {
                ViewBag.cookiesOutOfProduct = Request.Cookies["OutOfProduct"];
                CookieOptions co = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Append("OutOfProduct", "true", co);
            }
            ViewBag.listCategory = listCategory;
            ViewBag.listSubCategory = listSubCategory;
            ViewBag.outstandingProduct = outstandingProducts;
            ViewBag.promotionProducts = promotionProducts;
            ViewBag.PopularityProducts = PopularityProducts;
            ViewBag.NewProducts = NewProducts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}