﻿using Assignment_MVC.Models;
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
        public IActionResult GuessingGame()
        {

            Guess.RandomNumber = Guess.GetNewNum();

            HttpContext.Session.SetInt32("RandomNum", Guess.RandomNumber);
           
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int input, int randnum)
        {
            Guess.GuessedNumber = input;
            randnum = (int)HttpContext.Session.GetInt32("RandomNum");

            if (ModelState.IsValid)
            {
                ViewBag.Message = Guess.Check(input, randnum);
                if (input == randnum)
                {
                    Guess.RandomNumber = Guess.GetNewNum();
                    HttpContext.Session.SetInt32("RandomNum", Guess.RandomNumber);
                }
            } else
            {
                ViewBag.Message = "Must input a number";
            }

            return View();
        }
    }
}