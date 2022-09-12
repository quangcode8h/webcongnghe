using WebCongNghe.Models.Entities;
using System.ComponentModel.DataAnnotations;
namespace WebCongNghe.Models
{
    public class Products
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        // lấy top 10 sp
        public List<SanPham> getOutstandingProducts()
        {
            return (from p in db.SanPhams select p).Take(10).ToList();
        }
        // lấy tên hãng sp
        public String getNameProducer(int maNSX)
        {
            return (from n in db.Nsxes where n.MaNsx == maNSX select n.TenNsx).FirstOrDefault();
        }
        // lấy sản phẩm khuyến mãi > 20 %
        public List<SanPham> getPromotionProducts()
        {
            return (from p in db.SanPhams where p.KhuyenMai >= 20 select p).Take(20).ToList();
        }
        // lấy sp phổ biến
        public List<SanPham> getPopularityProducts(List<int> list)
        {
            var result = new List<SanPham>();
            var listProducts = (from p in db.SanPhams select p).Take(20).ToList();
            foreach(var s in list)
            {
                foreach(var p in listProducts)
                {
                    if(p.MaDmcon == s)
                    {
                        result.Add(p);
                    }
                }
            }
            return result;
        }
        // lấy sp mới
        public List<SanPham> getNewProducts()
        {
            return (from p in db.SanPhams orderby p.MaSp descending select p).Take(10).ToList();
        }
        // lấy sp theo mã danh mục con
        public List<SanPham> getProductsByCategory(int MaDmCon)
        {
            return (from p in db.SanPhams where p.MaDmcon == MaDmCon select p).ToList();
        }
        // lấy sp theo mã sp
        public SanPham getProductById(int? id)
        {
            return (from p in db.SanPhams where p.MaSp == id select p).FirstOrDefault();
        }
        // lấy all sp
        public List<SanPham> getAllProducts()
        {
            return (from p in db.SanPhams select p).ToList();
        }
        // lấy màu sp theo tên 
        public List<string> getColorsByNameProducts(string name)
        {
            return (from p in db.SanPhams where p.TenSp == name select p.Mau).Distinct().ToList();
        }
        // lấy sp theo tên và màu
        public SanPham getProductByNameAndColor(string name, string color)
        {
            return (from p in db.SanPhams where p.TenSp == name && p.Mau == color select p).FirstOrDefault();
        }
        // cập nhật lại số lg sp theo masp và slmua
        public void updateNumberOfProduct(int? masp, int? slmua)
        {
            SanPham product = getProductById(masp);
            if(product != null)
            {
                product.SoLuong = (int)(product.SoLuong - slmua);
            }
            db.SaveChanges();
        }
        // lấy tổng sp cùng tên
        public int? getNumberOfProductsOfTheSameName(string name)
        {
            return (from p in db.SanPhams where p.TenSp == name select p.SoLuong).Sum();
        }

        // sửa 1 sản phẩm
        public void editProduct(SanPham p)
        {
            SanPham productEdit = getProductById(p.MaSp);
            if(productEdit != null)
            {
                productEdit.TenSp = p.TenSp;
                productEdit.Mau = p.Mau;
                productEdit.SoLuong = p.SoLuong;
                productEdit.ChiTiet = p.ChiTiet;
                productEdit.Gia = p.Gia;
                productEdit.Anh1 = p.Anh1;
                productEdit.Anh2 = p.Anh2;
                productEdit.Anh3 = p.Anh3;
                productEdit.Anh4 = p.Anh4;
                productEdit.NgayCapNhat = p.NgayCapNhat;
                productEdit.TrangThai = p.TrangThai;
                productEdit.MaDmcon = p.MaDmcon;
                productEdit.MaNsx = p.MaNsx;
                productEdit.KhuyenMai = p.KhuyenMai;
                db.SaveChanges();
            }
        }
    }
}
