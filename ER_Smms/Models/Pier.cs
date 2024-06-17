using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
//using System.Text.Json.Serialization;

namespace ER_Smms.Models
{
    public class Pier : DateCreatedEdited
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Info { get; set; }


        public Harbour Harbour { get; set; }

        [JsonIgnore]
        public List<Boatslip> Boatslips { get; set; }

    }


}
