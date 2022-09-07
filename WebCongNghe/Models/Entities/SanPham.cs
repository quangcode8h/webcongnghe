using System;
using System.Collections.Generic;

#nullable disable

namespace WebCongNghe.Models.Entities
{
    public partial class SanPham
    {
        public SanPham()
        {
            GioHangs = new HashSet<GioHang>();
        }

        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string ChiTiet { get; set; }
        public double? Gia { get; set; }
        public int? SoLuong { get; set; }
        public string Anh1 { get; set; }
        public string Anh2 { get; set; }
        public string Anh3 { get; set; }
        public string Anh4 { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public int? TrangThai { get; set; }
        public int MaDmcon { get; set; }
        public int MaNsx { get; set; }
        public int? KhuyenMai { get; set; }
        public string Mau { get; set; }

        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
