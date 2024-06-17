using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class WinterstoreSpotViewModel
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal SpotM2 { get; set; }


        public string Totalm2RentoutIndoors { get; set; }

        public string Totalm2RentoutOutdoors { get; set; }

        //public string CurrentUser { get; set; }



        //public BoatData BoatData { get; set; }

        public ServiceType ServiceType { get; set; }

        public List<ServiceType> ServiceTypeListView { get; set; }

        public List<WinterstoreSpot_DTO> WinterstoreSpotListView { get; set; }

    }
}
