namespace E_Com.Models.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
                    public int userId { get; set; }
           
            public decimal totalAmount { get; set; }
            public string status { get; set; }
            public string paymentid { get; set; }
            public Users user { get; set; }
        
    }
}
