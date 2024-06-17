using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models
{
    public class CustomerAllInfoDTO
    {

        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator CustomerAllInfoDTO(IdentityAppUser obj)
        {
            return new CustomerAllInfoDTO
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
        //public static implicit operator IdentityAppUser(CustomerDTO viewModel)
        //{
        //    return new IdentityAppUser
        //    {
        //        Id = viewModel.Id,
        //        UserName = viewModel.UserName,
        //        FirstName = viewModel.FirstName,
        //        LastName = viewModel.LastName,
        //        Email = viewModel.Email,
        //        PhoneNumber = viewModel.PhoneNumber,
        //        Address = viewModel.Address,
        //        Postcode = viewModel.Postcode,
        //        City = viewModel.City

        //    };
        //}


        public string Id { get; set;}

        [Display(Name = "AnvändarNamn")]
        public string UserName { get; set; }

        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Tel")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Adress")]
        public string Address { get; set; }

        [Display(Name = "Postnummer")]
        public int Postcode { get; set; }

        [Display(Name = "Stad")]
        public string City { get; set; }

        [Display(Name = "Epost")]
        public string Email { get; set; }

        [Display(Name = "Extra Info (andra kontaktpersoner etc)")]
        public string ExtraInfoTextarea { get; set; }


        public int BoatslipsAmount { get; set; }

        public int BoatsAmount { get; set; }

        public int WinterstoreAmount { get; set; }



        public List<BoatDataDTO> BoatDatas { get; set; }
    }
}
