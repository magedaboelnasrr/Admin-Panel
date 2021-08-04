using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public float Salary { get; set; }

        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }

        public string Notes { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}
