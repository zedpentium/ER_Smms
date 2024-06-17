using Microsoft.AspNetCore.Identity;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ER_Smms.Models
{
    public class IdentityAppUser : IdentityUser
    {
        // allready exist public string Id { get; set;}

        // allready exist public string UserName { get; set;}

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // allready exist public string PhoneNumber { get; set; }

        // allready exist public string Email { get; set; }

        public string Address { get; set; }

        public int Postcode { get; set; }

        public string City { get; set; }

        public string ExtraInfoTextarea { get; set; }


        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime EnrollmentDate { get; set; }

        [JsonIgnore]
        public List<BoatData> BoatDatas { get; set; }

        public List<ServiceApplication> ServiceApplications { get; set; }

        public List<ServiceHistory> ServiceHistories { get; set; }



    }
}
