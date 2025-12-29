using System.ComponentModel.DataAnnotations;

namespace E_Com.Models
{
    public class ProductRAM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product RAM Name is required")]
        public string Name { get; set; }
    }
}
