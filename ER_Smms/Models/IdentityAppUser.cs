using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models
{
    public class IdentityAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string BirthDate { get; set; }

        public string Address { get; set; }

        public int Postcode { get; set; }

        public string City { get; set; }

        //public string Phone { get; set; }

    }
}
