using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class CreateServiceTypeViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator CreateServiceTypeViewModel(ServiceType obj)
        {
            return new CreateServiceTypeViewModel
            {
                Id = obj.Id,
                ArtNr = obj.ArtNr,
                Type = obj.Type,
                Label = obj.Label,
                Size = obj.Size,
                Price = obj.Price,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth

            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator ServiceType(CreateServiceTypeViewModel viewModel)
        {
            return new ServiceType
            {
                ArtNr = viewModel.ArtNr,
                Type = viewModel.Type,
                Label = viewModel.Label,
                Size = viewModel.Size,
                Price = viewModel.Price,
                Length= viewModel.Length,
                Width = viewModel.Width,
                Depth= viewModel.Depth
            };
        }


        public int Id { get; set; }

        public string Size { get; set; }


        [RegularExpression(@"^[0-9]{1,8}$|^[0-9]{1,8}$",
            ErrorMessage = "* Skriv siffror i heltal")]
        [Range(1, 99999999, ErrorMessage = "* Ange ArtikelNummer mellan 1 till 99999999")]
        [Required(ErrorMessage = "* Skriv in ArtikelNummer")]
        [Display(Name = "ArtikelNummer")]
        public int ArtNr { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Välj Typ på denna Tjänst")]
        [Display(Name = "Välj Typ av Tjänst")]
        public string Type { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namet på denna Tjänst"), MaxLength(80)]
        [Display(Name = "Namn på Tjänst")]
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

        [RegularExpression(@"^[0-9]{1,8}$|^[0-9]{1,8}\,[0-9]{1,8}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(typeof(Decimal), "0", "999999,99", ErrorMessage = "* Ange priset mellan 0 till 999999,99.")]
        [Required(ErrorMessage = "* Skriv in Pris på Tjänsten")]
        [Display(Name = "Pris")]
        public decimal Price { get; set; }

    }
}
