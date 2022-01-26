using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public List<Project> Project()
        {
            List<Project> AllProjects = new List<Project>
            {
                new Project {Name="Hangman", Description="A console application where you can play hangman", Url="https://github.com/pblomqvist/Hangman_Assignment"},
                new Project {Name="Calculator", Description="A calculator console application where you can do many calculations", Url="https://github.com/pblomqvist/Calculator_Assignment"},
                new Project {Name="Vending Machine", Description="A vending machine console application where you can buy and use products", Url="https://github.com/pblomqvist/VendingMachine_Assignment"},
                new Project {Name="HTML", Description="A very simple HTML page", Url="https://github.com/pblomqvist/Assignment_HTML"},
                new Project {Name="CSS", Description="A HTML page styled with CSS", Url="https://github.com/pblomqvist/Assignment_CSS"},
                new Project {Name="Sokoban", Description="A page containing the game Sokoban which contains Javascript", Url="https://github.com/pblomqvist/Sokoban"}
            };

            return AllProjects;
        }

        public IActionResult Projects()
        {
            return View(Project());
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
