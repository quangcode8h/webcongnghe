using Microsoft.AspNetCore.Mvc;
using WebCongNghe.Models;
using WebCongNghe.Models.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace WebCongNghe.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            ViewBag.CookieValue = Request.Cookies["register"];

            // xóa cookies
            CookieOptions co = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Append("register", "success", co);//key = register value = success
            
            return View();
        }
        public IActionResult Validate(Accounts a)
        {
            if (ModelState.IsValid)
            {
                encryption encrypt = new encryption();
                a.password = encrypt.perform(a.password);
                Users users = new Users();
                KhachHang user = users.getUserByAccountAndPassword(a.account, a.password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("login", user.MaKh);
                    return Redirect("~/Home/Index");
                }
                ViewBag.LoginError = "true";
                return View("Login");
            }
            return View("Login");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("login");
            return Redirect("");
        }
    }
}
