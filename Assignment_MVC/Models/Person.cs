using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        //Class for JS/AJAX assignment
        public string? City { get; set; }

        //Class for DB assignment
        [Display(Name = "City")]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public City DbCity { get; set; }


        public ICollection<PersonLanguage> PersonLanguages { get; set; }

    }
}
