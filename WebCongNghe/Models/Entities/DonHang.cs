using System;
using System.Collections.Generic;

#nullable disable

namespace WebCongNghe.Models.Entities
{
    public partial class DonHang
    {
        public int MaDh { get; set; }
        public int? MaKh { get; set; }
        public int? MaSp { get; set; }
        public int? TrangThaiThanhToan { get; set; }
        public int? TrangThaiGiaoHang { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
