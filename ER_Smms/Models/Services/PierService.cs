using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models;

namespace ER_Smms.Models.Services
{
    public class PierService : IPierService
    {
        private readonly IPierRepo _pierRepo;

        public PierService(IPierRepo pierRepo)
        {
            _pierRepo = pierRepo;
        }


        public string Create(CreatePierViewModel viewModel, Harbour selectedObj)
        {

            Pier remapViewToObj = new Pier(viewModel.Label, viewModel.Info);

            string createResultMessage = _pierRepo.Create(remapViewToObj, selectedObj);

            return createResultMessage;
        }

        public PierViewModel ReadAll()
        {
            PierViewModel listView = new PierViewModel() { PierListView = _pierRepo.ReadAll() };

            return listView;
        }

        public string Update(Pier pier)
        {
            string updateResultMessage = _pierRepo.Update(pier);

            return updateResultMessage;
        }


        public Pier FindBy(int id)
        {
            Pier foundObj = _pierRepo.Read(id);

            return foundObj;
        }

        public bool Remove(int id)
        {
            Pier objToDelete = _pierRepo.Read(id);
            bool success = _pierRepo.Delete(objToDelete);

            return success;
        }

    }


}
