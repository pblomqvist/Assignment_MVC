using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class CountryController : Controller
    {

        private readonly PersonDbContext _personDbContext;
        public CountryController(PersonDbContext context)
        {
            _personDbContext = context;
        }

        public IActionResult Index()
        {
            return View(_personDbContext.Countries.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _personDbContext.Countries.Add(country);
                _personDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var country = from c in _personDbContext.Countries
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                country = country.Where(s => s.CountryName!.Contains(searchString));
            }

            return View(country.ToList());
        }

        public IActionResult Delete(string CountryName)
        {

            var targetCity = _personDbContext.Countries.FirstOrDefault(c => c.CountryName == CountryName);
            _personDbContext.Countries.Remove(targetCity);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
