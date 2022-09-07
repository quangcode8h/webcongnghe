using System;
using System.Collections.Generic;

#nullable disable

namespace WebCongNghe.Models.Entities
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            GioHangs = new HashSet<GioHang>();
        }

        public int MaKh { get; set; }
        public string HoTen { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string AnhDaiDien { get; set; }
        public string DiaChi { get; set; }
        public int? DienThoai { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }

        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
