using Microsoft.AspNetCore.Mvc;
using WebCongNghe.Models.Entities;
using WebCongNghe.Models;
namespace WebCongNghe.Controllers
{
    public class RegisterController : Controller
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        public IActionResult Register()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["ErrorEmail"]))
            {
                ViewBag.ErrorEmail = Request.Cookies["ErrorEmail"];
                // xóa cookies
                CookieOptions co = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Append("ErrorEmail", "Email đã tồn tại", co);
            }
            else if (!string.IsNullOrEmpty(Request.Cookies["ErrorAccount"]))
            {
                ViewBag.ErrorAccount = Request.Cookies["ErrorAccount"];
                // xóa cookies
                CookieOptions co = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Append("ErrorAccount", "Tên tài khoản đã tồn tại", co);
            }
            return View();
        }
        public IActionResult Validate(Users u)
        {
            if (ModelState.IsValid)
            {
                Users users = new Users();
                if (users.getUserByValue(u.email) != null)
                {
                    CookieOptions co = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    };
                    Response.Cookies.Append("ErrorEmail", "Email đã tồn tại", co);
                    return RedirectToAction("Register");
                }
                else if(users.getUserByValue(u.account) != null)
                {
                    CookieOptions co = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    };
                    Response.Cookies.Append("ErrorAccount", "Tên tài khoản đã tồn tại", co);
                    return RedirectToAction("Register");
                }
                else
                {
                    KhachHang user = new KhachHang();
                    user.TaiKhoan = u.account;
                    user.Email = u.email;
                    encryption encrypt = new encryption();
                    user.MatKhau = encrypt.perform(u.password);
                    db.KhachHangs.Add(user);
                    db.SaveChanges();
                    CookieOptions co = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    };
                    Response.Cookies.Append("register", "success", co);//key = register value = success
                    return Redirect("~/Login/Login");
                }
            }
            return View("Register");
        }
    }
}
