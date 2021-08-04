using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class ResetPasswordVM
    {

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "You Must Enter A Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min is 3")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min is 3")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
