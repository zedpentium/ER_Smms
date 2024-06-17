using ER_Smms.Blappserv.Interfaces;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ER_Smms.Blappserv.ViewModels
{
    public class BManageCustomerViewModel : BaseViewModel, IBManageCustomerViewModel
    {
        private CustomerAllInfoDTO customerAllInfo = new CustomerAllInfoDTO();
        public CustomerAllInfoDTO CustomerAllInfo
        {
            get => customerAllInfo;
            set
            {
                SetValue(ref customerAllInfo, value);
            }
        }

        public IdentityAppUser Customer { get; set; } = new IdentityAppUser();

        [Display(Name = "KundBåt(ar)")]
        public int SelectedBoatDataId { get; set; } = new int();

        [Display(Name = "Lediga Båtplats(er)")]
        public int SelectedBoatslipId { get; set; } = new int();

        public int SelectedWinterstoreSpotId { get; set; } = new int();

        //public int SelectedBoatFormId { get; set; }

        //public bool AnyBoatSelected { get; set; }   // prop for easier if checks
        //public string Boatsliplabel { get; set; }   // prop for long adding to string code
        //public string Pierlabel { get; set; }       // prop for long adding to string code

        public BoatDataDTO BoatDTO { get; set; }


        public List<Boatslip> FreeBoatslips { get; set; } = new List<Boatslip>();

        //public List<WinterstoreSpot> FreeWinterstoreSpotsIn { get; set; }
        //public List<WinterstoreSpot> FreeWinterstoreSpotsOut { get; set; }
        public List<WinterstoreSpot> FreeWinterstoreSpots { get; set; } = new List<WinterstoreSpot>();

        public List<CustomerAllInfoDTO> CustomerAllInfoListView { get; set; } = new List<CustomerAllInfoDTO>();
    }
}
