using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models.ViewModels.Admin
{
    public class CreateServiceHistory : DateCreatedEdited
    {
        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator ServiceHistory(CreateServiceHistory viewModel)
        {
            return new ServiceHistory
            {
                Customer = viewModel.Customer,
                BoatData = viewModel.BoatData,
                ServiceType = viewModel.ServiceType,
                Boatslip = viewModel.Boatslip,
                WinterstoreSpot = viewModel.WinterstoreSpot,
                CreatedDate = viewModel.CreatedDate
            };
        }


        public IdentityAppUser Customer { get; set; }

        public BoatData BoatData { get; set; }

        public ServiceType ServiceType { get; set; }

        public Boatslip Boatslip { get; set; }

        public WinterstoreSpot WinterstoreSpot { get; set; }
}

}
