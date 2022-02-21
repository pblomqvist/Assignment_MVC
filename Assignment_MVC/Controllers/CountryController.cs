using Assignment_MVC.Models;
using Assignment_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            ICollection<Country> cities = _personDbContext.Countries.Include(c => c.Cities).ToList();
            
            return View(cities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CountryCreateViewModel countryVm)
        {

            if (ModelState.IsValid)
            {
                Country country = new Country();
                country.CountryName = countryVm.CountryName;

                if (_personDbContext.Countries.Any(c => c.CountryName == countryVm.CountryName))
                {
                    ModelState.AddModelError("duplicate_entry", "Cannot add duplicate entries");
                    return View(countryVm);
                }
                else
                {
                    _personDbContext.Countries.Add(country);
                    _personDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index), "Country");
                }

            }

            return View(countryVm);
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

        public IActionResult Details(string CountryName)
        {

            var targetCountry = _personDbContext.Countries.Find(CountryName);

            var cities = _personDbContext.Cities.Where(c => c.CountryName == CountryName).ToList();

            targetCountry.Cities = cities;


            return View(targetCountry);
        }

        public IActionResult Edit()
        {

            return View();
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
