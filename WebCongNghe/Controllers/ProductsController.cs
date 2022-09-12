using Microsoft.AspNetCore.Mvc;
using WebCongNghe.Models;
using WebCongNghe.Models.Entities;
namespace WebCongNghe.Controllers
{
    public class ProductsController : Controller
    {
        static Products products = new Products();
        static SubCategory subcategories = new SubCategory();
        static Category categories = new Category();
        static Producers producers = new Producers();
        static ShopCongNgheContext db = new ShopCongNgheContext();
        List<DanhMucCon> listSubcategory = subcategories.getSubCategory();
        List<Nsx> listProducer = producers.getListProducer();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductsByCategory(int id, string SubCategory, string Category)
        {
            var listProductsByCategory = products.getProductsByCategory(id);
            ViewBag.listProductsByCategory = listProductsByCategory;
            ViewBag.nameCategory = Category;
            ViewBag.nameSubCategory = SubCategory;
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = products.getProductById(id);
            var subCategory = subcategories.getSubCategoryById(product.MaDmcon);
            var listSubCategory = subcategories.getSubCategoriesById(subCategory.MaDm);
            var listProduct = products.getAllProducts();
            List<SanPham> similarProducts = new List<SanPham>();
            // lấy list sp tương tự
            foreach(var sc in listSubCategory)
            {
                foreach(var p in listProduct)
                {
                    if(p.MaDmcon == sc.MaDmcon && p.Gia >= product.Gia)
                    {
                        similarProducts.Add(p);
                    }
                }
                if(similarProducts.Count >= 11)
                {
                    break;
                }
            }
            similarProducts.Remove(product);
            var listMainCategory = categories.getCategoryOfPhoneAndLaptop();
            // Lấy ds mã danh mục con có ma dm truyền vào
            var listCodeOfSubcategory = subcategories.getCodeOfSubCategory(listMainCategory);
            // Lấy ds một số sp ưa chuộng
            var PopularityProducts = products.getPopularityProducts(listCodeOfSubcategory);
            ViewBag.p = product;
            ViewBag.similarProducts = similarProducts;
            ViewBag.PopularityProducts = PopularityProducts;
            // lấy ds màu của sp cùng tên
            ViewBag.listColor = products.getColorsByNameProducts(product.TenSp);
            ViewBag.NumberOfProductOfTheSameName = products.getNumberOfProductsOfTheSameName(product.TenSp);
            return View();
        }

        // code phần admin bảo trì sản phẩm
        public IActionResult MaintaintProducts()
        {
            if(HttpContext.Session.GetInt32("AdminLogin") != null)
            {
                List<SanPham> listProducts = products.getAllProducts();
                return View(listProducts);
            }
            return Redirect("~/Admin/Index");
        }

        // xóa 1 sp 
        public IActionResult Delete(int id)
        {
            SanPham productDelete = products.getProductById(id);
            if(productDelete != null)
            {
                db.SanPhams.Remove(productDelete);
                db.SaveChanges();
            }
            return RedirectToAction("MaintaintProducts");
        }

        // sửa 1 sp
        public IActionResult EditForm(int id)
        {
            if(HttpContext.Session.GetInt32("AdminLogin") != null)
            {
                SanPham productEdit = products.getProductById(id);
                ViewBag.listSubcategory = listSubcategory;
                ViewBag.listProducer = listProducer;
                return View(productEdit);
            }
            return Redirect("~/Admin/Index");
        }
        public IActionResult Edit(SanPham p)
        {
            products.editProduct(p);
            return RedirectToAction("MaintaintProducts");
        }

        // thêm sp mới
        public IActionResult AddForm()
        {
            if(HttpContext.Session.GetInt32("AdminLogin") != null)
            {
                ViewBag.listSubcategory = listSubcategory;
                ViewBag.listProducer = listProducer;
                return View();
            }
            return Redirect("~/Admin/Index");
        }

        public IActionResult Add(SanPham p)
        {
            if(ModelState.IsValid)
            {
                db.SanPhams.Add(p);
                db.SaveChanges();
                return RedirectToAction("MaintaintProducts");
            }
            ViewBag.listSubcategory = listSubcategory;
            ViewBag.listProducer = listProducer;
            return View("AddForm");
        }
    }

    
}
