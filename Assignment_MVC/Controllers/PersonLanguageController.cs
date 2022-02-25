using Assignment_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
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
            ViewData["People"] = new SelectList(_personDbContext.People, "PersonId", "PersonId");
            ViewData["Languages"] = new SelectList(_personDbContext.Languages, "LanguageId", "LanguageName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonLanguage model)
        {

            ViewData["People"] = new SelectList(_personDbContext.People, "PersonId", "PersonId");
            ViewData["Languages"] = new SelectList(_personDbContext.Languages, "LanguageId", "LanguageName");

            if (ModelState.IsValid)
            {
                ICollection<PersonLanguage> personLanguages = _personDbContext.PersonLanguages.ToList();

                foreach (var item in personLanguages)
                {

                    if (item.LanguageId == model.LanguageId & item.PersonId == model.PersonId)
                    {
                        ModelState.AddModelError("duplicate_entry", "Cannot add duplicate entries");
                        return View(model);
                    }
                    else
                    {
                        _personDbContext.PersonLanguages.Add(model);
                        _personDbContext.SaveChanges();
                        return RedirectToAction(nameof(Index), "PersonLanguage");
                    }

                }

            }

            return View(model);
        }

        public IActionResult Delete(int PersonId)
        {

            var targetPl = _personDbContext.PersonLanguages.FirstOrDefault(pl => pl.PersonId == PersonId);
            _personDbContext.PersonLanguages.Remove(targetPl);
            _personDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
