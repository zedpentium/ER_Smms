using System.Collections.Generic;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class BoatslipViewModel
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Length { get; set; }

        public string Width { get; set; }

        public decimal Depths { get; set; }

        public int MooringTypeId { get; set; }

        public int PierId { get; set; }



        public BoatData BoatData { get; set; }

        public List<Boatslip_DTO> BoatslipListView { get; set; }

        public MooringType MooringType { get; set; }

        public Pier Pier { get; set; }

    }
}
