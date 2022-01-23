using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class KeyReceipt
    {

        public int Id { get; set; }

        public string IdentityAppUser_Id { get; set; }

        public string KeyNumber { get; set; }

        public string KeyPictureURL { get; set; }

        public int Deposit { get; set; }
    }

}
