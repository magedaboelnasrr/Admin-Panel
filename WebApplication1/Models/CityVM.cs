using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    public class CityVM
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
