using System.Collections.Generic;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ER_Smms.Models
{
    public class Boatslip : DateCreatedEdited
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public int BoatDataIdRef { get; set; }



        public Pier Pier { get; set; }

        public ServiceType ServiceType { get; set; }

        public MooringType MooringType { get; set; }



        [JsonIgnore]
        public List<BoatData> BoatDatas { get; set; }

        public List<ServiceHistory> ServiceHistories { get; set; }

    }

}
