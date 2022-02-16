using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class PeopleController : Controller
    {

        private readonly PersonDbContext _personDbContext;
        public PeopleController(PersonDbContext context)
        {
            _personDbContext = context;
        }

        public IActionResult Index()
        {
            return View(_personDbContext.People.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _personDbContext.People.Add(person);
                _personDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
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

        public IActionResult Delete(int id)
        {
            
            var targetPerson = _personDbContext.People.Find(id);
            _personDbContext.People.Remove(targetPerson);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
