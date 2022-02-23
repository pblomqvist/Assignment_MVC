using Assignment_MVC.Models;
using Assignment_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {

        private readonly PersonDbContext _personDbContext;
        public PeopleController(PersonDbContext context)
        {
            _personDbContext = context;
        }

        public IActionResult Index()
        {

            ICollection<Person> people = _personDbContext.People.Include(c => c.PersonLanguages).ToList();

            return View(people);
        }

        public IActionResult Create()
        {
            ViewData["CityName"] = new SelectList(_personDbContext.Cities, "CityName", "CityName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonDBCreateViewModel personCrVm)
        {

            ViewData["CityName"] = new SelectList(_personDbContext.Cities, "CityName", "CityName");

            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.Name = personCrVm.Name;
                person.PhoneNumber = personCrVm.PhoneNumber;
                person.CityName = personCrVm.CityName;

                _personDbContext.People.Add(person);
                _personDbContext.SaveChanges();

                if (person != null)
                {
                    return RedirectToAction(nameof(Index), "People");
                }

                ModelState.AddModelError("Storage", "Failed to save");

            }

            return View(personCrVm);
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var person = from p in _personDbContext.People
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                person = person.Where(s => s.Name!.Contains(searchString));
            }

            return View(person.ToList());
        }

        public IActionResult Details(int id)
        {

            var targetPerson = _personDbContext.People.Find(id);

            var languages = _personDbContext.PersonLanguages.Where(pl => pl.PersonId == id).ToList();

            targetPerson.PersonLanguages = languages;


            return View(targetPerson);
        }

        public IActionResult Edit()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            
            var targetPerson = _personDbContext.People.Find(id);
            _personDbContext.People.Remove(targetPerson);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
