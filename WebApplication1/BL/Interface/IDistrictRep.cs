using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface IDistrictRep
    {
        IQueryable<DiscritVM> Get();
        DiscritVM GetById(int id);
    }
}
