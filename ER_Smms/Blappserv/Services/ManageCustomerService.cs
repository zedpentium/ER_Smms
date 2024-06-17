using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels.Admin;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.Services;
using ER_Smms.Blappserv.ViewModels;
using ER_Smms.Blappserv.Interfaces;
using ER_Smms.Models.ViewModels.Identity;
using Microsoft.JSInterop;
using System;
using Microsoft.AspNetCore.Components;

namespace ER_Smms.Blappserv.Services
{
    public class ManageCustomerService
    {
        private readonly IHarbourService _harbourService;
        private readonly IPierService _pierService;
        private readonly IBoatslipService _boatslipService;
        private readonly IMooringTypeService _mooringTypeService;
        private readonly IBoatDataService _boatDataService;
        private readonly IWinterstoreSpotService _winterstoreSpotService;
        private readonly IServiceTypeService _serviceTypeService;
        private readonly IServiceApplicationService _serviceApplicationService;

        private readonly IServiceHistoryService _serviceHistoryService;

        private readonly IApplicantService _applicantService;

        private ILoggerManager _logger;

        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityAppUser> _userManager;

        public ManageCustomerService(
            IHarbourService harbourService, IPierService pierService,
            IBoatslipService boatslipService, IMooringTypeService mooringTypeService,
            IBoatDataService boatDataService, IWinterstoreSpotService winterstoreSpotService,
            IServiceTypeService serviceTypeService, IServiceApplicationService serviceApplicationService,
            IServiceHistoryService serviceHistoryService, IApplicantService applicantService,

            ILoggerManager logger,

        RoleManager<IdentityRole> roleMgr, UserManager<IdentityAppUser> userMrg
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
            _serviceHistoryService = serviceHistoryService;

            _applicantService = applicantService;

            _logger = logger;

            _roleManager = roleMgr;
            _userManager = userMrg;
        }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }


        public async Task<CustomerAllInfoDTO> GetManageCustomerAsync(string userName)
        {

            // Get Weather Forecasts  

            //return await _context.WeatherForecast
            //     // Only get entries for the current logged in user
            //     .Where(x => x.UserName == strCurrentUser)
            //     // Use AsNoTracking to disable EF change tracking
            //     // Use ToListAsync to avoid blocking a thread
            //     .AsNoTracking().ToListAsync();


            IdentityAppUser customer = await _userManager.FindByNameAsync(userName);

            CustomerAllInfoDTO customerAllInfo = customer;

            customerAllInfo.BoatDatas = new List<BoatDataDTO>();
            List<BoatData> boatDataList = await _boatDataService.ReadAllForCurrentUser(customer.UserName);
            foreach (BoatData boatData in boatDataList)
            {
                customerAllInfo.BoatDatas.Add(boatData);
            }
            //customerAllInfoDTO.BoatDatas = await _boatDataService.ReadAllForCurrentUser(userName);
            //customerAllInfoDTO.BoatsAmount = customerAllInfoDTO.BoatDatas.Count;
            customerAllInfo.BoatsAmount = customerAllInfo.BoatDatas.Count;



            //BManageCustomerViewModel viewModel = new BManageCustomerViewModel()
            //{
            //    //CustomerAllInfo = customerAllInfoDTO,
            //    CustomerAllInfo = customerAllInfo,
            //    //FreeBoatslips = await _boatslipService.ReadAllEmpty(),
            //    BoatData = new BoatData()
            //    //FreeWinterstoreSpotsOut = await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstoreout"),
            //    //FreeWinterstoreSpotsIn = await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstorein")
            //};


            //ToastMessageShow();

            return customerAllInfo;
        }


        public async Task<BManageCustomerViewModel> GetAllCustomersAsync()
        {
            IList<IdentityAppUser> userlistFromDB = await _userManager.GetUsersInRoleAsync("User");

            BManageCustomerViewModel customerListViewModel = new BManageCustomerViewModel()
            { CustomerAllInfoListView = new List<CustomerAllInfoDTO>() };

            foreach (IdentityAppUser customer in userlistFromDB)
            {
                CustomerAllInfoDTO customerAllInfo = customer;

                customerAllInfo.BoatDatas = new List<BoatDataDTO>();
                List<BoatData> boatDataList = await _boatDataService.ReadAllForCurrentUser(customer.UserName);
                foreach (BoatData boatData in boatDataList)
                {
                    customerAllInfo.BoatDatas.Add(boatData);
                }
                customerAllInfo.BoatslipsAmount = 0;
                customerAllInfo.WinterstoreAmount = 0;
                customerAllInfo.BoatsAmount = customerAllInfo.BoatDatas.Count;


                foreach (BoatDataDTO boatData in customerAllInfo.BoatDatas)
                {
                    if (boatData.Boatslip != null)
                    { customerAllInfo.BoatslipsAmount++; }
                    if (boatData.WinterstoreSpot != null)
                    { customerAllInfo.WinterstoreAmount++; }
                }

                customerListViewModel.CustomerAllInfoListView.Add(customerAllInfo);
            }

            return customerListViewModel;
        }


