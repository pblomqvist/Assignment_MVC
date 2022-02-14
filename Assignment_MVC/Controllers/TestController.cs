using Assignment_MVC.Models;
using Assignment_MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
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

        [HttpGet]
        public ActionResult Fetch()
        {
            personVM.listOfPeople = AllPeople.OrderBy(p => p.PersonId).ToList();

            return PartialView("_cardListPartial", personVM.listOfPeople);
        }

    //public ActionResult Search(string keyword)
    //    {
    //        PersonViewModel search = new PersonViewModel();
    //        Person person = new Person();
    //        List<Person> matches = new List<Person>();

    //        if (keyword != null)
    //        {
    //            search.keyword = keyword.ToLower();

    //            foreach (Person item in AllPeople)
    //            {

    //                if (item.Name.ToLower().Contains(keyword) || item.City.ToLower().Contains(keyword))
    //                {
    //                    person = item;
    //                    matches.Add(person);
    //                }
    //            }

    //            search.listOfPeople = matches;

    //        } else
    //        {
    //            search.listOfPeople = AllPeople;
    //        } 

    //        return View("Index", search);
    //    }

     
        public ActionResult Details(int id)
        {

            List<Person> people = AllPeople;
            Person targetPerson = new Person();

            foreach (Person item in people)
            {
                if (item.PersonId == id)
                {
                    targetPerson = item;
                }
            }

            if (id == 0 || targetPerson.Name == null)
            {
                return null;
            }

            return PartialView("_cardPartial", targetPerson);
        }


        public ActionResult Create(string Name, int PhoneNumber, string City, PersonCreateViewModel personCrVM)
        {
            int idCounter = 0 + AllPeople.Count();

            Person person = new Person();

            if (Name != null || PhoneNumber != 0 || City != null)
            {
                personCrVM.Name = Name;
                personCrVM.PhoneNumber = PhoneNumber;
                personCrVM.City = City;

            }

            if (ModelState.IsValid)
            {

                person.PersonId = ++idCounter;
                person.Name = personCrVM.Name;
                person.PhoneNumber = personCrVM.PhoneNumber;
                person.City = personCrVM.City;

                AllPeople.Add(person);

                if (person != null)
                {
                    return PartialView("_cardPartial", person);
                }

                ModelState.AddModelError("Storage", "Failed to save");

            }

            return View(personCrVM);
        }


        //public ActionResult Create(PersonViewModel create)
        //{
        //    int idCounter = 0 + AllPeople.Count();
        //    Person newPerson = new Person();

        //    if (ModelState.IsValid)
        //    {
                
        //        newPerson.PersonId = ++idCounter;
        //        newPerson.Name = create.CreateVM.Name;
        //        newPerson.PhoneNumber = create.CreateVM.PhoneNumber;
        //        newPerson.City = create.CreateVM.City;

        //        AllPeople.Add(newPerson);

        //        if (newPerson != null)
        //        {
        //            return RedirectToAction(nameof(Index), "Test");
        //        }

        //        ModelState.AddModelError("Storage", "Failed to save");

        //    }

        //    create.listOfPeople = AllPeople;
            
        //    return PartialView("_listPartial", newPerson);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var person = AllPeople.Where(p => p.PersonId == id).FirstOrDefault();

        //    return View(person);
        //}

        //[HttpPost]
        //public ActionResult Edit(Person prsn)
        //{
        //   var person = AllPeople.Where(p => p.PersonId == prsn.PersonId).FirstOrDefault();

        //    AllPeople.Remove(person);
        //    AllPeople.Add(prsn);

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            PersonViewModel del = new PersonViewModel();
            del.listOfPeople = AllPeople;
            Person person = del.listOfPeople.Find(p => p.PersonId == id);

            if (person != null)
            {
                del.listOfPeople.Remove(person);
                return Ok();
            }

            return NotFound();
        }

    }
}
