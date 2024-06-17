using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class MooringTypeViewModel
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string Info { get; set; }


        public MooringType MooringType { get; set; }

        public List<MooringType> MooringTypeListView { get; set; }

    }
}
