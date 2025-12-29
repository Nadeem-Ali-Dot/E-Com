using Microsoft.OpenApi.Writers;

namespace E_Com.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int categoryId { get; set; }
        public int subcategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public bool IsFeatured { get; set; }
        public int ProductStock {  get; set; }
        
        public string Brand { get; set; }
        public decimal Discount { get; set; }
        public int RamId { get; set; }
        public int Weight { get; set; }
        public int Size { get; set; }
        public decimal Ratings { get; set; }
        public  int Location { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public DateTime CreateAt { get; set; }
        public int stock { get; set; }
        public ICollection<Category> category { get; set; }
        public ICollection<SubCategory> subCategory { get; set; }
        public ProductRAM productRAM { get; set; }
        public ProductWeight productWeight { get; set; }
        public ProductSize productSize   { get; set; }

    }
}
