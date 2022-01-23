using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{

    public class CreateBoatslipViewModel
    {

        public int Id { get; set; }

        public List<Pier> PierListView { get; set; }    

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namnet/Numret på denna Båtplats"), MaxLength(50)]
        [Display(Name = "Båtplatsens Namn/Nummer")]
        public string Label { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in MaxLängden denna Båtplats klarar"), MaxLength(500)]
        [Display(Name = "Längd")]
        [MinLength(5)]
        public int Lenght { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in MaxBredden denna Båtplats klarar"), MaxLength(500)]
        [Display(Name = "Bredd")]
        [MinLength(5)]
        public int Width { get; set; }

        //[DataType(DataType.Text)]
        [RegularExpression("[0-9]{1,}", ErrorMessage = "* Skriv in med siffror!")]
        [Required(ErrorMessage = "* Skriv in MaxDjup denna Båtplats klarar"), MaxLength(500)]
        [Display(Name = "Djup")]
        [MinLength(5)]
        public int Depth { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Välj FörtöjningsTyp"), MaxLength(500)]
        [Display(Name = "FörtöjningsTyp")]
        [MinLength(5)]
        public string MooringType { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Välj Brygga")]
        [Display(Name = "Välj Brygga")]
        public int PierId { get; set; }



    }
}
