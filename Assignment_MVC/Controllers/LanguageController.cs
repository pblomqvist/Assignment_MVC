using Assignment_MVC.Models;
using Assignment_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {
        private readonly PersonDbContext _personDbContext;
        public LanguageController(PersonDbContext context)
        {
            _personDbContext = context;
        }

        public IActionResult Index()
        {
            return View(_personDbContext.Languages.Include(l => l.PersonLanguages).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LanguageCreateViewModel languageCrVm)
        {

            if (ModelState.IsValid)
            {
                Language language = new Language();
                language.LanguageName = languageCrVm.LanguageName;

                if (_personDbContext.Languages.Any(l => l.LanguageName == languageCrVm.LanguageName))
                {
                    ModelState.AddModelError("duplicate_entry", "Cannot add duplicate entries");
                    return View(languageCrVm);
                }
                else
                {
                    _personDbContext.Languages.Add(language);
                    _personDbContext.SaveChanges();
                    return RedirectToAction(nameof(Index), "Language");
                }

            }

            return View(languageCrVm);
        }

        public IActionResult Details(string LanguageName)
        {

            var targetLanguage = _personDbContext.Languages.Find(LanguageName);

            var people = _personDbContext.PersonLanguages.Where(pl => pl.LanguageName == LanguageName).ToList();

            targetLanguage.PersonLanguages = people;


            return View(targetLanguage);
        }

        public IActionResult Edit()
        {

            return View();
        }

        public IActionResult Delete(string LanguageName)
        {

            var targetLanguage = _personDbContext.Languages.FirstOrDefault(c => c.LanguageName == LanguageName);
            _personDbContext.Languages.Remove(targetLanguage);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
