using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2a.Controllers
{
    public class ParmController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Uri01(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Uri02(float id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Uro03(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Uri04(DateTime id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
