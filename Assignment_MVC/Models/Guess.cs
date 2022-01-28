using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Assignment_MVC.Models
{
    public class Guess
    {
        public static string Check(int input, int randnum)
        {
            if (input == randnum)
            {
                return "Congratulations, your guess of " + randnum + " was correct! New number generated, try again!!";
            } else if (input < randnum) {
                return "Number is higher than " + input;
            } else if (input > randnum)
            {
                return "Number is lower than " + input;
            } else
            {
                return "Guessed number is " + input;
            }
        }

        public static int GetNewNum()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 100);

            return value;
        }

        [Required]
        public static int GuessedNumber { get; set; }
        public static int RandomNumber { get; set; }

    }
}
