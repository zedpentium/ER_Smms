using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models.ViewModels
{
    public class ReactAPIPersonViewModel
    {

        public int PersonId { get; set; }


        public string PersonName { get; set; }


        public string PersonPhoneNumber { get; set; }


    }
}
