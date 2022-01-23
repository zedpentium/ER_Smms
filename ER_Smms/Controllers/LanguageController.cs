using ER_Smms.Models;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Controllers
{
    [Authorize(Roles = "User, Admin")]

    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            LanguageViewModel languageViewModel = new LanguageViewModel()
            {
                LanguageListView = _languageService.All().LanguageListView,
            };

            return View("Index", languageViewModel);
        }

        [HttpPost]
        public IActionResult Index(LanguageViewModel languageViewModel)
        {
            LanguageViewModel languageViewModel2 = _languageService.FindBy(languageViewModel);

            return View("Index", languageViewModel2);
        }


        [HttpPost]
        public IActionResult CreateLanguage(CreateLanguageViewModel createLanguageViewModel) // set / HttpPost
        {

            LanguageViewModel newModel = new LanguageViewModel();

            if (ModelState.IsValid)
            {
                _languageService.Add(createLanguageViewModel);

                newModel.LanguageListView = _languageService.All().LanguageListView;

                ViewBag.Mess = "Language Added!";

                return View("Index", newModel);
            }

            newModel.LanguageName = createLanguageViewModel.LanguageName;

            newModel.LanguageListView = _languageService.All().LanguageListView;

            return View("index", newModel);
        }


        [HttpPost]
        public IActionResult FindLanguageById(int id)
        {
            Language foundLanguage = _languageService.FindBy(id);

            if (foundLanguage != null)
            {
                List<Language> addLanguage = new List<Language>() { foundLanguage };

                return PartialView("_LanguageListPartial", addLanguage);
            }

            return StatusCode(404);

        }

        [HttpPost]
        public IActionResult DeleteLanguageById(int id)
        {
            bool success = _languageService.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }


        public IActionResult DeleteLanguage(int id)
        {
            _languageService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
