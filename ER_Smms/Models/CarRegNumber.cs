using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class CarRegNumber
    {

        public int Id { get; set; }

        public string IdentityAppUser_Id { get; set; }

        public string RegNumber { get; set; }

    }

}
