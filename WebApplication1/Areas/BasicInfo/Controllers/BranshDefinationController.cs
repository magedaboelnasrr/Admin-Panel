using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.BasicInfo.Controllers
{
    [Area("BasicInfo")]
    public class BranshDefinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
