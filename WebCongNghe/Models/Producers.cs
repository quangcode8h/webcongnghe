using WebCongNghe.Models.Entities;
namespace WebCongNghe.Models
{
    public class Producers
    {
        ShopCongNgheContext db = new ShopCongNgheContext();
        public List<Nsx> getListProducer()
        {
            return (from p in db.Nsxes select p).ToList();
        }

    }
}
