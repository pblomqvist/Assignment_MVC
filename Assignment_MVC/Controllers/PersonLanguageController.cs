using Assignment_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    public class PersonLanguageController : Controller
    {
        private readonly PersonDbContext _personDbContext;
        public PersonLanguageController(PersonDbContext context)
        {
            _personDbContext = context;
        }

        public IActionResult Index()
        {
            return View(_personDbContext.PersonLanguages.OrderBy(p => p.PersonId).ToList());
        }

        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_personDbContext.People, "PersonId", "PersonId");
            ViewData["LanguageName"] = new SelectList(_personDbContext.Languages, "LanguageName", "LanguageName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonLanguage personLanguage)
        {

            ViewData["PersonId"] = new SelectList(_personDbContext.People, "PersonId", "PersonId");
            ViewData["LanguageName"] = new SelectList(_personDbContext.Languages, "LanguageName", "LanguageName");

            if (ModelState.IsValid)
            {
                
                if (_personDbContext.PersonLanguages.Any(p => p.PersonId == personLanguage.PersonId))
                {
                    ModelState.AddModelError("duplicate_entry", "Cannot add duplicate entries");
                    return View(personLanguage);
                } else
                {
                    _personDbContext.PersonLanguages.Add(personLanguage);
                    _personDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index), "PersonLanguage");
                }

            }

            return View(personLanguage);
        }
    }
}
