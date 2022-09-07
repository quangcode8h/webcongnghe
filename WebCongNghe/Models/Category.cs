using WebCongNghe.Models.Entities;
namespace WebCongNghe.Models
{
    public class Category
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        public List<DanhMuc> getCategory()
        {
            return (from c in db.DanhMucs select c).ToList();
        }

        public List<int> getCategoryOfPhoneAndLaptop()
        {
            var result = new List<int>();
            var listCategory = (from c in db.DanhMucs select c).ToList();
            foreach(var item in listCategory)
            {
                if(item.TenDm.ToLower().Trim() == "laptop" || item.TenDm.ToLower().Trim() == "điện thoại")
                {
                    result.Add(item.MaDm);
                }    
                
            }
            return result;
        }

        public DanhMuc getCategoryById(int id)
        {
            return (from c in db.DanhMucs where c.MaDm == id select c).FirstOrDefault();
        }
    }
}
