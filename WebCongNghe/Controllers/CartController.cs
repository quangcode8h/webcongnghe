using Microsoft.AspNetCore.Mvc;
using WebCongNghe.Models;
using WebCongNghe.Models.Entities;
namespace WebCongNghe.Controllers
{
    public class CartController : Controller
    {
        Products p = new Products();
        Carts c = new Carts();
        public IActionResult Index(int id)
        {
            if(HttpContext.Session.GetInt32("login") == null)
            {
                return Redirect("~/Login/Login");
            }
            List<SanPham> listPInCart = new List<SanPham>();
            List<int?> listCodeOfProduct = c.getCodeOfProductsByCarts(id);
            foreach (var code in listCodeOfProduct)
            {
                SanPham prod = p.getProductById(code);
                prod.SoLuong = (int)c.getNumberOfProductInCart(id, code);
                if (prod != null)
                {
                    listPInCart.Add(prod);
                }
            }
            ViewBag.listPInCart = listPInCart;
            ViewBag.id = id;
            return View();
        }
        
        public IActionResult Validate(string name, int amount, string color)
        {
            if (HttpContext.Session.GetInt32("login") == null)
            {
                return Redirect("~/Login/Login");
            }
            SanPham product = p.getProductByNameAndColor(name, color);
            if(product.SoLuong >= amount)
            {
                int id = (int)HttpContext.Session.GetInt32("login");
                c.addCart(id, product.MaSp, amount);
                p.updateNumberOfProduct(product.MaSp, amount);
                return Redirect("~/Cart/Index/" + @id);
            }
            CookieOptions co = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Append("OutOfProduct", "true", co);
            return Redirect("~/Home/Index");
        }

        public IActionResult deleteProduct(int id, int pr)
        {
            GioHang cartRemove = c.getCartByCustomerAndProduct(id, pr);
            if (cartRemove != null)
            {
                p.updateNumberOfProduct(pr, 0 - cartRemove.SoLuong);
                c.deleteCart(cartRemove.MaGh);
            }
            return Redirect("~/Cart/Index/" + @id);
        }
    }
}
