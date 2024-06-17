using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class CreateBoatslipViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator CreateBoatslipViewModel(Boatslip obj)
        {
            return new CreateBoatslipViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth,
                ServiceType = obj.ServiceType,
                MooringType = obj.MooringType,
                Pier = obj.Pier
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator Boatslip(CreateBoatslipViewModel viewModel)
        {
            return new Boatslip
            {
                Label = viewModel.Label,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Depth = viewModel.Depth,
                ServiceType = viewModel.ServiceType,
                MooringType = viewModel.MooringType,
                Pier = viewModel.Pier
            };
        }

        public int Id { get; set; }

        public Pier Pier { get; set; }
        public List<Pier> PierListView { get; set; }

        public ServiceType ServiceType { get; set; }
        public List<ServiceType> ServiceTypeListView { get; set; }

        public IEnumerable<ServiceType> Ienum_ServiceTypeListView { get; set; }

        public string JsonServiceTypeListView { get; set; }

        public MooringType MooringType { get; set; } 
        public List<MooringType> MooringTypeListView { get; set; }




        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namnet/Numret på denna Båtplats"), MaxLength(50)]
        [Display(Name = "Båtplatsens Namn/Nummer")]
        public string Label { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 999.99)]
        [Required(ErrorMessage = "* Skriv in MaxLängden denna Båtplats klarar")]
        [Display(Name = "Längd(m)")]
        //[MinLength(5)]
        public decimal Length { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 999.99)]
        [Required(ErrorMessage = "* Skriv in MaxBredden denna Båtplats klarar")]
        [Display(Name = "Bredd(m)")]
        //[MinLength(5)]
        public decimal Width { get; set; }

        //[DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 999.99)]
        [Required(ErrorMessage = "* Skriv in MaxDjup denna Båtplats klarar")]
        [Display(Name = "Djup(m)")]
        //[MinLength(5)]
        public decimal Depth { get; set; }


        [Required(ErrorMessage = "* Välj Tjänst")]
        [Display(Name = "Tjänst")]
        public int ServiceTypeId { get; set; }

        [Required(ErrorMessage = "* Välj FörtöjningsTyp")]
        [Display(Name = "FörtöjningsTyp")]
        public int MooringTypeId { get; set; }

        [Required(ErrorMessage = "* Välj Brygga")]
        [Display(Name = "Välj Brygga")]
        public int PierId { get; set; }

    }
}
