using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ER_Smms.Models
{
    public class WinterstoreSpot : DateCreatedEdited
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal SpotM2 { get; set; }
        

        public int BoatDataIdRef { get; set; }




        public ServiceType ServiceType { get; set; }

        [JsonIgnore]
        public List<BoatData> BoatDatas { get; set; }

        public List<ServiceHistory> ServiceHistories { get; set; }

    }

}
