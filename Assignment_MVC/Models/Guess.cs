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
        public static string Check(int guessednum, int randnum)
        {
            if (guessednum == randnum)
            {
                return "Congratulations, your guess of " + randnum + " was correct! New number generated, try again!!";
            } else if (guessednum < randnum) {
                return "Number is higher than " + guessednum;
            } else if (guessednum > randnum)
            {
                return "Number is lower than " + guessednum;
            } else
            {
                return "Guessed number is " + guessednum;
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
