namespace apparelshop.Models
{
    public class Orders
    {
        public int OrderID { get; set; } // 訂單ID (主鍵，自動產生)

        public int CustomerID { get; set; } // 客戶ID (外鍵)
        public int ProductID { get; set; } // 商品ID (外鍵)
        public DateTime OrderDate { get; set; } // 訂單成立日期

        public int Quantity { get; set; } // 訂購數量

    }
}
