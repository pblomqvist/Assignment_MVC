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

            ICollection<Person> people = _personDbContext.People
                .Include(c => c.PersonLanguages)
                .ToList();

            return View(people);
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

        public IActionResult Create(IList<Language> langs, PersonDBCreateViewModel viewModel)
        {
            ViewData["CityName"] = new SelectList(_personDbContext.Cities, "CityId", "CityName");
            ViewData["Countries"] = new SelectList(_personDbContext.Countries, "CountryId", "CountryName");

            langs = _personDbContext.Languages.ToList();

            viewModel.Languages = langs;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(PersonDBCreateViewModel personCrVm, string[] languages)
        {

            ViewData["CityName"] = new SelectList(_personDbContext.Cities, "CityId", "CityName");
            ViewData["Countries"] = new SelectList(_personDbContext.Countries, "CountryId", "CountryName");

            if (ModelState.IsValid)
            {
                PersonLanguage newPersonLanguage = new PersonLanguage();
                Person person = new Person();
                person.Name = personCrVm.Name;
                person.PhoneNumber = personCrVm.PhoneNumber;
                person.CityId = personCrVm.CityId;

                _personDbContext.People.Add(person);
                _personDbContext.SaveChanges();

                foreach (var item in languages)
                {
                    newPersonLanguage.LanguageId = Int32.Parse(item);
                    newPersonLanguage.PersonId = person.PersonId;
                    _personDbContext.PersonLanguages.Add(newPersonLanguage);
                    _personDbContext.SaveChanges();
                }


                if (person != null)
                {
                    return RedirectToAction(nameof(Index), "People");
                }

                ModelState.AddModelError("Storage", "Failed to save");

            }

            return View(personCrVm);
        }

        public IActionResult Details(int id)
        {

            var targetPerson = _personDbContext.People.Find(id);

            var languages = _personDbContext.PersonLanguages.Where(pl => pl.PersonId == id).ToList();

            var city = from c in _personDbContext.Cities
                       where c.CityId == targetPerson.CityId
                       select c.CityName;

            targetPerson.CityName = city.FirstOrDefault().ToString();

            targetPerson.PersonLanguages = languages;



            return View(targetPerson);
        }

        public IActionResult Edit(int id)
        {
            ViewData["CityName"] = new SelectList(_personDbContext.Cities, "CityId", "CityName");
            var targetPerson = _personDbContext.People.Find(id);

            return View(targetPerson);
        }

        [HttpPost]
        public IActionResult Edit(int id, PersonDBCreateViewModel viewModel)
        {
            ViewData["CityName"] = new SelectList(_personDbContext.Cities, "CityName", "CityName");
            Person person = _personDbContext.People.FirstOrDefault(p => p.PersonId == id);

            if (ModelState.IsValid)
            {
                person.Name = viewModel.Name;
                person.PhoneNumber = viewModel.PhoneNumber;
                person.CityId = viewModel.CityId;

                _personDbContext.People.Update(person);
                _personDbContext.SaveChanges();

                if (person != null)
                {
                    return RedirectToAction(nameof(Index), "People");
                }

                ModelState.AddModelError("Storage", "Failed to save");

            }

            return View(viewModel);

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
