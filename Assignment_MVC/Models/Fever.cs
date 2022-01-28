using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Models
{
    public class Fever
    {
        
        public static string Check(int temperature)
        {
            if (temperature >= 38)
            {
                return "Your temperature is " + temperature + "°C. You have fever!";
            } else if (temperature <= 35)
            {
                return "Your temperature is " + temperature + "°C. You have hypothermia!";
            }
            else
            {
                return "Your temperature is " + temperature + "°C. You don't have fever!";
            }
        }
        
        [Required]
        public int Temperature { get; set; }
    }
}
