using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2a.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult One()
        {
            return View("One");
        }

        public IActionResult Two()
        {
            return View("Two");
        }

        public IActionResult Three()
        {
            return View("Three");
        }


    }
}
