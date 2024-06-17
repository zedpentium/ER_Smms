using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class EditHarbourViewModel : CreateHarbourViewModel
    {

        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator EditHarbourViewModel(Harbour obj)
        {
            return new EditHarbourViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Info = obj.Info
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator Harbour(EditHarbourViewModel viewModel)
        {
            return new Harbour
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                Info = viewModel.Info
            };
        }

    }
}
