using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class CreatePierViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator CreatePierViewModel(Pier obj)
        {
            return new CreatePierViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Info = obj.Info,
                Harbour = obj.Harbour
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator Pier(CreatePierViewModel viewModel)
        {
            return new Pier
            {
                Label = viewModel.Label,
                Info = viewModel.Info,
                Harbour = viewModel.Harbour
            };
        }


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
