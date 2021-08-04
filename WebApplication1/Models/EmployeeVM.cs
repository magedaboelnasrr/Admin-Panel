using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        [MaxLength(50 , ErrorMessage ="Max Length is 50 character")]
        [MinLength(3,ErrorMessage ="Mini Length is 3 character")]
        public string Name { get; set; }
        [Required (ErrorMessage ="Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Salery")]
        [Range(3000 , 10000 ,ErrorMessage ="Enter Salery from 3K to 10K")]
        public float Salary { get; set; }
        [Required(ErrorMessage ="Enter Address")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage ="Enter Like 12-StreetName-CityName-CountryName")]
        public string Address { get; set; }
        [Required]
        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }
        [Required]
        public string Notes { get; set; }
        public string DepartmentId { get; set; }
        public string DistrictId { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public string PhotoName { get; set; }
        public IFormFile CvUrl { get; set; }
        public string CvName { get; set; }
    }
}