        public async Task<IdentityResult> SaveEditCustomerAsync(IBManageCustomerViewModel viewModel)
        {
            IdentityAppUser user = await _userManager.FindByNameAsync(viewModel.CustomerAllInfo.UserName);

            IdentityResult result = await IdentityUserMergeAndUpdate(user, viewModel);

            //await ToastMessageInputAndShow("success", "Editering av Kund", "Kunduppgifts-ändringar sparat", 7000);

            return result;
        }




        // ***** -- START - Take info from form, insert into user-object and update.

        public async Task<IdentityResult> IdentityUserMergeAndUpdate(IdentityAppUser user, IBManageCustomerViewModel viewModel)
        {
            user.FirstName = viewModel.CustomerAllInfo.FirstName;
            user.LastName = viewModel.CustomerAllInfo.LastName;
            user.Email = viewModel.CustomerAllInfo.Email;
            user.PhoneNumber = viewModel.CustomerAllInfo.PhoneNumber;
            user.Address = viewModel.CustomerAllInfo.Address;
            user.Postcode = viewModel.CustomerAllInfo.Postcode;
            user.City = viewModel.CustomerAllInfo.City;
            user.ExtraInfoTextarea = viewModel.CustomerAllInfo.ExtraInfoTextarea;

            var result = await _userManager.UpdateAsync(user);

            return result;
        }
        // ***** -- END - Take info from form, insert into user-object and update.



        // ------------- Boatslips
        public async Task<List<Boatslip>> GetFreeBoatslips()
        {
            List<Boatslip> freeBoatslips = await _boatslipService.ReadAllEmpty();

            return freeBoatslips;
        }


        public async Task ManageCustomerSaveAssignedBoatslip(IBManageCustomerViewModel viewModel)
        {
            //BoatData boatData = await _boatDataService.FindBy(viewModel.SelectedBoatDataId);
            if (viewModel.BoatDTO.Boatslip != null)
            {
                viewModel.BoatDTO.Boatslip.BoatDataIdRef = 0;
                await _boatslipService.Update(viewModel.BoatDTO.Boatslip);
            }

            Boatslip boatslip = await _boatslipService.FindBy(viewModel.SelectedBoatslipId);
            boatslip.BoatDataIdRef = viewModel.SelectedBoatDataId;
            viewModel.BoatDTO.Boatslip = boatslip;

            await _boatDataService.Update(viewModel.BoatDTO);

            await AddInServiceHistory(viewModel.BoatDTO.Id, boatslip.ServiceType.Id, boatslip.Id, 0);

            //await ToastMessageInputAndShow("success", "",
                    //$"Båten {viewModel.BoatDTO.Label}, har fått BåtPlats {boatslip.Label} på {boatslip.Pier.Label}", 7000);

            //return RedirectToAction("ManageCustomer", new { id = boatData.Customer.UserName });
        }






