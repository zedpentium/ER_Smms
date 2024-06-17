using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class EditBoatslipViewModel : CreateBoatslipViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator EditBoatslipViewModel(Boatslip obj)
        {
            return new EditBoatslipViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth,
                ServiceType = obj.ServiceType,
                MooringType = obj.MooringType,
                Pier = obj.Pier,
                BoatDataIdRef = obj.BoatDataIdRef
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator Boatslip(EditBoatslipViewModel viewModel)
        {
            return new Boatslip
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Depth = viewModel.Depth,
                ServiceType = viewModel.ServiceType,
                MooringType = viewModel.MooringType,
                Pier = viewModel.Pier,
                BoatDataIdRef = viewModel.BoatDataIdRef
            };
        }

        public int BoatDataIdRef { get; set; }

        public BoatData BoatData { get; set; }
        public List<BoatData> BoatDataListView { get; set; }




        //[Required(ErrorMessage = "* Kunds Båt")]
        [Display(Name = "Kunds Båt")]
        public int BoatDataId { get; set; }

        public int BoatDataIdThatWas { get; set; }


    }
}
