namespace apparelshop.Dtos
{
    public class ProductsForUpdateDto
    {
        public string? Name { get; set; }
        //商品顏色
        public string? Color { get; set; }
        // 商品類別
        public string? Category { get; set; }

        // 商品價格
        public decimal? Price { get; set; }

        // 商品庫存數量
        public int? Stock { get; set; }
    }
}
