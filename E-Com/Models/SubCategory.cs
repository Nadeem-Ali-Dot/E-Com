namespace E_Com.Models
{
    public class SubCategory
    {
        public int id { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryName {get;set;}
        public ICollection<Category> Category { get; set; }

    }
}
