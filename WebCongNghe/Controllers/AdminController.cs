using Microsoft.AspNetCore.Mvc;
using WebCongNghe.Models;
using WebCongNghe.Models.Entities;
namespace WebCongNghe.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Validate(Admins a)
        {
            if(ModelState.IsValid)
            {
                encryption enscript = new encryption();
                a.password = enscript.perform(a.password);
                Admins Admins = new Admins();
                Admin adminLogin = Admins.getAdminByAccountAndPassword(a.account, a.password);
                if(adminLogin != null)
                {
                    HttpContext.Session.SetInt32("AdminLogin", adminLogin.MaAdmin);
                    return View("Administration");
                }
                ViewBag.LoginError = "true";
                return View("Index");
            }
            return View("Index");
        }

        public IActionResult Administration()
        {
            
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("AdminLogin");
            return View("Index");
        }
    }
}
