using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{

    public class CreatePierViewModel
    {
        public int Id { get; set; }

        public Harbour Harbour { get; set; }

        public List<Harbour> HarbourListView { get; set; }    

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namn/Beteckning på denna Brygga"), MaxLength(50)]
        [Display(Name = "Bryggans Namn/Beteckning")]
        public string Label { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Info om denna Brygga"), MaxLength(500)]
        [Display(Name = "Info om Bryggan")]
        //[MinLength(1)]
        public string Info { get; set; }

        [RegularExpression("[0-9]{1,}", ErrorMessage = "* Välj Hamn!")]
        [Required(ErrorMessage = "* Välj Hamn!")]
        [Display(Name = "Välj Hamn")]
        public int HarbourId { get; set; }




    }
}
