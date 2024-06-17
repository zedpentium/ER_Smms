using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models
{
    public class Applicant : DateCreatedEdited
    {
        public int Id { get; set;}

        public string BrandModel { get; set; }

        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string ExtraInfoTextarea { get; set; }



        public List<ServiceApplication> ServiceApplications { get; set; }

    }
}
