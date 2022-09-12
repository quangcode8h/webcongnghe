using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string TenSp { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chi tiết sản phẩm")]
        public string ChiTiet { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(0, 100000000, ErrorMessage = "Giá sản phẩm từ 0 đến 100,000,000 vnđ")]
        public double? Gia { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Range(0, 1000, ErrorMessage = "Số lượng sản phẩm giới hạn từ 0 đến 1000")]
        public int? SoLuong { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập link ảnh 1")]
        public string Anh1 { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập link ảnh 2")]
        public string Anh2 { get; set; }

        public string Anh3 { get; set; }

        public string Anh4 { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày cập nhật")]
        public DateTime? NgayCapNhat { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập trạng thái")]
        public int? TrangThai { get; set; }

        public int MaDmcon { get; set; }

        public int MaNsx { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập khuyến mãi")]
        [Range(0, 100, ErrorMessage = "% khuyến mại từ 0 đến 100")]
        public int? KhuyenMai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập màu")]
        public string Mau { get; set; }

        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
