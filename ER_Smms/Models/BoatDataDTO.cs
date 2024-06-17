using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models
{
    public class BoatDataDTO : DateCreatedEdited
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator BoatDataDTO(BoatData obj)
        {
            return new BoatDataDTO
            {
                Id = obj.Id,
                Label = obj.Label,
                BrandModel = obj.BrandModel,
                Length = obj.Length,
                Width = obj.Width,
                Depth = obj.Depth,
                Weight = obj.Weight,
                Height = obj.Height,
                HaveInsurance = obj.HaveInsurance,
                CreatedDate = obj.CreatedDate,
                UpdatedDate = obj.UpdatedDate,
                CustomerUserName = obj.Customer.UserName,
                Boatslip = obj.Boatslip,
                WinterstoreSpot = obj.WinterstoreSpot
            };
        }

        //Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator BoatData(BoatDataDTO viewModel)
        {
            return new BoatData
            {
                Id = viewModel.Id,
                Label = viewModel.Label,
                BrandModel = viewModel.BrandModel,
                Length = viewModel.Length,
                Width = viewModel.Width,
                Depth = viewModel.Depth,
                Weight = viewModel.Weight,
                Height = viewModel.Height,
                HaveInsurance = viewModel.HaveInsurance,
                CreatedDate = viewModel.CreatedDate,
                UpdatedDate = viewModel.UpdatedDate,
                Boatslip = viewModel.Boatslip,
                WinterstoreSpot = viewModel.WinterstoreSpot
            };
        }



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



        public string CustomerUserName { get; set; }



        public Boatslip Boatslip { get; set; }

        public WinterstoreSpot WinterstoreSpot { get; set; }



    }
}
