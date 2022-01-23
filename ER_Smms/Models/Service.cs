using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Service
    {

        public int Id { get; set; }

        public int ArtNr { get; set; }

        public string Label { get; set; }

        public int Price { get; set; }

    }

}
