using System.ComponentModel.DataAnnotations;
using WebCongNghe.Models.Entities;
namespace WebCongNghe.Models
{
    public class Admins
    {
        ShopCongNgheContext db = new ShopCongNgheContext();

        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string account { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string password { get; set; }

        public Admin getAdminByAccountAndPassword(string account, string password)
        {
            return (from a in db.Admins where a.Tk == account && a.MatKhau == password select a).FirstOrDefault();
        }

        public Admin getAdminById(int? id)
        {
            return (from a in db.Admins where a.MaAdmin == id select a).FirstOrDefault();   
        }
    }
}
