using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{

    public class HarbourViewModel /* : CreateHarbourViewModel*/
    {
        public string Id { get; set; }

        public string Label { get; set; }

        public string Info { get; set; }

        public string MapURL { get; set; }


        public Harbour Harbour { get; set; }

        public List<Harbour> HarbourListView { get; set; }


        //public HarbourViewModel()
        //{
        //    HarbourListView = new List<Harbour>();
        //}


    }
}
