using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class ServiceTypeViewModel
    {
        public int Id { get; set; }

        public int ArtNr { get; set; }

        public string Type { get; set; }

        public string Label { get; set; }

        public decimal Price { get; set; }


        public List<ServiceType> ServiceTypeListView { get; set; }

    }
}
