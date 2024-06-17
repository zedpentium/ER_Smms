using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class CreateMooringTypeViewModel
    {
        // Convert from object to viewmodel on-the-fly in 1 place
        public static implicit operator CreateMooringTypeViewModel(MooringType obj)
        {
            return new CreateMooringTypeViewModel
            {
                Id = obj.Id,
                Label = obj.Label,
                Info = obj.Info
            };
        }

        // Convert from viewmodel to object on-the-fly in 1 place
        public static implicit operator MooringType(CreateMooringTypeViewModel viewModel)
        {
            return new MooringType
            {
                Label = viewModel.Label,
                Info = viewModel.Info
            };
        }


        public int Id { get; set; }

        public Pier Pier { get; set; }

        public List<Pier> PierListView { get; set; }

        public MooringType MooringType { get; set; }

        public List<MooringType> MooringTypeListView { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Namet på denna Förtöjning"), MaxLength(40)]
        [Display(Name = "FörtöjningsTyp")]
        public string Label { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Skriv in Info om denna Förtöjning"), MaxLength(100)]
        [Display(Name = "Info om FörtöjningsTypen")]
        //[MinLength(5)]
        public string Info { get; set; }

    }
}
