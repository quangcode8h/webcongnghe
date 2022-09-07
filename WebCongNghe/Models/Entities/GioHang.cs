using System;
using System.Collections.Generic;

#nullable disable

namespace WebCongNghe.Models.Entities
{
    public partial class GioHang
    {
        public int MaGh { get; set; }
        public int? MaKh { get; set; }
        public int? MaSp { get; set; }
        public int? SoLuong { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
