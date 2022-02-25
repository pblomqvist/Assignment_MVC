using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.ViewModels
{
    public class CountryCreateViewModel
    {

        [Required]
        [RegularExpression("^[a-zA-ZÀ-ÿ ]*$", ErrorMessage = "Name cannot contain numbers")]
        [Display(Name = "Country")]
        [StringLength(80, MinimumLength = 1)]
        public string CountryName { get; set; }

        public CountryCreateViewModel() { }

        public CountryCreateViewModel(string country)
        {
            CountryName = country;
        }


    }
}
