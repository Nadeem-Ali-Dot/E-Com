using System.ComponentModel.DataAnnotations;

namespace E_Com.Models
{
    public class CategoryDTO
    {
        [Required (ErrorMessage = "Category Name Is Required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category Name Is Required")]
        public string Color { get; set; }
        public IFormFile Image { get; set; }

    }

    public class CategoryUpdateDTO
    {
        [Required(ErrorMessage = "Id Is Required")]
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "Name Is Required")]
        public string name { get; set; }

    }
}
