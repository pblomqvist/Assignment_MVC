using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.ViewModels
{
    public class PersonViewModel
    {
        public PersonCreateViewModel CreateVM { get; set; }
        public List<Person> listOfPeople { get; set; }
        public string keyword { get; set; }
    }
}
