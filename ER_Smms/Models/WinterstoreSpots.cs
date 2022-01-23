using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class WinterstoreSpots
    {

        public int Id { get; set; }

        public string Label { get; set; }

        public int Lenght { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string StoreType { get; set; }

    }

}
