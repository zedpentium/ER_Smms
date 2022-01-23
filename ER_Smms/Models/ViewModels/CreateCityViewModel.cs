using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{
    public class CreateCityViewModel
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Please enter city"), MaxLength(50)]
        [Display(Name = "City")]
        public string CityName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Please choose country"), MaxLength(50)]
        [Display(Name = "Country")]
        public string Country { get; set; }

    }

}
