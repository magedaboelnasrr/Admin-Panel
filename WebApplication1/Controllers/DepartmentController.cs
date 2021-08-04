using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Interface;
using WebApplication1.BL.Repository;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class DepartmentController : Controller
    {

        //Loosly coupled

        private readonly IDepartmentRep department;

        //Tigtly Coupled
        //private readonly DepartmentRep department;

        //DepartmentRep department = new DepartmentRep();
        public DepartmentController(IDepartmentRep department)
        {
            this.department = department;
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

          var data = department.Get();

            return View(data);
        }


        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(DepartmentVM dpt)
        {
            if (ModelState.IsValid)
            {
                department.add(dpt);

                return RedirectToAction("Index");
            }
            else
            {
                return View(dpt);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = department.GetbyId(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
            if (ModelState.IsValid)
            {
                department.Edit(dpt);
                return RedirectToAction("Index", "Department");
            }
            else
            {
                return View(dpt);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = department.GetbyId(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            department.Delete(id);

            return RedirectToAction("Index", "Department");
        }

    }
}
