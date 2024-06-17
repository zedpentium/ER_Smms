using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Frontend
{

    public class UserEditBoatDataViewModel : UserCreateBoatDataViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator UserEditBoatDataViewModel(BoatData obj)
        {
            return new UserEditBoatDataViewModel
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
                UpdatedDate = obj.UpdatedDate,
                Customer = obj.Customer
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator BoatData(UserEditBoatDataViewModel viewModel)
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
                UpdatedDate = viewModel.UpdatedDate,
                Customer = viewModel.Customer
            };
        }


    }
}
