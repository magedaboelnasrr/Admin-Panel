using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress]
        public String Email { get; set; }
    }
}
