using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Helper;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {

        //private  Dbcontainer db = new Dbcontainer();
        private readonly Dbcontainer db;
        private readonly IMapper mapper;

        public EmployeeRep(Dbcontainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }
        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllEmps();
            return data;
        }


        public void add(EmployeeVM emp)
        {
            //Mapping

            //Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;

          

            var data = mapper.Map<Employee>(emp);

            data.PhotoName = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");
            data.CvName = UploadFileHelper.SaveFile(emp.CvUrl, "Docs");

            db.Employees.Add(data);
            db.SaveChanges();
        }

        public EmployeeVM GetbyId(int id)
        {
            EmployeeVM data = GetEmployeeByID(id);
            return data;
        }


        public void Edit(EmployeeVM emp)
        {
            //var olddata = db.Departments.Find(dpt.Id);
            //olddata.DepartmentName = dpt.DepartmentName;
            //olddata.DepartmentCode = dpt.DepartmentCode;

            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Employees.Find(id);

            UploadFileHelper.RemoveFile("Photos/", data.PhotoName);
            UploadFileHelper.RemoveFile("Docs/", data.CvName);
            db.Employees.Remove(data);
            db.SaveChanges();
        }



        //Refactor
        private EmployeeVM GetEmployeeByID(int id)
        {
            return db.Employees.Where(a => a.Id == id).Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Address = a.Address, Email = a.Email, HireDate = a.HireDate, IsActive = a.IsActive, Notes = a.Notes, Salary = a.Salary, DepartmentId = a.Department.DepartmentName, DistrictId = a.District.DistrictName, PhotoName = a.PhotoName, CvName = a.CvName }).FirstOrDefault();
        }
        private IQueryable<EmployeeVM> GetAllEmps()
        {
            return db.Employees.Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Address = a.Address, Email = a.Email, HireDate = a.HireDate, IsActive = a.IsActive, Notes = a.Notes, Salary = a.Salary, DepartmentId = a.Department.DepartmentName, DistrictId = a.District.DistrictName, PhotoName = a.PhotoName, CvName = a.CvName });
        }

    }
}
