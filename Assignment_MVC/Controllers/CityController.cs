using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class CityController : Controller
    {
        private readonly PersonDbContext _personDbContext;
        public CityController(PersonDbContext context)
        {
            _personDbContext = context;
        }

        public IActionResult Index()
        {
            return View(_personDbContext.Cities.ToList());
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var city = from c in _personDbContext.Cities
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                city = city.Where(s => s.CityName!.Contains(searchString));
            }

            return View(city.ToList());
        }

        public IActionResult Create()
        {
            ViewData["CountryName"] = new SelectList(_personDbContext.Countries, "CountryName", "CountryName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _personDbContext.Cities.Add(city);
                _personDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string CityName)
        {

            var targetCity = _personDbContext.Cities.FirstOrDefault(c => c.CityName == CityName);
            _personDbContext.Cities.Remove(targetCity);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
