using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models.ViewModels.Admin;
using ER_Smms.Models.ViewModels.Frontend;
using ER_Smms.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ER_Smms.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin, User")]
    public class FrontendController : Controller
    {
        private readonly IHarbourService _harbourService;
        private readonly IPierService _pierService;
        private readonly IBoatslipService _boatslipService;
        private readonly IMooringTypeService _mooringTypeService;
        private readonly IBoatDataService _boatDataService;
        private readonly IWinterstoreSpotService _winterstoreSpotService;
        private readonly IServiceTypeService _serviceTypeService;
        private readonly IServiceApplicationService _serviceApplicationService;
        private readonly IApplicantService _applicantService;

        private UserManager<IdentityAppUser> _userManager;

        public FrontendController(
            IHarbourService harbourService, IPierService pierService,
            IBoatslipService boatslipService, IMooringTypeService mooringTypeService,
            IBoatDataService boatDataService, IWinterstoreSpotService winterstoreSpotService,
            IServiceTypeService serviceTypeService, IServiceApplicationService serviceApplicationService,
            IApplicantService applicantService,

            UserManager<IdentityAppUser> userMrg
            )
        {
            _harbourService = harbourService;
            _pierService = pierService;
            _boatslipService = boatslipService;
            _mooringTypeService = mooringTypeService;
            _boatDataService = boatDataService;
            _winterstoreSpotService = winterstoreSpotService;
            _serviceTypeService = serviceTypeService;
            _serviceApplicationService = serviceApplicationService;
            _applicantService = applicantService;

            _userManager = userMrg;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("SuperAdmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                IdentityAppUser customer = await _userManager.GetUserAsync(User);

                //customer.BoatDatas.ForEach(boatData =>

                FrontendViewModel viewModel = new FrontendViewModel()
                { 
                    //ListUserBoatslip = await _boatslipService.FindUserBoatslip(customer.Id),
                    //ListUserWinterstoreSpot = await _winterstoreSpotService.FindUserWinterstoreSpot(customer.Id)
                    Customer = customer
                };

                //if (viewModel.ListUserBoatslip.Count == 0 )
                //{ viewModel.ListUserBoatslip = null; }

                //if (viewModel.ListUserWinterstoreSpot.Count == 0)
                //{ viewModel.ListUserWinterstoreSpot = null; }

                return View("Index", viewModel);
            }

        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Welcome()
        {
            return View("Welcome");
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult ApplyForBoatslip()
        {

            return View("ApplyForBoatslip");
            //ApplyForBoatslipViewModel viewModel = new ApplyForBoatslipViewModel();

            //List<Boatslip> freeBoatslipList = await _boatslipService.ReadAllEmpty();

            //if (freeBoatslipList.Count != 0 || freeBoatslipList != null)
            //{ viewModel.AreThereFreeBoatslip = true; }
            //else { viewModel.AreThereFreeBoatslip = false; }


            //List<ServiceApplication> applicationQueue = await _serviceApplicationService.ReadAllQueued();

            //List<ServiceApplication> applicationQueueBoatslip = new List<ServiceApplication>();

            //foreach (ServiceApplication item in applicationQueue)
            //{
            //    if (item.ServiceType.Type == "boatslip")
            //    { applicationQueueBoatslip.Add(item); }
            //}

            //viewModel.AmountInBoatslipQueue = applicationQueueBoatslip.Count;

            //return View("ApplyForBoatslip"); //, viewModel);
        }


        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyForBoatslipSave(ApplyForBoatslipViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.CreatedDate = DateTime.Now;
                await _applicantService.Create(viewModel);

                ServiceApplication newServApp = new ServiceApplication()
                {
                    ServiceType = await _serviceTypeService.FindBy(1),
                    Applicant = await _applicantService.FindByDateTime(viewModel.CreatedDate),
                    CreatedDate = viewModel.CreatedDate
                };

                await _serviceApplicationService.Create(newServApp);

                return View("ApplyForBoatslipSuccess", "Båtplats");
            }

            return View("ApplyForBoatslip", viewModel);
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult ApplyForBoatslipSuccess(string whatAppliedFor)
        {
            ViewBag.ApplicantType = whatAppliedFor;

            return View("ApplyForBoatslipSuccess");
        }



            // ******** START - User BoatData 
            public async Task<IActionResult> UserBoatData()
        {
            IdentityAppUser Customer = await _userManager.GetUserAsync(User);

            BoatDataViewModel viewModel = new BoatDataViewModel()
            { BoatDataListView = await _boatDataService.ReadAllForCurrentUser(Customer.UserName) };

            ToastMessageShow();

            return View("UserBoatData", viewModel);
        }


        [HttpGet]
        public IActionResult UserCreateBoatData()
        {
            return View("UserCreateBoatData");
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreateBoatData(UserCreateBoatDataViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.Customer = await _userManager.GetUserAsync(User);

                if (createViewModel.Customer != null)
                {
                    createViewModel.CustomerId = createViewModel.Customer.Id;
                }

                createViewModel.CreatedDate = DateTime.Now;

                //string resultMessage = _boatDataService.Create(createViewModel);
                await _boatDataService.Create(createViewModel);

                //if (resultMessage == "success")
                //{
                //    TempData["ToastType"] = "success";
                //}
                //else
                //{
                //    TempData["ToastType"] = "error";
                //}

                ToastMessageInput("success", "", "Ny Båt är Skapad" );

                return RedirectToAction("UserBoatData");
            }
            else
            {
                return View("UserCreateBoatData", createViewModel);
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEditBoatData(int id)
        {
            UserEditBoatDataViewModel objFromDb = await _boatDataService.FindBy(id);

            objFromDb.CustomerId = objFromDb.Customer.Id;

            IdentityAppUser customer = await _userManager.GetUserAsync(User);

            if (customer.Id != objFromDb.CustomerId)
            {
                ToastMessageInput("error", "", "Detta är inte din Båt!");

                return RedirectToAction("UserBoatData");
            }
            else
            {
                return View("UserEditBoatData", objFromDb);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEditBoatDataSave(UserEditBoatDataViewModel createViewModel)
        {

            if (ModelState.IsValid)
            {
                IdentityAppUser Customer = await _userManager.GetUserAsync(User);

                if (Customer.Id != createViewModel.CustomerId)
                {
                    ToastMessageInput("error", "", "Detta är inte din Båt!");

                    return RedirectToAction("UserBoatData");
                }

                createViewModel.UpdatedDate = DateTime.Now;

                //string resultMessage = _boatDataService.Update(createViewModel);

                await _boatDataService.Update(createViewModel);

                ToastMessageInput("success", "", "Editering av Båt Sparad");


                return RedirectToAction("UserBoatData");
            }

            return View("UserEditBoatData", createViewModel);
        }


        // ******** END - User BoatData 




        // ******* START - Applications for Boatslip, Winterstore etc ********

        public async Task<IActionResult> UserServiceApplications()
        {
            IdentityAppUser customer = await _userManager.GetUserAsync(User);

            UserServiceApplicationViewModel viewModel = new UserServiceApplicationViewModel()
            { 
                UserServiceApplicationListView = await _serviceApplicationService.ReadAllForCurrentUser(customer.UserName)
            };

            ToastMessageShow();

            return View("UserServiceApplication", viewModel);
        }


        public async Task<IActionResult> UserCreateServiceApplication()
        {
            IdentityAppUser Customer = await _userManager.GetUserAsync(User);

            UserCreateServiceApplicationViewModel createViewModel = new UserCreateServiceApplicationViewModel()
            {
                BoatDataListView = await _boatDataService.ReadAllForCurrentUser(Customer.UserName),
                ServiceTypeListView = await _serviceTypeService.ReadAll()
            };

            ToastMessageShow();

            return View("UserCreateServiceApplication", createViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreateServiceApplicationSave(UserCreateServiceApplicationViewModel createViewModel)
        {
            if(ModelState.IsValid)
            {
                createViewModel.Customer = await _userManager.GetUserAsync(User);
                createViewModel.BoatData = await _boatDataService.FindBy(createViewModel.BoatDataId);
                createViewModel.InQueue = 0;
                createViewModel.CreatedDate = DateTime.Now;
                createViewModel.ServiceType = await _serviceTypeService.FindBy(createViewModel.ServiceTypeId);


                // Start check IF exist - with this boat and service
                UserServiceApplicationViewModel customerServAppList = new UserServiceApplicationViewModel()
                {
                    UserServiceApplicationListView =
                        await _serviceApplicationService.ReadAllForCurrentUser(createViewModel.Customer.UserName)
                };

                foreach (var item in customerServAppList.UserServiceApplicationListView)
                {
                    if (item.BoatData == createViewModel.BoatData &&
                        item.ServiceType == createViewModel.ServiceType)
                    {
                        ToastMessageInput("error", "", "Ansökan finns redan! Med denna båt och tjänst.");

                        return RedirectToAction("UserCreateServiceApplication");
                    }
                }
                // End of check IF exist

                await _serviceApplicationService.Create(createViewModel);

                ToastMessageInput("success", "", "Ansökan Skapad");

                return RedirectToAction("UserServiceApplications");
            }
            else
            {
                return View("UserCreateServiceApplication", createViewModel);
            }

        }



        // ******* END - Applications for Boatslip, Winterstore etc ********



        // Error handling view

        public IActionResult CatchShowError(string message)
        {
            FrontendViewModel viewModel = new FrontendViewModel();
            viewModel.ErrorMessageInfo = message;
            return View("ErrorHandleShowInfo", viewModel);
        }


        // -------------- Normal Methods below -------------------



        // ---  ToastMessage Handler and show


        public void ToastMessageShow()
        {
            if (TempData["ToastMessage"] != null) // If message is set. Set ViewBags, to display in returned view 
            {
                ViewBag.ToastType = TempData["ToastType"];
                ViewBag.ToastTitle = TempData["ToastTitle"];
                ViewBag.ToastMessage = TempData["ToastMessage"];

                TempData["ToastMess"] = null;
            }
        }


        public void ToastMessageInput(string type = null, string title = null, string message = null)
        {
            TempData["ToastType"] = type; // Types can only be success, warning or error
            TempData["ToastTitle"] = title;
            TempData["ToastMessage"] = message;

            // Put the code-line below in views where you want toastmessages "popups" /Eric R
            // <partial name="_ToastHandlerPartial" />  
        }


    }


}
