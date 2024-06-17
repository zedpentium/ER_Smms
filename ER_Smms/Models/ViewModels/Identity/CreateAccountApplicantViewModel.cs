using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ER_Smms.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;


namespace ER_Smms.Models.ViewModels.Identity
{
    public class CreateAccountApplicantViewModel /* : PageModel*/
    {
        public string ReturnUrl { get; set; }

        public string UserName { get; set; }

        public string ExtraInfoTextarea { get; set; }

        //public IList<AuthenticationScheme> ExternalLogins { get; set; }


        // User account info

        [Required]
            [EmailAddress(ErrorMessage = "{0} måste vara en epost-adress")]
            [Display(Name = "AnvändarNamn (epost):")]
            public string Email { get; set; }


            //Added FirstName, LastName and BirthDate /ER
            [Required]
            [StringLength(100, ErrorMessage = "{0} måste vara minst {2} och max {1} bokstäver långt.", MinimumLength = 1)]
            [DataType(DataType.Text)]
            [Display(Name = "Förnamn:")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} måste vara minst {2} och max {1} bokstäver långt.", MinimumLength = 1)]
            [DataType(DataType.Text)]
            [Display(Name = "Efternamn:")]
            public string LastName { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "{0} måste vara minst {2} och max {1} bokstäver långt.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "TelefonNummer:")]
        public string PhoneNumber { get; set; }



        // BoatData info

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


    }
}
