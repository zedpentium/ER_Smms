using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class EditWinterstoreSpotViewModel : CreateWinterstoreSpotViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator EditWinterstoreSpotViewModel(WinterstoreSpot obj)
        {
            return new EditWinterstoreSpotViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Length = obj.Length,
                Width = obj.Width,
                Height = obj.Height,
                SpotM2 = obj.SpotM2,
                SpotPrice = obj.SpotM2 * obj.ServiceType.Price,
                ServiceType = obj.ServiceType
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator WinterstoreSpot(EditWinterstoreSpotViewModel viewModel)
        {
            return new WinterstoreSpot
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Height = viewModel.Height,
                SpotM2 = viewModel.SpotM2,
                ServiceType = viewModel.ServiceType
            };
        }


    }
}
