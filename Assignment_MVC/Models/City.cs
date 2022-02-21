﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class City
    {
        [Key]
        [Display(Name = "Name")]
        public string CityName { get; set; }

        //Navigation property
        public string CountryName { get; set; }
        public Country Country { get; set; }
        public ICollection<Person> People { get; set; }

    }
}