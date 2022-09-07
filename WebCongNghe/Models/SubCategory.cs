using WebCongNghe.Models.Entities;
namespace WebCongNghe.Models
{
    public class SubCategory
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        // hàm lấy ds danh mục con
        public List<DanhMucCon> getSubCategory()
        {
            return (from sc in db.DanhMucCons select sc).ToList();
        }
        // hàm lấy nhóm danh mục con theo id
        public List<DanhMucCon> groupSubCategory(int id)
        {
            return (from gsc in db.DanhMucCons where gsc.MaDm == id select gsc).ToList();
        }
        // hàm lấy mã danh mục con theo mã danh mục truyền vào
        public List<int>getCodeOfSubCategory(List<int> list)
        {
            var result = new List<int>();   
            var listSubCategory = (from s in db.DanhMucCons select s).ToList();
            foreach(var c in list)
            {
                foreach(var s in listSubCategory)
                {
                    if(c == s.MaDm)
                    {
                        result.Add(s.MaDmcon);
                    }    
                }
            }
            return result;
        }

        public DanhMucCon getSubCategoryById(int id)
        {
            return (from s in db.DanhMucCons where s.MaDmcon == id select s).FirstOrDefault();
        }

        public List<DanhMucCon> getSubCategoriesById(int MaDm)
        {
            return (from s in db.DanhMucCons where s.MaDm == MaDm select s).ToList();
        }
    }
}
