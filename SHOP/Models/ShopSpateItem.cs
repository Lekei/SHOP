namespace AspNetApp.Models
{
    public class ShopSpateItem
    {
        public int id { get; set; }
        public Spate spate { get; set; }
        public int price { get; set; }

        public string ShopSpateId { get; set; }
    }
}