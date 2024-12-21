namespace apparelshop.Dtos
{
    public class ProductsForCreationDto
    {
        // 商品名稱
        public string Name { get; set; } = string.Empty;

        //商品顏色
        public string Color { get; set; } = string.Empty;

        // 商品類別
        public string Category { get; set; } = string.Empty;

        // 商品價格
        public decimal Price { get; set; }

        // 商品庫存數量
        public int Stock { get; set; }
    }
}
