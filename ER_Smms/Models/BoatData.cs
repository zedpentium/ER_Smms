using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class BoatData
    {

        public int Id { get; set; }

        public string Label { get; set; }

        public int Lenght { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public int Weight { get; set; }

        public string BrandModel { get; set; }

        public string Insurance { get; set; }

        public string InsuranceURL { get; set; }

        public string BoatPictureURL { get; set; }

    }

}
