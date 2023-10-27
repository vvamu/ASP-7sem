using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2a.Controllers
{
    public class StateController : Controller
    {
        public IActionResult S200()
        {
            return Ok(); // Returns a status in the range (200, 299)
        }

        public IActionResult S300()
        {
            return Redirect("https://www.google.com"); // Returns a status in the range (300, 399)
        }

        public IActionResult S500()
        {
            int a = 0;
            int b = 1 / a; // Throws DivideByZeroException and returns a status in the range (500, 599)
            return Ok();
        }
    
}
}
