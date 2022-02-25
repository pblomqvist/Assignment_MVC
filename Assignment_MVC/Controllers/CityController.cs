using Assignment_MVC.Models;
using Assignment_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    [Authorize(Roles ="Admin")]
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
            ViewData["Countries"] = new SelectList(_personDbContext.Countries, "CountryId", "CountryName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CityCreateViewModel cityVm)
        {
            ViewData["Countries"] = new SelectList(_personDbContext.Countries, "CountryId", "CountryName");

            if (ModelState.IsValid)
            {
                City city = new City();
                city.CityName = cityVm.CityName;
                city.CountryId = cityVm.CountryId;

                if (_personDbContext.Cities.Any(c => c.CityName == cityVm.CityName))
                {
                    ModelState.AddModelError("duplicate_entry", "Cannot add duplicate entries");
                    return View(cityVm);
                }
                else
                {
                    _personDbContext.Cities.Add(city);
                    _personDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index), "City");
                }

            }

            return View(cityVm);
        }

        public IActionResult Edit(int CityId)
        {
            ViewData["Countries"] = new SelectList(_personDbContext.Countries, "CountryId", "CountryName");
            var targetCity = _personDbContext.Cities.Find(CityId);

            return View(targetCity);
        }

        [HttpPost]
        public IActionResult Edit(int CityId, CityCreateViewModel viewModel)
        {
            ViewData["Countries"] = new SelectList(_personDbContext.Countries, "CountryId", "CountryName");
            City city = _personDbContext.Cities.Where(c => c.CityId == CityId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                city.CityName = viewModel.CityName;
                city.CountryId = viewModel.CountryId;

                _personDbContext.Cities.Update(city);
                _personDbContext.SaveChanges();

                if (city != null)
                {
                    return RedirectToAction(nameof(Index), "City");
                }

                ModelState.AddModelError("Storage", "Failed to save");

            }

            return View(viewModel);

        }

        public IActionResult Delete(int CityId)
        {

            var targetCity = _personDbContext.Cities.FirstOrDefault(c => c.CityId == CityId);
            _personDbContext.Cities.Remove(targetCity);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
