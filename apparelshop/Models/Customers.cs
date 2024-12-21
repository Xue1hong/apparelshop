namespace apparelshop.Models
{
    public class Customers
    {

        public int CustomerID { get; set; } // 客戶ID (主鍵，自動產生)
        public string Name { get; set; } = string.Empty; // 客戶名稱
        public string Phone { get; set; } = string.Empty; // 電話
        public string Email { get; set; } = string.Empty; // 電子郵件
    }
}
