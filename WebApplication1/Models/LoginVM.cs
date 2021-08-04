using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="You Must Enter Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="Min Is 3")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
