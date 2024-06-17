using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels.Admin;
using ER_Smms.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Linq;
using System.Collections;
using ER_Smms.Models.ViewModels.Identity;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Diagnostics;
//using System.Text.Json;
//using System.Text.Json.Serialization;

namespace ER_Smms.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    [Authorize(Roles = "SuperAdmin, Admin")]
    public class AdminController : Controller
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

        public AdminController(
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


        [HttpGet]
        public IActionResult Index()
        {
            ToastMessageShow();

            return View("Index");
        }



        // ************* START Harbour Actions *************

        public async Task<IActionResult> Harbour()
        {
            HarbourViewModel harbourViewModel = new HarbourViewModel()
            { HarbourListView = await _harbourService.ReadAll() };

            ToastMessageShow();

            return View("Harbour", harbourViewModel);
        }



        [HttpGet]
        public IActionResult CreateHarbour()
        {
            return View("CreateHarbour");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHarbour(CreateHarbourViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                await _harbourService.Create(createViewModel);

                ToastMessageInput("success", "", "Hamn Skapad");

                return RedirectToAction("Harbour");
            }
            else
            {
                return View("CreateHarbour", createViewModel);
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHarbour(int id)
        {
            EditHarbourViewModel editViewModel = await _harbourService.FindBy(id);

            return View("EditHarbour", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHarbourSave(EditHarbourViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                await _harbourService.Update(editViewModel);

                ToastMessageInput("success", "", "Editering Sparad");

                return RedirectToAction("Harbour");
            }

            return View("EditHarbour", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteHarbour(int id)
        {
            await _harbourService.Remove(id);

            ToastMessageInput("success", "", "Hamn Raderad");

            return RedirectToAction("Harbour");
        }

        // ************* END Harbour Actions *************


        // ----------

        // ************* START Pier Actions *************
        public async Task<IActionResult> Pier()
        {
            PierViewModel pierViewModel = new PierViewModel()
            { PierListView = await _pierService.ReadAll() };

            ToastMessageShow();

            return View("Pier", pierViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> CreatePier()
        {
            CreatePierViewModel viewModel = new CreatePierViewModel()
            { HarbourListView = await _harbourService.ReadAll() };

            return View("CreatePier", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePier(CreatePierViewModel createViewModel)
        {

            if (createViewModel.HarbourId != 0)
            { createViewModel.Harbour = await _harbourService.FindBy(createViewModel.HarbourId); }
            else
            { createViewModel.Harbour = null; }

            if (ModelState.IsValid)
            {
                await _pierService.Create(createViewModel);

                ToastMessageInput("success", "", "Brygga Skapad");

                return RedirectToAction("Pier");
            }
            else
            {
                createViewModel.HarbourListView = await _harbourService.ReadAll();

                return View("CreatePier", createViewModel);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPier(int id)
        {
            EditPierViewModel editViewModel = await _pierService.FindBy(id);

             if (editViewModel.Harbour != null)
            { editViewModel.HarbourId = editViewModel.Harbour.Id; }
            else
            { editViewModel.HarbourId = 0; }

            editViewModel.HarbourListView = await _harbourService.ReadAll();

            return View("EditPier", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPierSave(EditPierViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (createViewModel.HarbourId != 0)
                {
                    createViewModel.Harbour = await _harbourService.FindBy(createViewModel.HarbourId);
                }
                else
                { createViewModel.Harbour = null; }

                await _pierService.Update(createViewModel);

                ToastMessageInput("success", "", "Editering Sparad");

                return RedirectToAction("Pier");
            }

            return View("EditPier", createViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePier(int id)
        {
            await _pierService.Remove(id);

            ToastMessageInput("success", "", "Brygga Raderad");

            return RedirectToAction("Pier");
        }




        // ************* END Pier Actions *************

        // ----------

        // ************* START Boatslip Actions *************


        public async Task<IActionResult> Boatslip(string sortFilter)
            //string currentFilter,
            //string searchString,
            //string showHideButtonText,
            //int? pageNumber)
        {
            List<Boatslip> boatslips = await _boatslipService.ReadAll();

            BoatslipViewModel viewModel = new BoatslipViewModel()
            { BoatslipListView = new List<Boatslip_DTO>() };

            foreach (Boatslip_DTO boatslip in boatslips)
            {
                if(boatslip.BoatDataIdRef != 0)
                {
                    boatslip.BoatData = await _boatDataService.FindBy(boatslip.BoatDataIdRef);
                }
                viewModel.BoatslipListView.Add(boatslip);
            }

            viewModel.BoatslipListView = SortFilterBoatslip(viewModel.BoatslipListView, sortFilter);

            ToastMessageShow();

            return View("Boatslip", viewModel);
        }


        public List<Boatslip_DTO> SortFilterBoatslip(List<Boatslip_DTO> boatslipList, string sortFilter)
        {
            ViewBag.BoatslipLabelSortParm = String.IsNullOrEmpty(sortFilter) ? "label_desc" : "";
            //ViewBag.BoatslipBoatDataSortParm = sortFilter == "Boat" ? "boat_desc" : "Boat";
            ViewBag.BoatslipFreeBoatslipParm = String.IsNullOrEmpty(sortFilter) ? "FreeBoatslip" : "";

            IEnumerable<Boatslip_DTO> IEnumList = boatslipList;

            ViewBag.ButtonShowFreeBoatslip = "Visa Lediga Platser";

            switch (sortFilter)
            {
                case "label_desc":
                    IEnumList =
                        boatslipList.OrderByDescending(s => s.Label);
                    break;
                //case "Boat":
                //    IEnumList =
                //        boatslipList.OrderBy(s => s.BoatData);
                //    break;
                //case "boat_desc":
                //    IEnumList =
                //        boatslipList.OrderByDescending(s => s.BoatData);
                //    break;
                case "FreeBoatslip":
                    IEnumList =
                        boatslipList
                        .Where(s => s.BoatDataIdRef == 0)
                        .OrderBy(s => s.Label);

                    ViewBag.ButtonShowFreeBoatslip = "Visa Alla Platser";
                    break;
                default:
                    IEnumList =
                        boatslipList.OrderBy(s => s.Label);
                    break;
            }

            return IEnumList.ToList();
        }


        [HttpGet]
        public async Task<IActionResult> CreateBoatslip()
        {
            CreateBoatslipViewModel viewModel = new CreateBoatslipViewModel()
            {
                PierListView = await _pierService.ReadAll(),
                ServiceTypeListView = await _serviceTypeService.ReadAllForType("boatslip"),
                MooringTypeListView = await _mooringTypeService.ReadAll()
            };

            return View("CreateBoatslip", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBoatslip(CreateBoatslipViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (createViewModel.PierId != 0) // 0 = no Pier is selected
                { createViewModel.Pier = await _pierService.FindBy(createViewModel.PierId); }
                else
                { createViewModel.Pier = null; }

                if (createViewModel.ServiceTypeId != 0) // 0 = no Pier is selected
                { createViewModel.ServiceType = await _serviceTypeService.FindBy(createViewModel.ServiceTypeId); }
                else
                { createViewModel.ServiceType = null; }

                if (createViewModel.MooringTypeId != 0) // 0 = no MooringType is selected
                { createViewModel.MooringType = await _mooringTypeService.FindBy(createViewModel.MooringTypeId); }
                else
                { createViewModel.MooringType = null; }

                await _boatslipService.Create(createViewModel);

                ToastMessageInput("success", "", "Båtplats Skapad");

                return RedirectToAction("Boatslip");
            }
            else
            {
                return View("CreateBoatslip", createViewModel);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBoatslip(int id)
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

            editViewModel.JsonServiceTypeListView = JsonConvert.SerializeObject(editViewModel.ServiceTypeListView);
            //    JsonConvert.SerializeObject(editViewModel.ServiceTypeListView, Formatting.Indented);
            //Debug.WriteLine(editViewModel.JsonServiceTypeListView);
            //var json = JsonConvert.SerializeObject(aList);
            // JsonConvert.SerializeObject(editViewModel.ServiceTypeListView, Formatting.Indented);


            editViewModel.MooringTypeListView = await _mooringTypeService.ReadAll();
            editViewModel.PierListView = await _pierService.ReadAll();
            editViewModel.BoatDataListView = await _boatDataService.ReadAll();

            return View("EditBoatslip", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBoatslipSave(EditBoatslipViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (editViewModel.ServiceTypeId > 0)
                {
                    editViewModel.ServiceType =
                          await _serviceTypeService.FindBy(editViewModel.ServiceTypeId);
                }
                else
                { editViewModel.ServiceType = null; }

                if (editViewModel.MooringTypeId > 0)
                { editViewModel.MooringType =
                        await _mooringTypeService.FindBy(editViewModel.MooringTypeId); }
                else
                { editViewModel.MooringType = null; }

                if (editViewModel.PierId > 0)
                { editViewModel.Pier = await _pierService.FindBy(editViewModel.PierId); }
                else
                { editViewModel.Pier = null; }

                if (editViewModel.BoatDataId > 0)
                { editViewModel.BoatDataIdRef = editViewModel.BoatDataId; }
                else
                { editViewModel.BoatDataIdRef = 0; }

                int writtenResult = await _boatslipService.Update(editViewModel);


                if (writtenResult > 0 && editViewModel.BoatDataIdRef != editViewModel.BoatDataIdThatWas)
                {
                    BoatData boatData = new BoatData();

                    if (editViewModel.BoatDataIdRef > 0)
                    {
                        boatData = await _boatDataService.FindBy(editViewModel.BoatDataIdRef);
                        boatData.Boatslip = await _boatslipService.FindBy(editViewModel.Id);
                    }
                    else if (editViewModel.BoatDataIdRef == 0)
                    {
                        boatData = await _boatDataService.FindBy(editViewModel.BoatDataIdThatWas);
                        boatData.Boatslip = null;
                    }

                    await _boatDataService.Update(boatData);

                    await AddInServiceHistory(boatData.Id, editViewModel.ServiceType.Id, editViewModel.Id, 0);
                }


                ToastMessageInput("success", "", "Båtplats-editering Sparad");

                return RedirectToAction("Boatslip");
            }

            editViewModel.ServiceTypeListView = await _serviceTypeService.ReadAllForType("boatslip");
            editViewModel.MooringTypeListView = await _mooringTypeService.ReadAll();
            editViewModel.PierListView = await _pierService.ReadAll();
            editViewModel.BoatDataListView = await _boatDataService.ReadAll();

            return View("EditBoatslip", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBoatslip(int id)
        {
            await _boatslipService.Remove(id);

            ToastMessageInput("success", "", "Båtplats Raderad");

            return RedirectToAction("Boatslip");
        }

        // ************* END Boatslip Actions *************

        // ----------


        // ************* START MooringType Actions *************

        public async Task<IActionResult> MooringType()
        {
            MooringTypeViewModel viewModel = new MooringTypeViewModel()
            { MooringTypeListView = await _mooringTypeService.ReadAll() };

            ToastMessageShow();

            return View("MooringType", viewModel);
        }



        [HttpGet]
        public IActionResult CreateMooringType()
        {
            return View("CreateMooringType");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMooringType(CreateMooringTypeViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                await _mooringTypeService.Create(createViewModel);

                ToastMessageInput("success", "", "FörtöjningsTyp Skapad");

                return RedirectToAction("MooringType");
            }
            else
            {
                return View("CreateMooringType", createViewModel);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMooringType(int id)
        {
            EditMooringTypeViewModel editViewModel = await _mooringTypeService.FindBy(id);

            return View("EditMooringType", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMooringTypeSave(EditMooringTypeViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                await _mooringTypeService.Update(createViewModel);

                ToastMessageInput("success", "", "Editering Sparad");

                return RedirectToAction("MooringType");
            }

            return View("EditMooringType", createViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMooringType(int id)
        {
            await _mooringTypeService.Remove(id);

            ToastMessageInput("success", "", "FörtöjningsTyp Raderad");

            return RedirectToAction("MooringType");
        }

        // ************* END MooringType Actions *************

        // ----------



        // ************* START BoatData Actions *************


        public async Task<IActionResult> BoatData(string sortOrder)
        {
            BoatDataViewModel viewModel = new BoatDataViewModel()
            { BoatDataListView = await _boatDataService.ReadAll() };

            ToastMessageShow();

            return View("BoatData", viewModel);
        }


        [HttpGet]
        public IActionResult CreateBoatData()
        {
            return View("CreateBoatData");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBoatData(CreateBoatDataViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.Customer = await _userManager.GetUserAsync(User);

                if (createViewModel.Customer != null)
                { 
                    createViewModel.CustomerId = createViewModel.Customer.Id;
                }

                createViewModel.CreatedDate = DateTime.Now;

                await _boatDataService.Create(createViewModel);

                ToastMessageInput("success", "", "Båt Skapad");

                return RedirectToAction("BoatData");
            }
            else
            {
                return View("CreateBoatData", createViewModel);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBoatData(int id)
        {
            EditBoatDataViewModel objFromDb = await _boatDataService.FindBy(id);

            return View("EditBoatData", objFromDb);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBoatDataSave(EditBoatDataViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.UpdatedDate = DateTime.Now;

                await _boatDataService.Update(createViewModel);

                ToastMessageInput("success", "", "Editering Sparad");

                return RedirectToAction("BoatData");
            }

            return View("EditBoatData", createViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBoatData(int id)
        {
            await _boatDataService.Remove(id);

            ToastMessageInput("success", "", "Båt Raderad");

            return RedirectToAction("BoatData");
        }



        // ************* END BoatData Actions *************

        // ----------


        // ************* START WinterStoreSpots Actions *************

        public async Task<IActionResult> WinterstoreSpot()
        {
            List<WinterstoreSpot> listFromDb = await _winterstoreSpotService.ReadAll();

            WinterstoreSpotViewModel viewModel = new WinterstoreSpotViewModel()
            {
                WinterstoreSpotListView = new List<WinterstoreSpot_DTO>(),
                ServiceType = new ServiceType(),
                ServiceTypeListView = new List<ServiceType>()
            };

            foreach (WinterstoreSpot spotObj in listFromDb)
            {
                WinterstoreSpot_DTO spot_DTO = spotObj;
                spot_DTO.BoatData = await _boatDataService.FindBy(spotObj.BoatDataIdRef);

                viewModel.WinterstoreSpotListView.Add(spot_DTO);
            }


            if (viewModel.WinterstoreSpotListView.Count != 0)
            {
                decimal totalm2In = 0;
                decimal totalm2Out = 0;

                foreach (WinterstoreSpot_DTO item in viewModel.WinterstoreSpotListView)
                {
                    if (item.ServiceType != null)
                    {
                        if (item.ServiceType.ArtNr == 5410)
                        {
                            totalm2In += item.SpotM2;

                            //viewModel.ServiceTypeListView.Add(item.ServiceType);
                        }

                        if (item.ServiceType.ArtNr == 5420)
                        {
                            totalm2Out += item.SpotM2;

                            //viewModel.ServiceTypeListView.Add(item.ServiceType);
                        }
                    }      
                }

                viewModel.Totalm2RentoutIndoors = totalm2In.ToString("F", CultureInfo.InvariantCulture);
                viewModel.Totalm2RentoutOutdoors = totalm2Out.ToString("F", CultureInfo.InvariantCulture);
            }

            ToastMessageShow();

            return View("WinterstoreSpot", viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> CreateWinterstoreSpot()
        {
            CreateWinterstoreSpotViewModel viewModel = new CreateWinterstoreSpotViewModel()
            { ServiceTypeListView = await _serviceTypeService.ReadAllForType("winterstorein") };

            foreach (var serviceType in await _serviceTypeService.ReadAllForType("winterstoreout"))
            { viewModel.ServiceTypeListView.Add(serviceType); }

            return View("CreateWinterstoreSpot", viewModel);
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWinterstoreSpot(CreateWinterstoreSpotViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.ServiceType = await _serviceTypeService.FindBy(createViewModel.ServiceTypeId);

                createViewModel.SpotM2 = createViewModel.Length * createViewModel.Width;

                await _winterstoreSpotService.Create(createViewModel);

                ToastMessageInput("success", "", "VinterförvaringsPlats Skapad");

                return RedirectToAction("WinterstoreSpot");
            }
            else
            {
                return View("CreateWinterstoreSpot", createViewModel);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWinterstoreSpot(int id)
        {
            EditWinterstoreSpotViewModel editViewModel = await _winterstoreSpotService.FindBy(id);

            if (editViewModel.ServiceType != null)
            { editViewModel.ServiceTypeId = editViewModel.ServiceType.Id; }
            else
            { editViewModel.ServiceTypeId = 0; }


            editViewModel.ServiceTypeListView = await _serviceTypeService.ReadAllForType("winterstorein");

            foreach (var serviceType in await _serviceTypeService.ReadAllForType("winterstoreout"))
            { editViewModel.ServiceTypeListView.Add(serviceType); }

            return View("EditWinterstoreSpot", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWinterstoreSpotSave(EditWinterstoreSpotViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                editViewModel.ServiceType = await _serviceTypeService.FindBy(editViewModel.ServiceTypeId);

                editViewModel.SpotM2 = editViewModel.Length * editViewModel.Width;

                await _winterstoreSpotService.Update(editViewModel);

                ToastMessageInput("success", "", "Editering Sparad");

                return RedirectToAction("WinterstoreSpot");
            }

            return View("EditWinterstoreSpot", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWinterstoreSpot(int id)
        {
            await _winterstoreSpotService.Remove(id);

            ToastMessageInput("success", "", "VinterförvaringsPlats Raderad");

            return RedirectToAction("WinterstoreSpot");
        }



        // ************* END WinterStoreSpots Actions *************

        // ----------



        // ************* START Show Customer Actions *************

       public IActionResult Blappserv() // This gives the startview for BlazorServer, so i have same layoutadmin for it
        {
            return View("Blappserv");
        }


        //public IActionResult Customer()
        //{
        //IList<IdentityAppUser> userlistFromDB = await _userManager.GetUsersInRoleAsync("User");

        //CustomerListViewModel customerListViewModel = new CustomerListViewModel()
        //{ CustomerAllInfoListView = new List<CustomerAllInfoDTO>() };

        //foreach (IdentityAppUser customer in userlistFromDB)
        //{
        //    CustomerAllInfoDTO customerAllInfo = customer;

        //    customerAllInfo.BoatDatas = new List<BoatDataDTO>();
        //    List<BoatData> boatDataList = await _boatDataService.ReadAllForCurrentUser(customer.UserName);
        //    foreach (BoatData boatData in boatDataList)
        //    {
        //        customerAllInfo.BoatDatas.Add(boatData);
        //    }
        //    //customerAllInfo.BoatDataDTOs = await _boatDataService.ReadAllForCurrentUser(customer.UserName);
        //    customerAllInfo.BoatslipsAmount = 0;
        //    customerAllInfo.WinterstoreAmount = 0;
        //    customerAllInfo.BoatsAmount = customerAllInfo.BoatDatas.Count;


        //    foreach (BoatDataDTO boatData in customerAllInfo.BoatDatas)
        //    {
        //        if(boatData.Boatslip != null)
        //        { customerAllInfo.BoatslipsAmount++; }
        //        if (boatData.WinterstoreSpot != null)
        //        { customerAllInfo.WinterstoreAmount++; }
        //    }

        //    customerListViewModel.CustomerAllInfoListView.Add(customerAllInfo);
        //}

        //    ToastMessageShow();

        //    //return View("Customer"); //, customerListViewModel);
        //    return Redirect($"https://{Request.Host.Value}/Customer");
        //}


        //[HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageCustomer(string id, string partialView = "")
        {
            IdentityAppUser customer = await _userManager.FindByNameAsync(id);

            CustomerAllInfoDTO customerAllInfo = customer;

            customerAllInfo.BoatDatas = new List<BoatDataDTO>();
            List<BoatData> boatDataList = await _boatDataService.ReadAllForCurrentUser(customer.UserName);
            foreach (BoatData boatData in boatDataList)
            {
                customerAllInfo.BoatDatas.Add(boatData);
            }
            //customerAllInfoDTO.BoatDataDTOs = await _boatDataService.ReadAllForCurrentUser(id);
            //customerAllInfoDTO.BoatsAmount = customerAllInfoDTO.BoatDatas.Count;


            ManageCustomerViewModel viewModel = new ManageCustomerViewModel()
            {
                //CustomerAllInfo = customerAllInfoDTO,
                CustomerAllInfo = customerAllInfo,
                FreeBoatslips = await _boatslipService.ReadAllEmpty(),
                BoatData = new BoatData()
                //FreeWinterstoreSpotsOut = await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstoreout"),
                //FreeWinterstoreSpotsIn = await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstorein")
            };
            

            ToastMessageShow();

            return View("ManageCustomer", viewModel);
        }


        //[HttpGet]
        //[Route("api/ManageCustomer/GetCustomer")]
        //public async Task<IActionResult> ManageCustomerBlazor(string id)
        //{
        //    IdentityAppUser customer = await _userManager.FindByNameAsync(id);

        //    CustomerAllInfoDTO customerAllInfoDTO = customer;
        //    customerAllInfoDTO.BoatDatas = await _boatDataService.ReadAllForCurrentUser(id);
        //    //customerAllInfoDTO.BoatsAmount = customerAllInfoDTO.BoatDatas.Count;


        //    ManageCustomerViewModel viewModel = new ManageCustomerViewModel()
        //    {
        //        //CustomerAllInfo = customerAllInfoDTO,
        //        CustomerAllInfo = customerAllInfoDTO,
        //        FreeBoatslips = await _boatslipService.ReadAllEmpty(),
        //        BoatData = new BoatData()
        //        //FreeWinterstoreSpotsOut = await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstoreout"),
        //        //FreeWinterstoreSpotsIn = await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstorein")
        //    };


        //    //ToastMessageShow();

        //    return viewModel;
        //}



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBoatslipForSelectedBoat(int id)
        {
            BoatData boatData = await _boatDataService.FindBy(id);
            Boatslip boatslip = await _boatslipService.FindBy(boatData.Boatslip.Id);

            await AddInServiceHistory(id, boatData.Boatslip.ServiceType.Id, boatData.Boatslip.Id, 0 );

            boatData.Boatslip = null;
            await _boatDataService.Update(boatData);

            boatslip.BoatDataIdRef = 0;
            boatslip.UpdatedDate = DateTime.Now;
            await _boatslipService.Update(boatslip);

            ToastMessageInput("success", "", $"BåtPlats Borttagen för {boatData.Label}");

            return RedirectToAction("ManageCustomer", new { id = boatData.Customer.UserName });
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageCustomerSaveAssignedBoatslip(ManageCustomerViewModel viewModel)
        {
            BoatData boatData = await _boatDataService.FindBy(viewModel.SelectedBoatDataId);
            if (boatData.Boatslip != null)
            {
                boatData.Boatslip.BoatDataIdRef = 0;
                await _boatslipService.Update(boatData.Boatslip);
            }

            Boatslip boatslip = await _boatslipService.FindBy(viewModel.SelectedBoatslipId);
            boatslip.BoatDataIdRef = viewModel.SelectedBoatDataId;
            boatData.Boatslip = boatslip;

            await _boatDataService.Update(boatData);

            await AddInServiceHistory(boatData.Id, boatslip.ServiceType.Id, boatslip.Id, 0);

            ToastMessageInput("success", "",
                    $"Båten {boatData.Label}, har fått BåtPlats {boatslip.Label} på {boatslip.Pier.Label}");

                return RedirectToAction("ManageCustomer", new { id = boatData.Customer.UserName });
        }



        [HttpPost]
        public async Task<PartialViewResult> CustomerBoatInfoPartial(int id)
        {
            ManageCustomerViewModel viewModel = new ManageCustomerViewModel()
            {
                SelectedBoatDataId = id,
                BoatData = await _boatDataService.FindBy(id),
                FreeBoatslips = await _boatslipService.ReadAllEmpty()
            };

            return PartialView("_ManageC_BoatInfo_SubManage_Partial", viewModel);
        }


        [HttpPost]
        public async Task<PartialViewResult> CustomerBoatWinterspotPartial(int id)
        {
            //BoatData.boatData = await _boatDataService.FindBy(id);
            ManageCustomerViewModel viewModel = new ManageCustomerViewModel()
            {
                SelectedBoatDataId = id,
                BoatData = await _boatDataService.FindBy(id),
                FreeWinterstoreSpots = await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstorein"),
            };

            foreach (WinterstoreSpot winterstoreout in await _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType("winterstoreout"))
            {
                viewModel.FreeWinterstoreSpots.Add(winterstoreout);
            }

            viewModel.FreeWinterstoreSpots = viewModel.FreeWinterstoreSpots.OrderBy(x => x.Label).ToList();

            return PartialView("_ManageC_BoatInfo_WinterSpot_Partial", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageCustomerSaveAssignedWinterstore(ManageCustomerViewModel viewModel)
        {
            BoatData boatData = await _boatDataService.FindBy(viewModel.SelectedBoatDataId);
            if(boatData.WinterstoreSpot != null)
            {
                boatData.WinterstoreSpot.BoatDataIdRef = 0;
                await _winterstoreSpotService.Update(boatData.WinterstoreSpot);
            }

            WinterstoreSpot winterstore = await _winterstoreSpotService.FindBy(viewModel.WinterstoreSpotId);
            winterstore.BoatDataIdRef = viewModel.SelectedBoatDataId;
            boatData.WinterstoreSpot = winterstore;

            await _boatDataService.Update(boatData);

            await AddInServiceHistory(boatData.Id, winterstore.ServiceType.Id, winterstore.Id, 0);

            ToastMessageInput("success", "",
                    $"Båten {boatData.Label}, har fått VinterPlats {winterstore.Label} som är {winterstore.ServiceType.Label}");

            return RedirectToAction("ManageCustomer", new { id = boatData.Customer.UserName });
        }


        public async Task<IActionResult> CreateWinterstoreSpot_Partial(string id)
        {
            TempData["userName"] = id;

            CreateWinterstoreSpotViewModel viewModel = new CreateWinterstoreSpotViewModel()
            { ServiceTypeListView = await _serviceTypeService.ReadAllForType("winterstorein") };

            foreach (var serviceType in await _serviceTypeService.ReadAllForType("winterstoreout"))
            { viewModel.ServiceTypeListView.Add(serviceType); }

            return PartialView("_CreateWinterstoreSpot_Partial", viewModel);
        }


        public async Task<IActionResult> CreateWinterstoreSpotSave_Partial(CreateWinterstoreSpotViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.ServiceType = await _serviceTypeService.FindBy(createViewModel.ServiceTypeId);
                createViewModel.SpotM2 = createViewModel.Length * createViewModel.Width;

                await _winterstoreSpotService.Create(createViewModel);

                ToastMessageInput("success", "", "VinterförvaringsPlats Skapad");

                return RedirectToAction("ManageCustomer", new { id = TempData["userName"] });
            }
            else
            {
                //createWinterstoreSpot_PartialView
                //return PartialView("_CreateWinterstoreSpot_Partial", createViewModel);
                ToastMessageInput("error", "", "Något fylldes inte i korrekt! Vid skapande av vinterplats.");

                return RedirectToAction("ManageCustomer", new { id = TempData["userName"] });
            }

        }

        // ********* START - Build Customer DTO **********

        // Building up my Custom CustomerDTO (Data Transfer Object, or custom object)
        // IdentityAppUser + BoatData-list with/if any BoatData.Boatslip info
        //public async Task<CustomerAllInfoDTO> BuildCustomerDTO(IdentityAppUser user)
        //{
        //    CustomerAllInfoDTO buildCustomerObj = new CustomerAllInfoDTO()
        //    { BoatDatas = new List<BoatDataDTO>() };
        //    buildCustomerObj = user;

        //    List<BoatData> userBoatList = await _boatDataService.ReadAllForCurrentUser(user.Id);

        //    buildCustomerObj.BoatsAmount = userBoatList.Count;
        //    buildCustomerObj.BoatslipsAmount = 0;

        //    if (userBoatList.Count != 0)
        //    {
        //        List<Boatslip> userBoatslips = await _boatslipService.FindUserBoatslip(user.Id);

        //        buildCustomerObj.BoatslipsAmount = userBoatslips.Count;
        //        buildCustomerObj.BoatDatas = new List<BoatDataDTO>();

        //        foreach (BoatData boat in userBoatList)
        //        {
        //            BoatDataDTO boatDataDTO = new BoatDataDTO()
        //            {
        //                Boatslip = new Boatslip(),
        //                WinterstoreSpot = new WinterstoreSpot()
        //            };
        //            boatDataDTO = boat;

        //            if (userBoatslips.Count != 0)
        //            {
        //                boatDataDTO.Boatslip = userBoatslips.Find(p => p.BoatData.Id == boat.Id);
        //            }
        //            //Boatslip foundBoatslip = userBoatslips.Find(p => p.BoatData.Id == boat.Id);
        //            //if (foundBoatslip != null) { boatDataDTO.Boatslip = foundBoatslip; }
        //            //else { boatDataDTO.Boatslip = null; }


        //            buildCustomerObj.BoatDatas.Add(boatDataDTO);

        //        } // End foreach
        //    } // End if
        //    else
        //    {
        //        buildCustomerObj.BoatDatas = null;
        //    }

        //    return buildCustomerObj;
        //}

        // ********* END - Build Customer DTO **********





        // ************* END Customer Actions *************     

        // ----------



        // ************* START ServiceType Actions *************

        [HttpGet]
        public async Task<IActionResult> ServiceType(string sortFilter)
        {
            ServiceTypeViewModel viewModel = new ServiceTypeViewModel()
            { ServiceTypeListView = await _serviceTypeService.ReadAll() };

            viewModel.ServiceTypeListView = SortFilterServiceType(viewModel.ServiceTypeListView, sortFilter);

            ToastMessageShow();

            return View("ServiceType", viewModel);
        }


        public List<ServiceType> SortFilterServiceType(List<ServiceType> serviceTypeList, string sortFilter)
        {
            ViewBag.ServiceTypeArtNrSortParm = String.IsNullOrEmpty(sortFilter) ? "artNr_desc" : "";
            //ViewBag.BoatDataSortParm = sortFilter == "Boat" ? "boat_desc" : "Boat";
            //ViewBag.FreeBoatslipParm = String.IsNullOrEmpty(sortFilter) ? "FreeBoatslip" : "";

            IEnumerable<ServiceType> IEnumList = serviceTypeList;

            //ViewBag.ShowHideFree = "Visa Lediga Platser";

            switch (sortFilter)
            {
                case "artNr_desc":
                    IEnumList =
                        serviceTypeList.OrderByDescending(s => s.ArtNr);
                    break;
                //case "Boat":
                //    IEnumList =
                //        serviceTypeList.OrderBy(s => s.ServiceType);
                //    break;
                //case "boat_desc":
                //    IEnumList =
                //        serviceTypeList.OrderByDescending(s => s.ServiceType);
                //    break;
                //case "FreeBoatslip":
                //    IEnumList =
                //        serviceTypeList
                //        .Where(s => s.ServiceType == null)
                //        .OrderBy(s => s.Label);

                //    ViewBag.ShowHideFree = "Visa Alla Platser";
                //    break;
                default:
                    IEnumList =
                        serviceTypeList.OrderBy(s => s.ArtNr);
                    break;
            }

            return IEnumList.ToList();
        }


        [HttpGet]
        public IActionResult CreateServiceType()
        {
            return View("CreateServiceType");
        }


        public string CheckAndMakeSize(CreateServiceTypeViewModel createViewModel)
        {
            string newSize = "";

            if (createViewModel.Type == "boatslip")
            {
                newSize =
                        "Längd: " + createViewModel.Length + "m Bredd: " + createViewModel.Width +
                        "m Djup: " + createViewModel.Depth + "m";
            }
            else { newSize = ""; }

            return newSize;
        }


            [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateServiceType(CreateServiceTypeViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.Size = CheckAndMakeSize(createViewModel);

                await _serviceTypeService.Create(createViewModel);

                ToastMessageInput("success", "", "Tjänst Skapad");

                return RedirectToAction("ServiceType");
            }
            else
            {
                return View("CreateServiceType", createViewModel);
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServiceType(int id)
        {
            EditServiceTypeViewModel editViewModel = await _serviceTypeService.FindBy(id);

            return View("EditServiceType", editViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditServiceTypeSave(EditServiceTypeViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                editViewModel.Size = CheckAndMakeSize(editViewModel);

                await _serviceTypeService.Update(editViewModel);

                ToastMessageInput("success", "", "Editering Sparad");

                return RedirectToAction("ServiceType");
            }

            return View("EditServiceType", editViewModel);

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            await _serviceTypeService.Remove(id);

            ToastMessageInput("success", "", "Tjänst Raderad");

            return RedirectToAction("ServiceType");
        }


        // ************* END ServiceType Actions *************     

        // ----------



        // ************* START -  ServiceHistory Actions *************


        public async Task<IActionResult> AddInServiceHistory(
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

            return Ok();
        }




        // ************* END -  ServiceHistory Actions *************     


        // ----------




        // ************* START - ServiceApplication Actions *************

        [HttpGet]
        public async Task<IActionResult> ServiceApplications(string sortFilter)
        {
            ServiceApplicationViewModel viewModel = new ServiceApplicationViewModel()
            {
                ServiceApplicationListView = await _serviceApplicationService.ReadAll()
            };

            // Sort the list by ascending CreatedDate and send to view
            IEnumerable<ServiceApplication> IEnumList = viewModel.ServiceApplicationListView;
            IEnumList.OrderBy(s => s.CreatedDate);

            viewModel.ServiceApplicationListView = IEnumList.ToList();

            ToastMessageShow();

            return View("ServiceApplication", viewModel);
        }


        // ServiceApplicationQueue View
        [HttpGet]
        public async Task<IActionResult> ServiceApplicationQueue()
        {
            ServiceApplicationQueueViewModel viewModel = new ServiceApplicationQueueViewModel()
            {
                ServiceApplicationQueueListView = await _serviceApplicationService.ReadAllQueued()
            };

            // Sort the list by ascending UpdatedDate and send to view
            IEnumerable<ServiceApplication> IEnumList = viewModel.ServiceApplicationQueueListView;
            IEnumList.OrderBy(s => s.UpdatedDate);

            viewModel.ServiceApplicationQueueListView = IEnumList.ToList();

            ToastMessageShow();

            return View("ServiceApplicationQueue", viewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleUserServiceApplication(int id)
        {
            ManageServiceApplicationViewModel handleViewModel = await _serviceApplicationService.FindBy(id);
            handleViewModel.BoatDataId = handleViewModel.BoatData.Id;

            if(handleViewModel.Customer != null)
            {
                handleViewModel.CustomerId = handleViewModel.Customer.Id;
            }
            else if(handleViewModel.Applicant != null)
            { 
                handleViewModel.ApplicantId = handleViewModel.Applicant.Id;
            }

            handleViewModel.ServiceTypeId = handleViewModel.ServiceType.Id;

            switch (handleViewModel.ServiceType.Type)
            {
                case "boatslip":
                    handleViewModel.BoatslipListView = await _boatslipService.ReadAllEmpty();
                    break;

                case "winterstorein":
                case "winterstoreout":
                    handleViewModel.WinterstoreSpotListView = await
                        _winterstoreSpotService.ReadAllEmptyWinterstoreSpotByType(
                            handleViewModel.ServiceType.Type);
                    break;
            } // End switch

            return View("ManageServiceApplication", handleViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleUserServiceApplicationSave(ManageServiceApplicationViewModel handleViewModel)
        {
            if (ModelState.IsValid)
            {
                int tempBoatslipId = handleViewModel.BoatslipId,
                    tempWinterstoreSpotId = handleViewModel.WinterstoreSpotId,
                    tempServiceTypeId = handleViewModel.ServiceTypeId;

                handleViewModel = await _serviceApplicationService.FindBy(handleViewModel.Id);
                handleViewModel.ServiceTypeId = tempServiceTypeId;
                handleViewModel.ServiceType = await _serviceTypeService.FindBy(tempServiceTypeId);
                handleViewModel.BoatslipId = tempBoatslipId;
                handleViewModel.BoatDataId = handleViewModel.BoatData.Id;
                handleViewModel.WinterstoreSpotId = tempWinterstoreSpotId;

                switch (handleViewModel.ServiceType.Type)
                {
                    case "boatslip":
                        Boatslip boatslip =
                            await _boatslipService.FindBy(handleViewModel.BoatslipId);
                        handleViewModel.Boatslip = boatslip;

                        boatslip.BoatDataIdRef = handleViewModel.BoatData.Id;

                        await _boatslipService.Update(boatslip);
                        break;

                    case "winterstorein":
                    case "winterstoreout":
                        WinterstoreSpot winterstoreSpot =
                            await _winterstoreSpotService.FindBy(handleViewModel.WinterstoreSpotId);
                        handleViewModel.WinterstoreSpot = winterstoreSpot;

                        winterstoreSpot.BoatDataIdRef = handleViewModel.BoatData.Id;

                        await _winterstoreSpotService.Update(winterstoreSpot);
                        break;

                } // End switch

                CreateServiceHistory objCreate = new CreateServiceHistory()
                {
                    Customer = handleViewModel.Customer,
                    BoatData = handleViewModel.BoatData,
                    ServiceType = handleViewModel.ServiceType,
                    Boatslip = handleViewModel.Boatslip,
                    WinterstoreSpot = handleViewModel.WinterstoreSpot,
                    CreatedDate = DateTime.Now
                };
                
                await _serviceHistoryService.Create(objCreate);
                await _serviceApplicationService.Remove(handleViewModel.Id);

                ToastMessageInput("success", "", "Tilldelat och sparat");

                return RedirectToAction("ServiceApplications");

            } // End If
            else
            {
                return View("ManageServiceApplication", handleViewModel);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PutInQueueUserServiceApplication(int id)
        {
            ServiceApplication handleViewModel = new ServiceApplication();

            handleViewModel = await _serviceApplicationService.FindBy(id);

            handleViewModel.InQueue = 1;
            handleViewModel.UpdatedDate = DateTime.Now;

            await _serviceApplicationService.Update(handleViewModel);

            //ToastMessageInput("success", "", "TjänstAnsökan tillagd i KÖ-Listan");
            ToastMessageInput("success", "", $"TjänstAnsökan tillagd i KÖ-Listan"); //{howManyWritten.Result}");

            return RedirectToAction("ServiceApplications");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveInQueueUserServiceApplication(int id)
        {
            ServiceApplication handleViewModel = await _serviceApplicationService.FindBy(id);

            handleViewModel.InQueue = 0;
            handleViewModel.UpdatedDate = DateTime.Now;

            //Task<int> howManyWritten =
            await _serviceApplicationService.Update(handleViewModel);

            ToastMessageInput("success", "", "TjänstAnsökan Borttagen från KÖ-Listan");

            return RedirectToAction("ServiceApplicationQueue");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServiceApplication(int id)
        {
            ServiceApplication serviceApp = await _serviceApplicationService.FindBy(id);

            await _applicantService.Remove(serviceApp.Applicant.Id);
            serviceApp.Applicant = null;
            await _serviceApplicationService.Update(serviceApp);
            await _serviceApplicationService.Remove(id);

            ToastMessageInput("success", "", "Tjänst Raderad");

            return RedirectToAction("ServiceApplications");
        }



        // *** START *** Make account and boatdata from the Applicant
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccountForApplicant(int id)
        {
            ServiceApplication serviceApplication = await _serviceApplicationService.FindBy(id);

            Applicant applicant = await _applicantService.FindBy(serviceApplication.Applicant.Id);


            IdentityAppUser makeUser = new IdentityAppUser
            {
                UserName = applicant.Email,
                Email = applicant.Email,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                PhoneNumber = applicant.PhoneNumber,
                ExtraInfoTextarea = applicant.ExtraInfoTextarea
            };

            //hash the password before storing in db
            var hashit = new PasswordHasher<IdentityAppUser>();
            var result = await _userManager.CreateAsync(makeUser, "ChangeMePassword1788");

            if (result.Succeeded)
            {
                //_logger.LogInformation("User created a new account with password.");
                var assignRoleresult = await _userManager.AddToRoleAsync(makeUser, "User");
            }

            if (!result.Succeeded)
            {
                var why = result.Errors;
                ToastMessageInput("error", "", $"Kunde inte skapa själva kontot. {why}");

                return RedirectToAction("ServiceApplications");
            }


            IdentityAppUser justCreatedUser = await _userManager.FindByNameAsync(applicant.Email);

            BoatData createdBoatData = new BoatData()
            {
                BrandModel = applicant.BrandModel,
                Length = applicant.Length,
                Width = applicant.Width,
                Depth = applicant.Depth,
                CreatedDate = DateTime.Now,
                Customer = justCreatedUser,
                Label = applicant.Email + " Båt nr1"
            };

            await _boatDataService.Create(createdBoatData);

            serviceApplication.Customer = justCreatedUser;
            serviceApplication.BoatData = await _boatDataService.FindByCustomerUserName(justCreatedUser.UserName);

            await _applicantService.Remove(serviceApplication.Applicant.Id);

            serviceApplication.Applicant = null;

            await _serviceApplicationService.Update(serviceApplication);

            ToastMessageInput("success", "", "Kundkonto och Båtinfo Skapat och Sparat. Ansökan uppdaterad.");

            return RedirectToAction("ServiceApplications");
        }
        // *** END *** Make account and boatdata from the Applicant



        // ************* END ServiceApplication Actions *************     

        // ----------


        // ---- START ---  Extra Methods To keep code DRY (Dont Repeat yourself)

        //public async Task<CreateServiceHistory> CreateSaveServiceHistory(int id)
        //{
        //    CreateServiceHistory objCreate = new CreateServiceHistory()
        //{
        //    Customer = handleViewModel.Customer,
        //    BoatData = handleViewModel.BoatData,
        //    ServiceType = handleViewModel.ServiceType,
        //    Boatslip = handleViewModel.Boatslip,
        //    WinterstoreSpot = handleViewModel.WinterstoreSpot,
        //    CreatedDate = DateTime.Now
        //};

        //await _serviceHistoryService.Create(objCreate);


        // ---- END ---  Extra Methods To keep code DRY (Dont Repeat yourself)

        // ---------



        // ---------------  Special Actions below ---------------


        public IActionResult AccessDenied()
        {
            return View("_AccessDenied");
        }





        // -------------- Normal "Non-Action" Methods -------------------





            // ---  ToastMessage Handler and show


            public void ToastMessageShow()
        {
            if (TempData["ToastMessage"] != null) // If message is set. Set ViewBags, for display in views 
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