        // ----------- Winterspots
        public async Task<List<WinterstoreSpot>> GetFreeWinterstoreSpots()
        {
            List<WinterstoreSpot> freeWinterstoreSpots =
                await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstoreout");

            foreach (var winterspotin in await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstorein"))
            {
                freeWinterstoreSpots.Add(winterspotin);
            }

            return freeWinterstoreSpots;
        }


        public async Task EditWinterstoreSpotSave(EditWinterstoreSpotViewModel editViewModel)
        {
            editViewModel.ServiceType = await _serviceTypeService.FindBy(editViewModel.ServiceTypeId);

            editViewModel.SpotM2 = editViewModel.Length * editViewModel.Width;

            await _winterstoreSpotService.Update(editViewModel);

            //ToastMessageInput("success", "", "Editering Sparad");
        }


        public async Task ManageCustomerSaveAssignedWinterstore(IBManageCustomerViewModel viewModel)
        {
            //BoatData boatData = await _boatDataService.FindBy(viewModel.SelectedBoatDataId);
            if (viewModel.BoatDTO.WinterstoreSpot != null)
            {
                viewModel.BoatDTO.WinterstoreSpot.BoatDataIdRef = 0;
                await _winterstoreSpotService.Update(viewModel.BoatDTO.WinterstoreSpot);
            }

            WinterstoreSpot winterstore = await _winterstoreSpotService.FindBy(viewModel.SelectedWinterstoreSpotId);
            winterstore.BoatDataIdRef = viewModel.SelectedBoatDataId;
            viewModel.BoatDTO.WinterstoreSpot = winterstore;

            await _boatDataService.Update(viewModel.BoatDTO);

            await AddInServiceHistory(viewModel.BoatDTO.Id, winterstore.ServiceType.Id, winterstore.Id, 0);

            //await ToastMessageInputAndShow("success", "",
                    //$"Båten {viewModel.BoatDTO.Label}, har fått VinterPlats {winterstore.Label} som är {winterstore.ServiceType.Label}", 7000);

            //return RedirectToAction("ManageCustomer", new { id = boatData.Customer.UserName });
        }


        // ************* START -  Create/Edit Boatslip Actions *************


        public async Task<EditBoatslipViewModel> EditBoatslip(int id)
        {
            EditBoatslipViewModel editViewModel = await _boatslipService.FindBy(id);

            if (editViewModel.ServiceType != null)
            { editViewModel.ServiceTypeId = editViewModel.ServiceType.Id; }
            else
            { editViewModel.ServiceTypeId = 0; }

            if (editViewModel.MooringType != null)
            { editViewModel.MooringTypeId = editViewModel.MooringType.Id; }
            else
            { editViewModel.MooringTypeId = 0; }

            if (editViewModel.Pier != null)
            { editViewModel.PierId = editViewModel.Pier.Id; }
            else
            { editViewModel.PierId = 0; }

            if (editViewModel.BoatDataIdRef != 0)
            {
                editViewModel.BoatDataId = editViewModel.BoatDataIdRef;
                editViewModel.BoatDataIdThatWas = editViewModel.BoatDataId;
            }
            else
            { editViewModel.BoatDataId = 0; }

            editViewModel.ServiceTypeListView = await _serviceTypeService.ReadAllForType("boatslip");

            editViewModel.Ienum_ServiceTypeListView = editViewModel.ServiceTypeListView;

            //editViewModel.JsonServiceTypeListView = JsonConvert.SerializeObject(editViewModel.ServiceTypeListView);
            //    JsonConvert.SerializeObject(editViewModel.ServiceTypeListView, Formatting.Indented);
            //Debug.WriteLine(editViewModel.JsonServiceTypeListView);
            //var json = JsonConvert.SerializeObject(aList);
            // JsonConvert.SerializeObject(editViewModel.ServiceTypeListView, Formatting.Indented);


            editViewModel.MooringTypeListView = await _mooringTypeService.ReadAll();
            editViewModel.PierListView = await _pierService.ReadAll();
            editViewModel.BoatDataListView = await _boatDataService.ReadAll();

            return editViewModel;
        }



        // ************* END -  Create/Edit Boatslip Actions *************








        // ************* START -  ServiceHistory Actions *************


        public async Task AddInServiceHistory(
            int boatDataid, int serviceTypeId = 0, int boatslipId = 0, int winterstoreSpotId = 0)
        {
            CreateServiceHistory historyEntry = new CreateServiceHistory()
            {
                BoatData = await _boatDataService.FindBy(boatDataid),
                ServiceType = new ServiceType(),
                Boatslip = new Boatslip(),
                WinterstoreSpot = new WinterstoreSpot(),
                CreatedDate = DateTime.Now
            };
            historyEntry.Customer = historyEntry.BoatData.Customer;
            historyEntry.Boatslip = null;
            historyEntry.WinterstoreSpot = null;

            if (serviceTypeId != 0)
            { historyEntry.ServiceType = await _serviceTypeService.FindBy(serviceTypeId); }

            if (boatslipId != 0)
            { historyEntry.Boatslip = await _boatslipService.FindBy(boatslipId); }

            if (winterstoreSpotId != 0)
            { historyEntry.WinterstoreSpot = await _winterstoreSpotService.FindBy(winterstoreSpotId); }

            await _serviceHistoryService.Create(historyEntry);

            //return Ok();
        }




        // ************* END -  ServiceHistory Actions *************     


        // ----------






        // ---  ToastMessage Handler and show

        public async Task ToastMessageInputAndShow()
        {
            //await JSRuntime.InvokeVoidAsync("setAndShowToast", $"{type}", $"{title}", $"{message}", $"{timer}");

            await JSRuntime.InvokeVoidAsync("setAndShowToast", "success", "testa", "bööööös", 7000);
        }


        //public void ToastMessageShow()
        //{
        //    if (TempData["ToastMessage"] != null) // If message is set. Set ViewBags, to display in returned view 
        //    {
        //        ViewBag.ToastType = TempData["ToastType"];
        //        ViewBag.ToastTitle = TempData["ToastTitle"];
        //        ViewBag.ToastMessage = TempData["ToastMessage"];

        //        TempData["ToastMess"] = null;
        //    }
        //}


        //public void ToastMessageInput(string type = null, string title = null, string message = null)
        //{
        //    TempData["ToastType"] = type; // Types can only be success, warning or error
        //    TempData["ToastTitle"] = title;
        //    TempData["ToastMessage"] = message;

        //    // Put the code-line below in views where you want toastmessages "popups" /Eric R
        //    // <partial name="_ToastHandlerPartial" /> 
        //}


    }

}