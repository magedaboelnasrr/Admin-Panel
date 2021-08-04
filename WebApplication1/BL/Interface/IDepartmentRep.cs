using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
   public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetbyId(int id);
        void add(DepartmentVM dpt);
        void Edit(DepartmentVM dpt);
        void Delete(int id);

    }
}
