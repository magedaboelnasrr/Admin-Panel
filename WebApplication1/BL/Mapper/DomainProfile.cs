using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();


        }
    }
}
