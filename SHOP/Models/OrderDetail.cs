namespace AspNetApp.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int SpateID { get; set; }
        public uint price { get; set; }
        public virtual Spate spate { get; set; }
        public virtual Order order { get; set; }
    }
}