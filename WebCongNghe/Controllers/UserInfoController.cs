using Microsoft.AspNetCore.Mvc;
using WebCongNghe.Models.Entities;
using WebCongNghe.Models;
using System.IO;
namespace WebCongNghe.Controllers
{
    public class UserInfoController : Controller
    {
        public IActionResult Index(int id)
        {
            Users users = new Users(); 
            KhachHang u = users.getUserById(id);
            return View(u);
        }

        public IActionResult Validate(KhachHang u, IFormFile uploadImage)
        {
            if (uploadImage != null)
            {
                //chỉ định đường dẫn lưu
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", uploadImage.FileName);
                //copy file vào thư mục chỉ định
                using (FileStream file = new FileStream(fullPath, FileMode.Create))
                {
                    uploadImage.CopyTo(file);
                }
                u.AnhDaiDien = uploadImage.FileName;
            }
            Users user = new Users();
            user.updateUser(u);
            return Redirect("~/UserInfo/Index/" + u.MaKh);
        }
    }
}
