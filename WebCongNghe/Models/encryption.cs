using System.Security.Cryptography; // khai báo thư viện md5
using System.Text;
namespace WebCongNghe.Models
{
    public class encryption
    {
        public string perform(string password)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            return BitConverter.ToString(hash);
        }
    }
}
