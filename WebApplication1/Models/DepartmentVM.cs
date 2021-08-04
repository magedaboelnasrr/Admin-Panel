using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="enter the Department Name")]
        [MinLength(3,ErrorMessage ="Min Length is 3 character")]
        [StringLength(20,ErrorMessage ="max length is 20 char")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage ="enter the department code")]
        public string DepartmentCode { get; set; }

    }
}
