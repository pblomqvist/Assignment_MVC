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

        public IActionResult Details(int LanguageId)
        {

            var targetLanguage = _personDbContext.Languages.Find(LanguageId);

            var people = _personDbContext.PersonLanguages.Where(pl => pl.LanguageId == LanguageId).ToList();

            targetLanguage.PersonLanguages = people;


            return View(targetLanguage);
        }

        public IActionResult Edit(int LanguageId)
        {
            var targetLanguage = _personDbContext.Languages.Find(LanguageId);

            return View(targetLanguage);
        }

        [HttpPost]
        public IActionResult Edit(int LanguageId, LanguageCreateViewModel viewModel)
        {
            Language language = _personDbContext.Languages.Where(c => c.LanguageId == LanguageId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                language.LanguageName = viewModel.LanguageName;

                _personDbContext.Languages.Update(language);
                _personDbContext.SaveChanges();

                if (language != null)
                {
                    return RedirectToAction(nameof(Index), "Language");
                }

                ModelState.AddModelError("Storage", "Failed to save");

            }

            return View(viewModel);

        }

        public IActionResult Delete(int LanguageId)
        {

            var targetLanguage = _personDbContext.Languages.FirstOrDefault(c => c.LanguageId == LanguageId);
            _personDbContext.Languages.Remove(targetLanguage);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
