namespace E_Com.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public DateTime orderDate { get; set; }

        public decimal totalAmount { get; set; }
        public string status { get; set; }
        public string paymentid { get; set; }
        public Users user { get; set; }
    }


    public class OrdersDTOs
    {       
        public int userId { get; set; }
        public decimal totalAmount { get; set; }
        public string status { get; set; }
        public string paymentid { get; set; }
     
    }
}
