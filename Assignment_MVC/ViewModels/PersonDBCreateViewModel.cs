using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.ViewModels
{
    public class PersonDBCreateViewModel
    {
        //Viewmodel for /Person/Create in order to keep /Test/Create intact

        [Required]
        [RegularExpression("^[a-zA-ZÀ-ÿ ]*$", ErrorMessage = "Name cannot contain numbers or special characters")]
        [StringLength(80, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public IList<Country> Countries { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
        public City city { get; set; }

        [Display(Name = "Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public IList<Language> Languages { get; set; }

        public PersonDBCreateViewModel() { }

        public PersonDBCreateViewModel(string name, int phone, int city)
        {
            Name = name;
            PhoneNumber = phone;
            CityId = city;
        }

    }
}
