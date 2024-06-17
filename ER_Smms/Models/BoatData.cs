using System.Collections.Generic;


namespace ER_Smms.Models
{
    public class BoatData : DateCreatedEdited
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




        public IdentityAppUser Customer { get; set; }

        public Boatslip Boatslip { get; set; }

        public WinterstoreSpot WinterstoreSpot { get; set; }



        public List<ServiceApplication> ServiceApplications { get; set; }

        public List<ServiceHistory> ServiceHistories { get; set; }

    }

}
