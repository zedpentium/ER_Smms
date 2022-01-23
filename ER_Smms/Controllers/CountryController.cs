using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models;

namespace ER_Smms.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            CountryViewModel countryViewModel = new CountryViewModel()
            {
                CountryListView = _countryService.All().CountryListView,
            };

            return View("Index", countryViewModel);
        }

        [HttpPost]
        public IActionResult Index(CountryViewModel countryViewModel)
        {
            CountryViewModel countryViewModel2 = _countryService.FindBy(countryViewModel);

            return View("Index", countryViewModel2);
        }


        [HttpPost]
        public IActionResult CreateCountry(CreateCountryViewModel createCountryViewModel) // set / HttpPost
        {

            CountryViewModel newModel = new CountryViewModel();

            if (ModelState.IsValid)
            {
                _countryService.Add(createCountryViewModel);

                newModel.CountryListView = _countryService.All().CountryListView;

                ViewBag.Mess = "Country Added!";

                return View("Index", newModel);
            }

            newModel.CountryName = createCountryViewModel.CountryName;

            newModel.CountryListView = _countryService.All().CountryListView;

            return View("index", newModel);
        }


        [HttpPost]
        public IActionResult FindCountryById(int id)
        {
            Country foundCountry = _countryService.FindBy(id);

            if (foundCountry != null)
            {
                List<Country> addCountry = new List<Country>() { foundCountry };

                return PartialView("_CountryListPartial", addCountry);
            }

            return StatusCode(404);

        }

        [HttpPost]
        public IActionResult DeleteCountryById(int id)
        {
            bool success = _countryService.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }

        public IActionResult DeleteCountry(int id)
        {
            _countryService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
