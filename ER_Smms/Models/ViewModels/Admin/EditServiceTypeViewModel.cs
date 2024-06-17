using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class EditServiceTypeViewModel : CreateServiceTypeViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator EditServiceTypeViewModel(ServiceType obj)
        {
            return new EditServiceTypeViewModel
            {
                Id = obj.Id,
                ArtNr = obj.ArtNr,
                Type = obj.Type,
                Label = obj.Label,
                Size = obj.Size,
                Price = obj.Price,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator ServiceType(EditServiceTypeViewModel viewModel)
        {
            return new ServiceType
            {
                Id = viewModel.Id,
                ArtNr = viewModel.ArtNr,
                Type = viewModel.Type,
                Label = viewModel.Label,
                Size = viewModel.Size,
                Price = viewModel.Price,
                Length= viewModel.Length,
                Width= viewModel.Width,
                Depth= viewModel.Depth
            };
        }


    }
}
