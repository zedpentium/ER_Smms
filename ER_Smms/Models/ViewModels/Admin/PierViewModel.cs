using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class PierViewModel
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string Info { get; set; }



        public Pier Pier { get; set; }

        public List<Pier> PierListView { get; set; }

    }
}
