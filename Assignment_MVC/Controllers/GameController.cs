using Assignment_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult GuessingGame()
        {
            //Randomize a number and assign it
            //Guess.RandomNumber = Guess.GetNewNum();

            if (!HttpContext.Request.Cookies.ContainsKey("RandomNum"))
            {
                AppendNewNum();
                HttpContext.Session.SetInt32("RandomNum", Guess.RandomNumber);
            } else
            {
                ViewBag.Message = "Random number exists!";
            }

           
            return View();
        }
        
        public void AppendNewNum()
        {
            Guess.RandomNumber = Guess.GetNewNum();
            HttpContext.Response.Cookies.Append("RandomNum", Guess.RandomNumber.ToString());
            HttpContext.Session.SetInt32("RandomNum", Guess.RandomNumber);
        }

        [HttpPost]
        public IActionResult GuessingGame(int guessednum, int randnum)
        {
            Guess.GuessedNumber = guessednum;
            randnum = Int32.Parse(HttpContext.Request.Cookies["RandomNum"]);

            if (ModelState.IsValid)
            {
                ViewBag.Message = Guess.Check(guessednum, randnum);
                if (guessednum == randnum)
                {
                    Response.Cookies.Delete("RandomNum");
                    AppendNewNum();
                }
            } else
            {
                ViewBag.Message = "Must input a number";
            }

            return View();
        }
    }
}
