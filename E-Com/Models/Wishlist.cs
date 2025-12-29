namespace E_Com.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        //public DateTime createdAt { get; set; }
        public Users user { get; set; }
        public Products product { get; set; }
    }
}
