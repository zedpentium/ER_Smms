using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Frontend
{

    public class UserServiceApplicationViewModel
    {
 
        public IdentityAppUser Customer { get; set; }

        public BoatData BoatData { get; set; }
        public List<BoatData> BoatListView { get; set; }

        public List<ServiceApplication> UserServiceApplicationListView { get; set; }

        public int BoatDataId { get; set; }

        public string WhatService { get; set; }

    }

}
