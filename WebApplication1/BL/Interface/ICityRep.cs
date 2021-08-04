using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface ICityRep
    {
        IQueryable<CityVM> Get();
        CityVM GetById(int id);
    }
}
