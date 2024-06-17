using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class ManageServiceApplicationViewModel : DateCreatedEdited
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator ManageServiceApplicationViewModel(ServiceApplication obj)
        {
            return new ManageServiceApplicationViewModel
            {
                Id = obj.Id,
                Customer = obj.Customer,
                Applicant = obj.Applicant,
                BoatData = obj.BoatData,
                ServiceType = obj.ServiceType,
                InQueue = obj.InQueue
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator ServiceApplication(ManageServiceApplicationViewModel viewModel)
        {
            return new ServiceApplication
            {
                Id = viewModel.Id,
                Customer = viewModel.Customer,
                Applicant = viewModel.Applicant,
                BoatData = viewModel.BoatData,
                ServiceType = viewModel.ServiceType,
                InQueue= viewModel.InQueue
            };
        }


        public int Id { get; set; }

        public int InQueue { get; set; }

        public BoatData BoatData { get; set; }

        public IdentityAppUser Customer { get; set; }

        public Applicant Applicant { get; set; }

        public ServiceType ServiceType { get; set; }
        public List<ServiceType> ServiceTypeListView { get; set; }

        public Boatslip Boatslip { get; set; }
        public List<Boatslip> BoatslipListView { get; set; }

        public ServiceApplication ServiceApplication { get; set; }
        //public List<ServiceApplication> ServiceApplicationListView { get; set; }

        public WinterstoreSpot WinterstoreSpot { get; set; }
        public List<WinterstoreSpot> WinterstoreSpotListView { get; set; }



        //[DataType(DataType.Text)]
        //[Required(ErrorMessage = "* Skriv in Namnet/Numret på denna Båtplats"), MaxLength(50)]
        //[Display(Name = "Båtplatsens Namn/Nummer")]
        //public string Label { get; set; }


        [Required(ErrorMessage = "* Välj Tjänst")]
        [Display(Name = "Tjänst")]
        public int BoatslipId { get; set; }


        [Required(ErrorMessage = "* Välj Ledig Vinterförvaring")]
        [Display(Name = "Vinterförvaring")]
        public int WinterstoreSpotId { get; set; }

        public string CustomerId { get; set; }

        public int ApplicantId { get; set; }

        public int ServiceTypeId { get; set; }

        public int BoatDataId { get; set; }


    }
}
