using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{
    public class CreateCountryViewModel
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Please enter country"), MaxLength(50)]
        [Display(Name = "Country")]
        public string CountryName { get; set; }
    }

}
