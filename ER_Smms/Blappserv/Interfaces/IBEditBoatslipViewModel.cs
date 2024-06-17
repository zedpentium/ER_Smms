using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels.Admin;

namespace ER_Smms.Blappserv.Interfaces
{
    public interface IBEditBoatslipViewModel
    {
        bool IsBusy { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public Pier Pier { get; set; }
        public List<Pier> PierListView { get; set; }

        public ServiceType ServiceType { get; set; }
        public List<ServiceType> ServiceTypeListView { get; set; }

        public IEnumerable<ServiceType> Ienum_ServiceTypeListView { get; set; }

        public string JsonServiceTypeListView { get; set; }

        public MooringType MooringType { get; set; }
        public List<MooringType> MooringTypeListView { get; set; }


        public int BoatDataIdRef { get; set; }

        public BoatData BoatData { get; set; }
        public List<BoatData> BoatDataListView { get; set; }

        public int BoatDataId { get; set; }

        public int BoatDataIdThatWas { get; set; }

        public string Label { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public int ServiceTypeId { get; set; }

        public int MooringTypeId { get; set; }

        public int PierId { get; set; }
    }
}
