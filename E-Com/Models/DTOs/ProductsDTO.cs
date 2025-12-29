using Microsoft.OpenApi.Writers;

namespace E_Com.Models
{
    public class ProductsDTO
    {
      
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int categoryId { get; set; }
    
   
        public int stock { get; set; }
      

    }
}
