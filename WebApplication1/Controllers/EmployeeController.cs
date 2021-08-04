using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
    public class EmployeeController : Controller
    {
        //Loosly coupled

        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;



        //Tigtly Coupled
        //private readonly DepartmentRep department;

        //DepartmentRep department = new DepartmentRep();
        public EmployeeController(IEmployeeRep employee , IDepartmentRep department , ICountryRep country , ICityRep city , IDistrictRep district)
        {
            this.employee = employee;
            this.department = department;
            this.country = country;
            this.city = city;
            this.district = district;
        }
        public IActionResult Index()
        {
            #region list
            //string[] arr = { "maged", "mohamed", "wael" };
            //ViewBag.data = arr;

            //DepartmentVM dpt1 = new DepartmentVM() { Id = 1, DepartmentName = "HR", DepartmentCode = "A100" };
            //DepartmentVM dpt2 = new DepartmentVM() { Id = 1, DepartmentName = "Managed", DepartmentCode = "A200" };
            //DepartmentVM dpt3 = new DepartmentVM() { Id = 1, DepartmentName = "Support", DepartmentCode = "A300" };


            //List<DepartmentVM> departments = new List<DepartmentVM>();

            //departments.Add(dpt1);
            //departments.Add(dpt2);
            //departments.Add(dpt3);

            // var data = departments;
            #endregion

            var data = employee.Get();

            return View(data);
        }

        [HttpGet]
        public IActionResult create()
        {
            var data = department.Get();
            var CountryData = country.Get();
            ViewBag.DeparmentList = new SelectList(data, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(CountryData, "Id", "CountryName");

            return View();
        }
        [HttpPost]
        public IActionResult create(EmployeeVM emp)
        {
            if (ModelState.IsValid)
            {

                #region Upload Photo

                //// Get Directory
                //string PhotoPath = Directory.GetCurrentDirectory() + "/wwwroot/Files/Photos/";
                //// Get File Name
                //string PhotoName = Guid.NewGuid() +  Path.GetFileName( emp.PhotoUrl.FileName);
                //// Merge The Directory with File Name
                //string FinalPath = Path.Combine(PhotoPath, PhotoName);

                //using ( var stream = new FileStream(FinalPath,FileMode.Create))
                //{
                //    emp.PhotoUrl.CopyTo(stream);
                //}
                #endregion

                #region Upload CV

                //string CvPath = Directory.GetCurrentDirectory() + "/wwwroot/Files/Docs/";
                //string CvName = Guid.NewGuid() + Path.GetFileName(emp.CvUrl.FileName);
                //string CvFinalPath = Path.Combine(CvPath, CvName);
                //using(var stream = new FileStream(CvFinalPath , FileMode.Create))
                //{
                //    emp.CvUrl.CopyTo(stream);
                //}
                #endregion




                employee.add(emp);

                return RedirectToAction("Index" , "Employee");
            }
            else
            {
                var data = department.Get();
                ViewBag.DeparmentList = new SelectList(data, "Id", "DepartmentName");
                return View(emp);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = employee.GetbyId(id);
            var Deptdata = department.Get();
            ViewBag.DeparmentList = new SelectList(Deptdata, "Id", "DepartmentName" ,data.DepartmentId);

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            if (ModelState.IsValid)
            {
                employee.Edit(emp);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                var data = department.Get();
                ViewBag.DeparmentList = new SelectList(data, "Id", "DepartmentName", emp.DepartmentId);

                return View(emp);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = employee.GetbyId(id);
            var Deptdata = department.Get();
            ViewBag.DeparmentList = new SelectList(Deptdata, "Id", "DepartmentName" , data.DepartmentId);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            employee.Delete(id);

            return RedirectToAction("Index", "Employee");
        }



        //-------------------------------- Ajax Call----------------------------------------//


        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CountryID)
        {
            var data = city.Get().Where(a => a.CountryId == CountryID);
            return Json(data);
        }
        [HttpPost]
        public JsonResult GetDisrtictDataByCityId (int CityID)
        {
            var data = district.Get().Where(a => a.CityId == CityID);
            return Json(data);
        }
    }
}
