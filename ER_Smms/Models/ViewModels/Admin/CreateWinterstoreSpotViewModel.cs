using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class CreateWinterstoreSpotViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator CreateWinterstoreSpotViewModel(WinterstoreSpot obj)
        {
            return new CreateWinterstoreSpotViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Length = obj.Length,
                Width = obj.Width,
                Height = obj.Height,
                SpotM2 = obj.SpotM2,
                SpotPrice = obj.SpotM2 * obj.ServiceType.Price,
                ServiceType = obj.ServiceType
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator WinterstoreSpot(CreateWinterstoreSpotViewModel viewModel)
        {
            return new WinterstoreSpot
            {
                Label = viewModel.Label,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Height = viewModel.Height,
                SpotM2 = viewModel.SpotM2,
                ServiceType = viewModel.ServiceType
            };
        }


        public int Id { get; set; }

        public decimal SpotM2 { get; set; }

        [Display(Name = "PlatsPris")]
        public decimal SpotPrice { get; set; }

        public ServiceType ServiceType { get; set; }

        public List<ServiceType> ServiceTypeListView { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namnet och/eller Nummer på vinterförvaringsPlatsen"), MaxLength(50)]
        [Display(Name = "Namn och/eller Nummer på platsen")]
        public string Label { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Längden platsen klarar")]
        [Display(Name = "Längd(m)")]
        //[MinLength(5)]
        public decimal Length { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Bredden platsen klarar")]
        [Display(Name = "Bredd(m)")]
        public decimal Width { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        //[Required(ErrorMessage = "* Skriv in Höjden på denna Båt på kärra, för inomhus vinterförvaring." +
        //    " Där högsta höjden är på fastmonterad del. Mast, Tak, Stag etc")]
        [Display(Name = "Höjd(m). Skriv in platsens MaxHöjd. " +
            "Där högsta höjden av båt på kärra, är från marken/golvet upp till fastmonterad del. Mast, Tak, Stag etc")]
        public decimal Height { get; set; }

        [Display(Name = "FörvaringsTyp? (Inne/Ute) ")]
        [Required(ErrorMessage = "* Välj om platsen är Inne eller Ute")]
        public int ServiceTypeId { get; set; }


    }
}
