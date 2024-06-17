using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ER_Smms.Models.ViewModels.Identity
{

    public class EditUserViewModel : IdentityUser
    {
            // Convert from object to viewmodel on-the-fly in 1 place
            public static implicit operator EditUserViewModel(IdentityAppUser obj)
            {
                return new EditUserViewModel
                {
                    Id = obj.Id,
                    UserName = obj.UserName,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Email = obj.Email,
                    PhoneNumber = obj.PhoneNumber,
                    Address = obj.Address,
                    Postcode = obj.Postcode,
                    City = obj.City,
                    ExtraInfoTextarea = obj.ExtraInfoTextarea
                };
            }

            // Convert from viewmodel to object on-the-fly in 1 place
            public static implicit operator IdentityAppUser(EditUserViewModel viewModel)
            {
                return new IdentityAppUser
                {
                    Id = viewModel.Id,
                    UserName = viewModel.UserName,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber,
                    Address = viewModel.Address,
                    Postcode = viewModel.Postcode,
                    City = viewModel.City,
                    ExtraInfoTextarea = viewModel.ExtraInfoTextarea
                };
            }


        [Display(Name = "AnvändarNamn")]
        public override string UserName { get; set; }

        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        //[Display(Name = "BirthDate")]
        //public string BirthDate { get; set; }

        [Display(Name = "Tel")]
        public override string PhoneNumber { get; set; }

        [Display(Name = "Adress")]
        public string Address { get; set; }

        [Display(Name = "Postnummer")]
        public int Postcode { get; set; }

        [Display(Name = "Stad")]
        public string City { get; set; }

        [Display(Name = "Epost")]
        public override string Email { get; set; }

        [Display(Name = "Extra Info (andra kontaktpersoner etc)")]
        public string ExtraInfoTextarea { get; set; }



        public bool NoUserFound { get; set; }

        public string NoUserFoundMessage { get; set; }
    }
}
