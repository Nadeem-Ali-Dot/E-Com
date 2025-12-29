namespace E_Com.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
        public DateTime paymentDate { get; set; }
        public Orders order { get; set; }
        public string transactionId { get; set; }
}
}
