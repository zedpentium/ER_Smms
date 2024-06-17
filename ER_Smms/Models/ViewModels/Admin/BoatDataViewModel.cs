using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class BoatDataViewModel
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string BrandModel { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public string HaveInsurance { get; set; }

        public string InsuranceURL { get; set; }

        public string BoatPictureURL { get; set; }


        public BoatData BoatData { get; set; }

        public List<BoatData> BoatDataListView { get; set; }
    }

    
}
