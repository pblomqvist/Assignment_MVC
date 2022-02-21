using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.ViewModels
{
    public class PersonIndexData
    {
        public IEnumerable<Person> People { get; set; }
        public ICollection<Language> Languages { get; set; }
        public IEnumerable <Country> Countries { get; set; }

    }
}
