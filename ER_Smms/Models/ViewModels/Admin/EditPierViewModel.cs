using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class EditPierViewModel : CreatePierViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator EditPierViewModel(Pier obj)
        {
            return new EditPierViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Info = obj.Info,
                Harbour = obj.Harbour
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator Pier(EditPierViewModel viewModel)
        {
            return new Pier
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                Info = viewModel.Info,
                Harbour = viewModel.Harbour
            };
        }

    }
}
