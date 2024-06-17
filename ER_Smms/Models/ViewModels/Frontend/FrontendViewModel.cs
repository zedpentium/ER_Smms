using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Frontend
{

    public class FrontendViewModel
    {
        public IdentityAppUser Customer { get; set; }

        public string ErrorMessageInfo { get; set; }


        public List<BoatData> ListUserBoatData { get; set; }

        public List<Boatslip> ListUserBoatslip { get; set; }

        public List<WinterstoreSpot> ListUserWinterstoreSpot { get; set; }

    }
}
