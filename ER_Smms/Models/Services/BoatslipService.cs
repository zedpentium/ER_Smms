using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models;

namespace ER_Smms.Models.Services
{
    public class BoatslipService : IBoatslipService
    {
        private readonly IBoatslipRepo _boatslipRepo;

        public BoatslipService(IBoatslipRepo boatslipRepo)
        {
            _boatslipRepo = boatslipRepo;
        }


        public string Create(CreateBoatslipViewModel viewModel, Pier selectedObj)
        {
            Boatslip remapViewToObj = new Boatslip(
                viewModel.Label, viewModel.Lenght, viewModel.Width,
                viewModel.Depth, viewModel.MooringType);

            string createResultMessage = _boatslipRepo.Create(remapViewToObj, selectedObj);

            return createResultMessage;
        }

        public BoatslipViewModel ReadAll()
        {
            BoatslipViewModel listView = new BoatslipViewModel()
            { BoatslipListView = _boatslipRepo.ReadAll() };

            return listView;
        }

        public string Update(Boatslip boatslip)
        {
            string updateResultMessage = _boatslipRepo.Update(boatslip);

            return updateResultMessage;
        }


        public Boatslip FindBy(int id)
        {
            Boatslip foundObj = _boatslipRepo.Read(id);

            return foundObj;
        }

        public bool Remove(int id)
        {
            Boatslip objToDelete = _boatslipRepo.Read(id);
            bool success = _boatslipRepo.Delete(objToDelete);

            return success;
        }

    }


}
