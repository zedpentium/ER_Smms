using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ER_Smms.Models.ViewModels.Admin
{
    public class ManageCustomerViewModel
    {
        public CustomerAllInfoDTO CustomerAllInfo { get; set; }
        public IdentityAppUser Customer { get; set; }

        [Display(Name = "KundBåt(ar)")]
        public int SelectedBoatDataId { get; set; }

        [Display(Name = "Lediga Båtplats(er)")]
        public int SelectedBoatslipId { get; set; }

        public int WinterstoreSpotId { get; set; }

        public int SelectedBoatFormId { get; set; }


        public BoatData BoatData { get; set; }


        public List<Boatslip> FreeBoatslips { get; set; }

        public List<WinterstoreSpot> FreeWinterstoreSpotsIn { get; set; }
        public List<WinterstoreSpot> FreeWinterstoreSpotsOut { get; set; }
        public List<WinterstoreSpot> FreeWinterstoreSpots { get; set; }
    }
}
