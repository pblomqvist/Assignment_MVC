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
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Name cannot contain numbers")]
        [StringLength(80, MinimumLength = 1)]
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public Country Country { get; set; }
    }
}
