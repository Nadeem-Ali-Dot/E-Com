namespace E_Com.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public Products product { get; set; }
        public Orders order { get; set; }
    }
}
