using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models.Interfaces;
using System.Diagnostics;

namespace ER_Smms.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class AdminController : Controller
    {

        // Now using DI and theese Constructors /ER

        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;

        private readonly IHarbourService _harbourService;
        private readonly IPierService _pierService;
        private readonly IBoatslipService _boatslipService;

        public AdminController(
            IPeopleService peopleService, ICityService cityService,
            ICountryService countryService, ILanguageService languageService,
            IHarbourService harbourService, IPierService pierService, IBoatslipService boatslipService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _countryService = countryService;
            _languageService = languageService;

            _harbourService = harbourService;
            _pierService = pierService;
            _boatslipService = boatslipService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            // CheckIfEmptyUserRoles() does not work. The RedirectToAction
            //in this method refuses to work so, adding a button for that action!

            //switch (checkDone)
            //{
            //    case "EMPTY":
            //        ViewBag.Mess = "UserRoles was empty, so added Admin.";
            //        break;

            //    case "ERRORCouldNotMakeAdmin":
            //        ViewBag.Mess = "Error! UserRole \"Admin\" could not be added, (userRoles are empty).";
            //        break;

            //    case "ROLEExist":
            //        ViewBag.Mess = "UserRoles exists. Nothing done.";
            //        break;

            //    default:
            //        ViewBag.Mess = "";
            //        break;
            //}



            //PeopleViewModel peopleViewModel = CheckIfEmptyDBTables(); 
            // Check if certain DB-Tables are empty. If yes, then add some.";

            //CreatePersonViewModel citylist = new CreatePersonViewModel()
            //{ Cities = peopleViewModel.CityListView };

            ToastMessageHandler();

            return View("Index");
        }



        // ************* START Harbour Actions *************

        public IActionResult Harbour()
        {
            HarbourViewModel harbourViewModel = new HarbourViewModel();
            harbourViewModel = _harbourService.ReadAll();

            ToastMessageHandler();

            return View("Harbour", harbourViewModel);
        }



        [HttpGet]
        public IActionResult CreateHarbour()
        {
            return View("CreateHarbour");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateHarbour(CreateHarbourViewModel createHarbourViewModel)
        {

            if (ModelState.IsValid)
            {
                string resultMessage = _harbourService.Create(createHarbourViewModel);

                if (resultMessage == "success")
                {
                    TempData["ToastType"] = "success";
                }
                else
                {
                    TempData["ToastType"] = "error";
                }

                TempData["ToastMess"] = "Skapade av Hamn - " + resultMessage;

                return RedirectToAction("Harbour");
            }
            else
            {
                TempData["ToastType"] = "error";
                TempData["ToastMess"] = "Fel vid ifyllning av info";
                return View("CreateHarbour");
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditHarbour(int id)
        {
            Harbour editHarbour = _harbourService.FindBy(id);

            CreateHarbourViewModel editViewModel = new CreateHarbourViewModel()
            { Id = editHarbour.Id ,Label = editHarbour.Label, Info = editHarbour.Info };

            return View("EditHarbour", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditHarbourSave(CreateHarbourViewModel createHarbourViewModel)
        {
            if (ModelState.IsValid)
            {
                Harbour editHarbour = new Harbour()
                { 
                    Id = createHarbourViewModel.Id,
                    Label = createHarbourViewModel.Label,
                    Info = createHarbourViewModel.Info
                };

                string resultMessage = _harbourService.Update(editHarbour);

                TempData["ToastType"] = "success";
                TempData["ToastMess"] = "Ändring Sparad!";

                return RedirectToAction("Harbour");
            }

            TempData["ToastType"] = "error";
            TempData["ToastMess"] = "Du skrev in fel vid editering. Ändra och försök igen.";
            return View("EditHarbour");

        }


        [HttpPost]
        public IActionResult DeleteHarbour(int id)
        {
            _harbourService.Remove(id);

            TempData["ToastType"] = "success";
            TempData["ToastMess"] = "Hamn Raderad!";

            return RedirectToAction("Harbour");
        }

        // ************* END Harbour Actions *************


        // ----------

        // ************* START Pier Actions *************
        public IActionResult Pier()
        {
            PierViewModel pierViewModel = new PierViewModel();
            pierViewModel = _pierService.ReadAll();

            ToastMessageHandler();

            return View("Pier", pierViewModel);
        }

        [HttpGet]
        public IActionResult CreatePier()
        {
            CreatePierViewModel viewModel = new CreatePierViewModel();
            viewModel.HarbourListView = _harbourService.ReadAll().HarbourListView;

            return View("CreatePier", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreatePier(CreatePierViewModel createViewModel)
        {
            //Harbour foundHarbour;

            Harbour foundHarbour = _harbourService.FindBy(createViewModel.HarbourId);

            //if (createPierViewModel.HarbourId != 0)
            //{
            //    foundHarbour = _harbourService.FindBy(createPierViewModel.HarbourId);
            //}
            //else
            //{
            //    foundHarbour = null;
            //}

            if (ModelState.IsValid)
            {
                string resultMessage = _pierService.Create(createViewModel, foundHarbour);

                if (resultMessage == "success")
                {
                    TempData["ToastType"] = "success";
                }
                else
                {
                    TempData["ToastType"] = "error";
                }

                TempData["ToastMess"] = "Skapa Brygga - " + resultMessage;

                return RedirectToAction("Pier");
            }
            else
            {
                TempData["ToastType"] = "error";
                TempData["ToastMess"] = "Fel vid ifyllning av info";
                return View("CreatePier", createViewModel);
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditPier(int id)
        {
            Pier objFromDb = _pierService.FindBy(id);

            int harbourId;

            if (objFromDb.Harbour != null)
            { harbourId = objFromDb.Harbour.Id; }
            else
            { harbourId = 0; }

            CreatePierViewModel editViewModel = new CreatePierViewModel()
            { 
                Id = objFromDb.Id,
                Label = objFromDb.Label,
                Info = objFromDb.Info,
                HarbourId = harbourId, HarbourListView = _harbourService.ReadAll().HarbourListView
            };

            return View("EditPier", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditPierSave(CreatePierViewModel createViewModel)
        {

            if (ModelState.IsValid)
            {
                Pier objFromDb = _pierService.FindBy(createViewModel.Id);
                Harbour foundHarbour;

                if (createViewModel.HarbourId != 0)
                {
                    foundHarbour = _harbourService.FindBy(createViewModel.HarbourId);
                }
                else
                {
                    foundHarbour = null;
                }

                objFromDb.Id = createViewModel.Id;
                objFromDb.Label = createViewModel.Label;
                objFromDb.Info = createViewModel.Info;
                objFromDb.Harbour = foundHarbour;                 

                string resultMessage = _pierService.Update(objFromDb);

                TempData["ToastType"] = "success";
                TempData["ToastMess"] = "Ändring Sparad!";

                return RedirectToAction("Pier");
            }

            TempData["ToastType"] = "error";
            TempData["ToastMess"] = "Du skrev in fel vid editering. Ändra och försök igen.";
            return View("EditPier", createViewModel);

        }

        // ************* END Pier Actions *************

        // ----------

        // ************* START Boatslip Actions *************

        public IActionResult Boatslip()
        {
            BoatslipViewModel pierViewModel = new BoatslipViewModel();
            pierViewModel = _boatslipService.ReadAll();

            ToastMessageHandler();

            return View("Boatslip", pierViewModel);
        }


        [HttpGet]
        public IActionResult CreateBoatslip()
        {
            CreateBoatslipViewModel viewModel = new CreateBoatslipViewModel();
            viewModel.PierListView = _pierService.ReadAll().PierListView;

            return View("CreateBoatslip", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateBoatslip(CreateBoatslipViewModel createViewModel)
        {
            Pier foundPier = _pierService.FindBy(createViewModel.PierId);

            if (ModelState.IsValid)
            {
                string resultMessage = _boatslipService.Create(createViewModel, foundPier);

                if (resultMessage == "success")
                {
                    TempData["ToastType"] = "success";
                }
                else
                {
                    TempData["ToastType"] = "error";
                }

                TempData["ToastMess"] = "Skapa Brygga - " + resultMessage;

                return RedirectToAction("Boatslip");
            }
            else
            {
                TempData["ToastType"] = "error";
                TempData["ToastMess"] = "Fel vid ifyllning av info";
                return View("CreateBoatslip");
            }

        }


        // ************* END Boatslip Actions *************

        // ----------




        //[HttpPost]
        //public IActionResult Index(PeopleViewModel peopleViewModel) //Find by model
        //{
        //    //PeopleViewModel peopleViewModel2 = new PeopleViewModel();
        //    //peopleViewModel2 = peopleViewModel;
        //    peopleViewModel = _peopleService.FindBy(peopleViewModel);

        //    /*peopleViewModel2.PersonName = peopleViewModel.PersonName;
        //    peopleViewModel2.PersonPhoneNumber = peopleViewModel.PersonPhoneNumber;
        //    peopleViewModel2.CityListView = peopleViewModel.CityListView;*/

        //    return View("Index", peopleViewModel);
        //}


        //[HttpPost]
        //public IActionResult CreatePerson(CreatePersonViewModel createPersonViewModel) // set / HttpPost
        //{


        //    PeopleViewModel peopleViewModel = new PeopleViewModel();

        //    List<City> cityL = _cityService.All().CityListView;
        //    createPersonViewModel.Cities = cityL;

        //    peopleViewModel.PersonName = createPersonViewModel.PersonName;
        //    peopleViewModel.PersonPhoneNumber = createPersonViewModel.PersonPhoneNumber;
        //    peopleViewModel.CityListView = cityL;


        //    if (ModelState.IsValid)
        //    {

        //        _peopleService.Add(createPersonViewModel);

        //        ViewBag.Mess = "Person Added!";

        //        peopleViewModel.PeopleListView = _peopleService.All().PeopleListView;

        //        return View("Index", peopleViewModel);
        //    }

        //    peopleViewModel.PeopleListView = _peopleService.All().PeopleListView;

        //    return View("index", peopleViewModel);
        //}


        //[HttpPost]
        //public IActionResult DeletePerson(int id)
        //{
        //    _peopleService.Remove(id);

        //    TempData["Deletemess"] = "Person Deleted!";

        //    return RedirectToAction("Index");
        //}

        


        // ---------------  Special Actions below ---------------

        //[HttpPost]
        //public IActionResult PersonDetails(int id)
        //{
        //    Person personDetails = _peopleService.FindBy(id);

        //    return View("Details", personDetails);
        //}




        //[HttpPost]
        //public IActionResult AddLanguageView(int id)
        //{
        //    PersonLanguageViewModel personLanguageViewModel = new PersonLanguageViewModel()
        //    {
        //        LanguageListView = _languageService.All().LanguageListView,
        //        Person = _peopleService.FindBy(id)
        //    };

        //    personLanguageViewModel = GenerateSelectList(personLanguageViewModel);
        //    //personLanguageViewModel.LanguageListView = _languageService.All().LanguageListView;
        //    //personLanguageViewModel.Person = foundPerson;

        //    return View("AddLanguagesToPerson", personLanguageViewModel);
        //}



        //public IActionResult AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel)
        //{
        //    Person person = _peopleService.FindBy(personLanguageViewModel.PersonId);

        //    personLanguageViewModel.LanguageListView = _languageService.All().LanguageListView;
        //    personLanguageViewModel.Person = person;

        //    personLanguageViewModel = GenerateSelectList(personLanguageViewModel);


        //    if (ModelState.IsValid)
        //    {
        //        bool success = _peopleService.AddLanguageToPerson(personLanguageViewModel);

        //        if (success) { ViewBag.Mess = "Languages added to Person!"; }
        //        else { ViewBag.Mess = "Error! Language did NOT get stored"; }

        //        return View("AddLanguagesToPerson", personLanguageViewModel);
        //    }

        //    return View("AddLanguagesToPerson", personLanguageViewModel);
        //}


        public IActionResult AccessDenied()
        {
            return View("_AccessDenied");
        }


        //public RedirectToActionResult CheckIfEmptyUserRoles()
        //{
        //    return RedirectToAction("IsRolesEmpty", "Identity");
        //}


        // -------------- Normal Methods below -------------------

        public void ToastMessageHandler()
        {
            if (TempData["ToastMess"] != null) // If there is a message set. Copy it to ViewBag.Mess
            {
                ViewBag.Mess = TempData["ToastMess"];
                TempData["ToastMess"] = null;
            }
        }


    //public PeopleViewModel CheckIfEmptyDBTables()
    //{
    //    PeopleViewModel peopleViewModel = new PeopleViewModel()
    //    {
    //        PeopleListView = _peopleService.All().PeopleListView,
    //        CityListView = _cityService.All().CityListView,
    //        CountryListView = _countryService.All().CountryListView,
    //        LanguageListView = _languageService.All().LanguageListView
    //    };

    //    if (peopleViewModel.LanguageListView.Count == 0 || peopleViewModel.LanguageListView == null)
    //    {
    //        _languageService.CreateBaseLanguages();
    //        ViewBag.BaseLanguageList = "Language-table was empty, added languages into it. ";
    //        peopleViewModel.LanguageListView = _languageService.All().LanguageListView;
    //    }

    //    if (peopleViewModel.CountryListView.Count == 0 || peopleViewModel.CountryListView == null)
    //    {
    //        _countryService.CreateBaseCountries();
    //        ViewBag.BaseCountryList = "Country-table was empty, added cities into it. ";
    //        peopleViewModel.CountryListView = _countryService.All().CountryListView;
    //    }

    //    if (peopleViewModel.CityListView.Count == 0 || peopleViewModel.CityListView == null)
    //    {
    //        _cityService.CreateBaseCities(peopleViewModel.CountryListView);
    //        ViewBag.BaseCityList = "City-table was empty, added cities into it, and a country per city. ";
    //        peopleViewModel.CityListView = _cityService.All().CityListView;
    //    }

    //    if (peopleViewModel.PeopleListView.Count == 0 || peopleViewModel.PeopleListView == null)
    //    {
    //        _peopleService.CreateBasePeople(peopleViewModel.CityListView);
    //        ViewBag.BasePersonList = "Person-table was empty, added peoples into it. ";
    //        peopleViewModel.PeopleListView = _peopleService.All().PeopleListView;
    //    }

    //    return peopleViewModel;

    //}


    //public PersonLanguageViewModel GenerateSelectList(PersonLanguageViewModel personLanguageViewModel)
    //{
    //    List<Language> listPeronsLang = new List<Language>();
    // list to add languages that a person might have allready
    //    List<SelectListItem> generatedList = new List<SelectListItem>();

    //    foreach (PersonLanguage language in personLanguageViewModel.Person.PersonLanguages.ToList())
    //    {
    //        listPeronsLang.Add(language.Language);
    //    }

    //    bool IsSelected; // to hold true or false for those languages a person might allready have

    //    foreach (Language languageItem in personLanguageViewModel.LanguageListView)
    //    {
    //        Language personLangID = listPeronsLang.Find(id => id.LanguageId == languageItem.LanguageId);

    //        if (personLangID != null) // IsSelected is True if equal, false if not equal
    //        { IsSelected = languageItem.LanguageId == personLangID.LanguageId; }
    //        else { IsSelected = false; }

    //        SelectListItem selectList = new SelectListItem()
    //        {
    //            Text = languageItem.LanguageName,
    //            Value = languageItem.LanguageId.ToString(),
    //            Selected = IsSelected
    //        };
    //        generatedList.Add(selectList);
    //    }
    //    personLanguageViewModel.LanguageSelectList = generatedList;

    //    return personLanguageViewModel;
    //}




}


}
