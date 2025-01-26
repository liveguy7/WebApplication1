using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage="Name Cannot Exceed 50 Characters")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[a-z]+@[a-z]+\.[a-z]+$", ErrorMessage="Invalid Email")]

        [Display(Name ="Office Email")]
        public string email { get; set; }

        [Required]
        public Dept? department { get; set; }
        public string? PhotoPath { get; set; }

    }
}



