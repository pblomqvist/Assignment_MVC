using Assignment_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.ViewModels
{
    public class PersonCreateViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Name cannot contain numbers")]
        [StringLength(80, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public int PhoneNumber { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "City cannot contain numbers")]
        [StringLength(80, MinimumLength = 1)]
        public string City { get; set; }

        public PersonCreateViewModel() { }

        public PersonCreateViewModel(string name, int phonenumber, string city)
        {
            Name = name;
            PhoneNumber = phonenumber;
            City = city;
        }

    }
}
