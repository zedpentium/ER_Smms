using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Boatslip_DTO : DateCreatedEdited
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator Boatslip_DTO(Boatslip obj)
        {
            return new Boatslip_DTO
            {
                Id = obj.Id,
                Label = obj.Label,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth,
                BoatDataIdRef = obj.BoatDataIdRef,
                ServiceType = obj.ServiceType,
                Pier = obj.Pier,
                MooringType = obj.MooringType,
                CreatedDate = obj.CreatedDate,
                UpdatedDate = obj.UpdatedDate
            };
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public int BoatDataIdRef { get; set; }

        public BoatData BoatData { get; set; }



        public Pier Pier { get; set; }

        public ServiceType ServiceType { get; set; }

        public MooringType MooringType { get; set; }


    }

}
