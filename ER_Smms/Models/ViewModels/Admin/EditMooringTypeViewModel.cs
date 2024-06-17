using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class EditMooringTypeViewModel : CreateMooringTypeViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator EditMooringTypeViewModel(MooringType obj)
        {
            return new EditMooringTypeViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Info = obj.Info
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator MooringType(EditMooringTypeViewModel viewModel)
        {
            return new MooringType
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                Info = viewModel.Info
            };
        }


    }
}
