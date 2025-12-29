using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.DTOs
{
    public class UserDTOs
    {

        [Required(ErrorMessage = "{0} is required.")]
      //  [RegularExpression(@"^[A-Za-z]+{d}+$", ErrorMessage = "Only words allowed")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0}'s length should be between {2} and {1}.")]
       

        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Passowrd { get; set; }
        [Required]
        public string Role { get; set; }
     
    }

    public class UserUpdateDTOs
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Passowrd { get; set; }
        [Required]
        public string Role { get; set; }
    }

}
