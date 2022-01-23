using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{

    public class EditHarbourViewModel
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namet på denna Hamn"), MaxLength(50)]
        [Display(Name = "Hamnens Namn")]
        public string Label { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Info om denna Hamnen"), MaxLength(500)]
        [Display(Name = "Info om Hamnen")]
        public string Info { get; set; }

        //[DataType(DataType.Text)]
        //[Required(ErrorMessage = "* Please enter name"), MaxLength(80)]
        //[Display(Name = "*Not finished___Map-placeholder to upload a map...")]
        //public string MapURL { get; set; }


    }
}
