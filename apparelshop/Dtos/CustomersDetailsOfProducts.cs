using apparelshop.Models;
using System.ComponentModel.DataAnnotations;
//查詢Products和參與其中的所有Customers詳細資料的DTO
namespace apparelshop.Dtos
{
    public class CustomersDetailsOfProducts
    {
        [Required]
        public int ProductID { get; set; } // 產品唯一識別碼
        [Required]
        public string Name { get; set; } // 產品名稱
        [Required]
        public string Color { get; set; } //產品顏色
        [Required]
        public string Category { get; set; } // 產品類別
        // 此產品的所有客戶清單
        public List<Customers> Customers { get; set; } = new List<Customers>();
    }
}
