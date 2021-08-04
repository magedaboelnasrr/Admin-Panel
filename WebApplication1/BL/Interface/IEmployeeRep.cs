using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetbyId(int id);
        void add(EmployeeVM emp);
        void Edit(EmployeeVM emp);
        void Delete(int id);
    }
}
