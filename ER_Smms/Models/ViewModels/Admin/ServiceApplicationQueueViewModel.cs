using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class ServiceApplicationQueueViewModel
    {
        public IdentityAppUser Customer { get; set; }

        public Applicant Applicant { get; set; }

        public BoatData BoatData { get; set; }
        public List<BoatData> BoatDataListView { get; set; }

        public List<ServiceApplication> ServiceApplicationQueueListView { get; set; }

        public BoatData BoatDataId { get; set; }

        //public string WhatService { get; set; }

        public ServiceType ServiceType { get; set; }

    }

}
