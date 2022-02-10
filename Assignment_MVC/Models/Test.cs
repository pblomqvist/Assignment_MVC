using Assignment_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Test
    {
        private static int idCounter = 0 + AllPeople.Count();
        private static List<Person> AllPeople = new List<Person>();

        public PersonViewModel Create(PersonViewModel personViewModel)
        {
            Person newPerson = new Person();
            newPerson.PersonId = ++idCounter;
            newPerson.Name = personViewModel.CreateVM.Name;
            newPerson.PhoneNumber = personViewModel.CreateVM.PhoneNumber;
            newPerson.City = personViewModel.CreateVM.City;

            AllPeople.Add(newPerson);

            return personViewModel;
        }

    }
}
