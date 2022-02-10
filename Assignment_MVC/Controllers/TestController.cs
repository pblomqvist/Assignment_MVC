using Assignment_MVC.Models;
using Assignment_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class TestController : Controller
    {

        PersonViewModel personVM = new PersonViewModel();

        public static List<Person> AllPeople = new List<Person>
        {
            new Person
            {
                PersonId = 1,
                Name = "Maja Gräddnos",
                City = "Kiruna",
                PhoneNumber = 12345
            },
            new Person
            {
                PersonId = 2,
                Name = "Kalle Kaviar",
                City = "Västerås",
                PhoneNumber = 123457
            },
            new Person
            {
                PersonId = 3,
                Name = "Pelle Svanslös",
                City = "Stockholm",
                PhoneNumber = 123458
            },
            new Person
            {
                PersonId = 4,
                Name = "Frank Franksson",
                City = "Göteborg",
                PhoneNumber = 123458
            },
            new Person
            {
                PersonId = 5,
                Name = "Kalle Söderström",
                City = "Göteborg",
                PhoneNumber = 123458
            }
        };

        public IActionResult Index()
        {
            personVM.listOfPeople = AllPeople.OrderBy(p => p.PersonId).ToList();

            return View(personVM);

        }


        public ActionResult Search(string keyword)
        {
            PersonViewModel search = new PersonViewModel();
            Person person = new Person();
            List<Person> matches = new List<Person>();

            if (keyword != null)
            {
                search.keyword = keyword.ToLower();

                foreach (Person item in AllPeople)
                {

                    if (item.Name.ToLower().Contains(keyword) || item.City.ToLower().Contains(keyword))
                    {
                        person = item;
                        matches.Add(person);
                    }
                }

                search.listOfPeople = matches;

            } else
            {
                search.listOfPeople = AllPeople;
            } 

            return View("Index", search);
        }

        [HttpPost]
        public ActionResult Create(PersonViewModel create)
        {
            int idCounter = 0 + AllPeople.Count();

            if (ModelState.IsValid)
            {
                Person newPerson = new Person();
                newPerson.PersonId = ++idCounter;
                newPerson.Name = create.CreateVM.Name;
                newPerson.PhoneNumber = create.CreateVM.PhoneNumber;
                newPerson.City = create.CreateVM.City;

                AllPeople.Add(newPerson);

                if (newPerson != null)
                {
                    return RedirectToAction(nameof(Index), "Test");
                }

                ModelState.AddModelError("Storage", "Failed to save");

            }
            
            return View("Index", create);
        }

        public ActionResult Edit(int id)
        {
            var person = AllPeople.Where(p => p.PersonId == id).FirstOrDefault();

            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person prsn)
        {
           var person = AllPeople.Where(p => p.PersonId == prsn.PersonId).FirstOrDefault();

            AllPeople.Remove(person);
            AllPeople.Add(prsn);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            PersonViewModel del = new PersonViewModel();

            del.listOfPeople = AllPeople;

            Person person = del.listOfPeople.Find(p => p.PersonId == id);
            AllPeople.Remove(person);
            return View("Index", del);
        }

        public ActionResult Example(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var fromJSON = serializer.Deserialize<Person>(model);
            return Json(fromJSON);
        }
    }
}
