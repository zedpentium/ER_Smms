using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Frontend
{

    public class ApplyForBoatslipViewModel : DateCreatedEdited
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator ApplyForBoatslipViewModel(Applicant obj)
        {
            return new ApplyForBoatslipViewModel
            {
                Id = obj.Id,
                BrandModel = obj.BrandModel,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth,
                CreatedDate = obj.CreatedDate,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                PhoneNumber = obj.PhoneNumber,
                ExtraInfoTextarea = obj.ExtraInfoTextarea
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator Applicant(ApplyForBoatslipViewModel viewModel)
        {
            return new Applicant
            {
                BrandModel = viewModel.BrandModel,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Depth = viewModel.Depth,
                CreatedDate = viewModel.CreatedDate,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                ExtraInfoTextarea = viewModel.ExtraInfoTextarea
            };
        }



        public int Id { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Typ/Modell/Märke på denna Båt"), MaxLength(50)]
        [Display(Name = "* Båtens Typ/Modell")]
        public string BrandModel { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Längden på denna Båt")]
        [Display(Name = "* Längd(m)")]
        //[MinLength(5)]
        public decimal Length { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Bredden på denna Båt")]
        [Display(Name = "* Bredd(m)")]
        public decimal Width { get; set; }

        //[DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{1,2}$|^[0-9]{1,2}\,[0-9]{1,2}$",
            ErrorMessage = "* Skriv in siffror, med eller utan decimal (comma och max 2 decimaler.")]
        [Range(0, 9999.99)]
        [Required(ErrorMessage = "* Skriv in Djup på denna Båt")]
        [Display(Name = "* Djup(m). Hur djupt båten går.")]
        public decimal Depth { get; set; }


        [Required(ErrorMessage = "* Skriv in Förnamn")]
        [Display(Name = "* Förnamn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Skriv in Efternamn")]
        [Display(Name = "* Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Tel")]
        public string PhoneNumber { get; set; }


        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            ErrorMessage = "* Ogiltig(a) tecken. Du får inte använda å ä ö. Skriv eposten igen")]
        //[EmailAddress(ErrorMessage = "Icke giltig Epost Adress. Skriv in igen.")]
        [Required(ErrorMessage = "* Skriv in din Epost.")]
        [Display(Name = "* Epost")]
        public string Email { get; set; }

        [Display(Name = "Extra Info")]
        public string ExtraInfoTextarea { get; set; }




    }

    
}
