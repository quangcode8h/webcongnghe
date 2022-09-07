using WebCongNghe.Models;
using WebCongNghe.Models.Entities;
namespace WebCongNghe.Models
{
    public class Carts
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        Products products = new Products();
        // thêm sp vào giỏ hàng
        public void addCart(int MaKh, int MaSp, int soluong)
        {
            GioHang cartCheck = (from o in db.GioHangs where o.MaKh == MaKh && o.MaSp == MaSp select o).FirstOrDefault();
            if (cartCheck != null)
            {
                cartCheck.SoLuong = cartCheck.SoLuong + soluong;
            }
            else
            {
                GioHang cart = new GioHang();
                cart.MaKh = MaKh;
                cart.MaSp = MaSp;
                cart.SoLuong = soluong;
                db.GioHangs.Add(cart);
            }
            db.SaveChanges();
        }
        // lấy mã sp trong giỏ hàng
        public List<int?> getCodeOfProductsByCarts(int makh)
        {
            return (from c in db.GioHangs where c.MaKh == makh select c.MaSp).ToList();
        }
        // lấy mã sản phẩm trong giỏ hàng theo makh và masp
        public int? getNumberOfProductInCart(int makh, int? masp)
        {
            return (from c in db.GioHangs where c.MaKh == makh && c.MaSp == masp select c.SoLuong).Sum();
        }
        // lấy tt giỏ hàng theo makh và masp
        public GioHang getCartByCustomerAndProduct(int makh, int masp)
        {
            return (from c in db.GioHangs where c.MaKh == makh && c.MaSp == masp select c).FirstOrDefault();
        }
        // xóa tt sp trong giỏ hàng bằng magh
        public void deleteCart(int magh)
        {
            GioHang cartRemove = (from c in db.GioHangs where c.MaGh == magh select c).FirstOrDefault();
            if (cartRemove != null)
            {
                db.GioHangs.Remove(cartRemove);
                db.SaveChanges();
            }
        }
        // đếm các sp cùng một mã kh
        public int CountNumberOfRecords(int? makh)
        {
            return (from c in db.GioHangs where c.MaKh == makh select c).Count();
        }
    }
}
