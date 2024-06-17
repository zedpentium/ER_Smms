using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class WinterstoreSpot_DTO : DateCreatedEdited
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator WinterstoreSpot_DTO(WinterstoreSpot obj)
        {
            return new WinterstoreSpot_DTO
            {
                Id = obj.Id,
                Label = obj.Label,
                Length = obj.Length,
                Width = obj.Width,
                Height = obj.Height,
                SpotM2 = obj.SpotM2,
                ServiceType = obj.ServiceType,
                BoatDataIdRef = obj.BoatDataIdRef,
                CreatedDate = obj.CreatedDate,
                UpdatedDate = obj.UpdatedDate
            };
        }


        public int Id { get; set; }

        public string Label { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal SpotM2 { get; set; }



        public ServiceType ServiceType { get; set; }

        public int BoatDataIdRef { get; set; }

        public BoatData BoatData { get; set; }

    }

}
