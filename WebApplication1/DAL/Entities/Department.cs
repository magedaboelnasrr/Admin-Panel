using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string DepartmentCode { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
