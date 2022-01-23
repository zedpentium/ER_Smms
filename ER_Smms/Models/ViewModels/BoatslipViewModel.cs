using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{

    public class BoatslipViewModel
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Length { get; set; }

        public string Width { get; set; }

        public string Depths { get; set; }

        public string Weight { get; set; }

        public string Brandmodel { get; set; }

        public string Insurance { get; set; }

        public string InsuranceURL { get; set; }

        public string BoatPictureURL { get; set; }


        public Boatslip Boatslip { get; set; }

        public List<Boatslip> BoatslipListView { get; set; }
    }
}
