using System.ComponentModel.DataAnnotations;

namespace E_Com.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Size Name is required")]
        public string Name { get; set; }
    }
}
