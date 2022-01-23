using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Keycode
    {

        public int Id { get; set; }

        public string IdentityAppUser_Id { get; set; }

        public string Code { get; set; }

        public string DateValidTo { get; set; }
    }

}
