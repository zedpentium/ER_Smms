using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Frontend
{

    public class UserCreateBoatDataViewModel : DateCreatedEdited
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator UserCreateBoatDataViewModel(BoatData obj)
        {
            return new UserCreateBoatDataViewModel
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
                Customer = obj.Customer
                //Boatslip = obj.Boatslip
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator BoatData(UserCreateBoatDataViewModel viewModel)
        {
            return new BoatData
            {
                Label = viewModel.Label,
                BrandModel = viewModel.BrandModel,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Depth = viewModel.Depth,
                Weight = viewModel.Weight,
                Height = viewModel.Height,
                HaveInsurance = viewModel.HaveInsurance,
                CreatedDate = viewModel.CreatedDate,
                Customer = viewModel.Customer
                //Boatslip = viewModel.Boatslip
            };
        }


        public int Id { get; set; }

        public Boatslip Boatslip { get; set; }

        //public List<Pier> PierListView { get; set; }  
        
        public IdentityAppUser Customer { get; set; } 

        public string CustomerId { get; set; } 


          

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namnet och/eller Nummer på denna Båt"), MaxLength(50)]
        [Display(Name = "Båtens Namn och/eller Nummer")]
        public string Label { get; set; }

        [DataType(DataType.Text)]
        //[Required(ErrorMessage = "* Skriv in Märke & Modell denna Båt"), MaxLength(50)]
        [Display(Name = "Båtens Märke & Modell")]
        public string BrandModel { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Längden på denna Båt")]
        [Display(Name = "Längd(m)")]
        //[MinLength(5)]
        public decimal Length { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Bredden på denna Båt")]
        [Display(Name = "Bredd(m)")]
        public decimal Width { get; set; }

        //[DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Djup på denna Båt")]
        [Display(Name = "Djup(m). Hur djupt båten går.")]
        public decimal Depth { get; set; }

        [RegularExpression(@"^[0-9]{1,5}$|^[0-9]{1,5}\,[0-9]{1,5}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(typeof(Decimal), "0", "99990,99", ErrorMessage = "* Ange Vikten mellan 0 till 99990,99.")]
        [Required(ErrorMessage = "* Skriv in TotalVikten på denna Båt")]
        [Display(Name = "Vikt(kg)")]
        public decimal Weight { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        //[Required(ErrorMessage = "* Skriv in Höjden på denna Båt på kärra, för inomhus vinterförvaring." +
        //    " Där högsta höjden är på fastmonterad del. Mast, Tak, Stag etc")]
        [Display(Name = "Höjd(m). Skriv in Höjden på denna Båt på kärra, för inomhus vinterförvaring." +
            " Där högsta höjden är på fastmonterad del. Mast, Tak, Stag etc")]
        public decimal Height { get; set; }

        [Display(Name = "Har du försäkring på båten?")]
        public string HaveInsurance { get; set; }


    }
}
