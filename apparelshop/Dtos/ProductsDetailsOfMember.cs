using apparelshop.Models;
using System.ComponentModel.DataAnnotations;

namespace apparelshop.Dtos
{
    public class ProductsDetailsOfMember
    {
        [Required]
        public int CustomerID { get; set; } // 成員唯一識別碼

        [Required]
        public string Name { get; set; } // 成員名稱

        [Required]
        public string Phone { get; set; } // 成員聯絡電話

        [Required]
        public string Email { get; set; } // 成員聯絡電話

        // 此成員購買或關聯的產品清單
        public List<String> Products { get; set; } = new List<String>();
    }
}
