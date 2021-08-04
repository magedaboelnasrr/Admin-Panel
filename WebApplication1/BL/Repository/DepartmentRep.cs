using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {


        //private  Dbcontainer db = new Dbcontainer();
        private readonly Dbcontainer db;
        private readonly IMapper mapper;

        public DepartmentRep(Dbcontainer db  , IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }
        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepts();
            return data;
        }


        public void add(DepartmentVM dpt)
        {
            //Mapping

            //Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;



            var data = mapper.Map<Department>(dpt);
            db.Departments.Add(data);
            db.SaveChanges();
        }

        public DepartmentVM GetbyId(int id)
        {
            DepartmentVM data = GetDepartmentByID(id);
            return data;
        }

       
        public void Edit(DepartmentVM dpt)
        {
            //var olddata = db.Departments.Find(dpt.Id);
            //olddata.DepartmentName = dpt.DepartmentName;
            //olddata.DepartmentCode = dpt.DepartmentCode;

            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Departments.Find(id);
            db.Departments.Remove(data);
            db.SaveChanges();
        }



        //Refactor
        private DepartmentVM GetDepartmentByID(int id)
        {
            return db.Departments.Where(a => a.Id == id).Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode }).FirstOrDefault();
        }
        private IQueryable<DepartmentVM> GetAllDepts()
        {
            return db.Departments.Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }

    }
}
