namespace E_Com.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public DateTime createdAt { get; set; }
        public string productId { get; set; }
        public int quantity { get; set; }
        public Users user { get; set; }
        public Products product { get; set; }

    }
}
