using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    
    public class DoctorController : Controller
    {
        
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(int temperature)
        {
            Fever fever = new Fever();

            fever.Temperature = temperature;

            if (ModelState.IsValid)
            {
                ViewBag.Message = Fever.Check(temperature);
            }

            return View();
        }
    }
}
