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
    }
}
