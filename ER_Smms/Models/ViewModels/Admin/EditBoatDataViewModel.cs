using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class EditBoatDataViewModel : CreateBoatDataViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator EditBoatDataViewModel(BoatData obj)
        {
            return new EditBoatDataViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                BrandModel = obj.BrandModel,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth,
                Weight = obj.Weight,
                Height = obj.Height,
                HaveInsurance = obj.HaveInsurance,
                CreatedDate = obj.CreatedDate,
                UpdatedDate = obj.UpdatedDate
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator BoatData(EditBoatDataViewModel viewModel)
        {
            return new BoatData
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                BrandModel = viewModel.BrandModel,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Depth = viewModel.Depth,
                Weight = viewModel.Weight,
                Height = viewModel.Height,
                HaveInsurance = viewModel.HaveInsurance,
                CreatedDate = viewModel.CreatedDate,
                UpdatedDate = viewModel.UpdatedDate
            };
        }


    }
}
