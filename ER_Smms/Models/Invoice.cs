using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Invoice
    {

        public int Id { get; set; }

        public int DateGenerated { get; set; }

        public string IdentityAppUser_Id { get; set; }

        public string Service_Id { get; set; }

    }

}
