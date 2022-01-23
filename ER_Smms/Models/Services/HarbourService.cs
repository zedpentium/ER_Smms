using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models.Interfaces;
using ER_Smms.Models.ViewModels;
using ER_Smms.Models;

namespace ER_Smms.Models.Services
{
    public class HarbourService : IHarbourService
    {
        private readonly IHarbourRepo _harbourRepo;

        public HarbourService(IHarbourRepo harbourRepo)
        {
            _harbourRepo = harbourRepo;
        }


        public string Create(CreateHarbourViewModel viewModel)
        {
            Harbour remapViewToObj = new Harbour()
            { Label = viewModel.Label, Info = viewModel.Info };
                
            string createHarbourResultMessage = _harbourRepo.Create(remapViewToObj);

            return createHarbourResultMessage;
        }

        public HarbourViewModel ReadAll()
        {
            HarbourViewModel harbourViewMod = new HarbourViewModel() { HarbourListView = _harbourRepo.ReadAll() };

            return harbourViewMod;
        }

        public string Update(Harbour harbour)
        {
            string updateHarbourResultMessage = _harbourRepo.Update(harbour);

            return updateHarbourResultMessage;
        }

        //public HarbourViewModel FindBy(HarbourViewModel search)
        //{
        //    throw new NotImplementedException();
        //}

        public Harbour FindBy(int id)
        {
            Harbour foundHarbour = _harbourRepo.Read(id);

            return foundHarbour;
        }

        public bool Remove(int id)
        {
            Harbour harbourToDelete = _harbourRepo.Read(id);
            bool success = _harbourRepo.Delete(harbourToDelete);

            return success;
        }

    }


}
