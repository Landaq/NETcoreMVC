namespace FluentAPIDemo.Models
{
    public class Product
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int StockCount { get; set; }

        public string? Name { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
