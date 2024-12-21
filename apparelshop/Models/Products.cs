namespace apparelshop.Models
{
    public class Products
    {
        public int ProductID { get; set; }  // 商品ID (主鍵，自動產生)
        public string Name { get; set; } = string.Empty;  // 商品名稱
        public string Category { get; set; } = string.Empty; // 類別
        public decimal Price { get; set; }  // 價格
        public int Stock { get; set; }  // 庫存數量

    }
}

