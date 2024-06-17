using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
//using System.Text.Json.Serialization;

namespace ER_Smms.Models
{
    public class ServiceType
    {

        public int Id { get; set; }

        public int ArtNr { get; set; }

        public string Label { get; set; }

        public string Size { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }


        [JsonIgnore]
        public List<Boatslip> Boatslips { get; set; }

        [JsonIgnore]
        public List<WinterstoreSpot> WinterstoreSpots { get; set; }

        public List<ServiceApplication> ServiceApplications { get; set; }

        public List<ServiceHistory> ServiceHistories { get; set; }

    }

}
