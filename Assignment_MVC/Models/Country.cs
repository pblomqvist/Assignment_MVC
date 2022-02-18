using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Country
    {
        [Key]
        [Display(Name = "Name")]
        public string CountryName { get; set; }

        //Navigation property
        public ICollection<City> Cities { get; set; }
    }
}
