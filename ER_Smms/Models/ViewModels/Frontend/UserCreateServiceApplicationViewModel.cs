using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Frontend
{

    public class UserCreateServiceApplicationViewModel : DateCreatedEdited
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator UserCreateServiceApplicationViewModel(ServiceApplication obj)
        {
            return new UserCreateServiceApplicationViewModel
            {
                Customer = obj.Customer,
                BoatData = obj.BoatData,
                ServiceType = obj.ServiceType,
                InQueue = obj.InQueue
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator ServiceApplication(UserCreateServiceApplicationViewModel viewModel)
        {
            return new ServiceApplication
            {
                Id = viewModel.Id,
                Customer = viewModel.Customer,
                BoatData = viewModel.BoatData,
                ServiceType = viewModel.ServiceType,
                InQueue= viewModel.InQueue
            };
        }

        public int Id { get; set; }

        public IdentityAppUser Customer { get; set; }

        public BoatData BoatData { get; set; }
        public List<BoatData> BoatDataListView { get; set; }

        public ServiceType ServiceType { get; set; }
        public List<ServiceType> ServiceTypeListView { get; set; }

        public int InQueue { get; set; }



        [Display(Name = "Dina Båtar")]
        public int BoatDataId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Välj en tjänst för din båt")]
        public int ServiceTypeId { get; set; }

    }

}
