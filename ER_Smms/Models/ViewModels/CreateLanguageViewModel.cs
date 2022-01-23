using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels
{
    public class CreateLanguageViewModel
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Please select languages"), MaxLength(50)]
        [Display(Name = "Language")]
        public string LanguageName { get; set; }

    }

}
