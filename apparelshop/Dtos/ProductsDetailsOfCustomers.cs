using apparelshop.Models;
using System.ComponentModel.DataAnnotations;
//查詢Customers和他 / 她參與的所有Products詳細資料的DTO
namespace apparelshop.Dtos
{
    public class ProductsDetailsOfCustomers
    {
        [Required]
        public int CustomerID { get; set; } // 成員唯一識別碼
        [Required]
        public string Name { get; set; } // 成員名稱
        [Required]
        public string Phone { get; set; } // 成員聯絡電話
        [Required]
        public string Email { get; set; } // 成員電子郵件
        // 此成員購買或關聯的產品清單
        public List<Products> Products { get; set; } = new List<Products>();
    }
}
