using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCongNghe.Models.Entities;
namespace WebCongNghe.Models
{
    public class Accounts
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản hoặc email")]
        public string account { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string password { get; set; }
    }
}
