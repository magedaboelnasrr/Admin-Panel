using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //----------------------------Ajax Call-------------------------------

        [HttpPost]
        public JsonResult Display(string name)
        {
            var data = "welcome" + name;
            return Json(data);
        }
    }
}
