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
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            CityViewModel cityViewModel = new CityViewModel()
            {
                CityListView = _cityService.All().CityListView,
                CountryListView = _countryService.All().CountryListView,
            };

            return View("Index", cityViewModel);
        }

        [HttpPost]
        public IActionResult Index(CityViewModel cityViewModel)
        {
            CityViewModel cityViewModel2 = _cityService.FindBy(cityViewModel);

            return View("Index", cityViewModel2);
        }


        [HttpPost]
        public IActionResult CreateCity(CreateCityViewModel createCityViewModel) // set / HttpPost
        {

            CityViewModel newModel = new CityViewModel();

            if (ModelState.IsValid)
            {
                Country country = _countryService.FindBy(Convert.ToInt32(createCityViewModel.Country));

                _cityService.Add(createCityViewModel.CityName, country);

                newModel.CityListView = _cityService.All().CityListView;
                newModel.CountryListView = _countryService.All().CountryListView;

                ViewBag.Mess = "City Added!";

                return View("Index", newModel);
            }

            newModel.CityName = createCityViewModel.CityName;

            newModel.CityListView = _cityService.All().CityListView;
            newModel.CountryListView = _countryService.All().CountryListView;

            return View("index", newModel);
        }


        [HttpPost]
        public IActionResult FindCityById(int id)
        {
            City foundCity = _cityService.FindBy(id);

            if (foundCity != null)
            {
                List<City> addCity = new List<City>() { foundCity };

                return PartialView("_CountryListPartial", addCity);
            }

            return StatusCode(404);

        }

        [HttpPost]
        public IActionResult DeleteCityById(int id)
        {
            bool success = _cityService.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }

        public IActionResult DeleteCity(int id)
        {
            _cityService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
