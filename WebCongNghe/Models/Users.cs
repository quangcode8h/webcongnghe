using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCongNghe.Models.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebCongNghe.Models
{
    public class Users
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        //[Key, Column(Order = 1)]//id bắt đầu từ 1
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]//tự động tăng
        //public int id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email không đúng định dạng")]
        public string email { get; set; }

        [Required(ErrorMessage = "vui lòng nhập tên tài khoản")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên từ 3 đến 50 ký tự")]
        public string account { get; set; }

        [Required(ErrorMessage = "vui lòng nhập mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Mật khẩu phải gồm chữ cái in hoa, ký tự và số")]
        public string password {get;set;}

        [NotMapped]//dùng biểu thức này, cho các trường thuộc tính không có trong table Users, nếu không có ta sẽ bị báo lỗi, vì mô hình thực thể User.cs sẽ đại diện cho từng cột dữ liệu trong table User
        [Required(ErrorMessage = "vui lòng xác nhận lại mật khẩu")]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "Xác nhận mật khẩu chưa đúng")]
        public string ConfirmPassword { get; set; }

        //thêm 1 user vào bảng khách hàng
        public void addUser(KhachHang u)
        {
            db.KhachHangs.Add(u);
            db.SaveChanges();
        }
        // tìm khách hàng có tên tài khoản hoặc email truyền vào
        public KhachHang getUserByValue(string value)
        {
            return (from u in db.KhachHangs where u.TaiKhoan == value || u.Email == value select u).FirstOrDefault();
        }


        // lấy ds khách hàng
        public List<KhachHang> getListUser()
        {
            return (from u in db.KhachHangs select u).ToList();
        }

        // Lấy khách hàng có tk và mk truyền vào
        public KhachHang getUserByAccountAndPassword(string account, string password)
        {
            return (from u in db.KhachHangs where u.Email == account || u.TaiKhoan == account && u.MatKhau == password select u).FirstOrDefault();
        }

        // Lấy khách hàng by id
        public KhachHang getUserById(int id)
        {
            return (from u in db.KhachHangs where u.MaKh == id select u).FirstOrDefault();
        }

        // chỉnh sửa thông tin khách hàng
        public void updateUser(KhachHang u)
        {
            KhachHang userUpdate = getUserById(u.MaKh);
            if(userUpdate != null)
            {
                userUpdate.HoTen = u.HoTen;
                userUpdate.Email = u.Email;
                userUpdate.AnhDaiDien = u.AnhDaiDien;
                userUpdate.DiaChi = u.DiaChi;
                userUpdate.GioiTinh = u.GioiTinh;
                userUpdate.NgaySinh = u.NgaySinh;
                userUpdate.DienThoai = u.DienThoai;
                db.SaveChanges();
            }
        }
    }
}
