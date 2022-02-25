using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.ViewModels
{
    public class CityCreateViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-ZÀ-ÿ ]*$", ErrorMessage = "Name cannot contain numbers")]
        [Display(Name = "City")]
        [StringLength(80, MinimumLength = 1)]
        public string CityName { get; set; }
        
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public CityCreateViewModel() { }

        public CityCreateViewModel(string city, int country)
        {
            CityName = city;
            CountryId = country;
        }

    }
}
