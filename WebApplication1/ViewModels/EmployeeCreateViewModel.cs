using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot Exceed 50 Characters")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[a-z]+@[a-z]+\.[a-z]+$", ErrorMessage = "Invalid Email")]

        [Display(Name = "Office Email")]
        public string email { get; set; }

        [Required]
        public Dept? department { get; set; }
        public IFormFile photo { get; set; }

    }
}


