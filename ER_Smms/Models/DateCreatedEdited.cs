using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ER_Smms.Models.ViewModels;
using System;

namespace ER_Smms.Models
{
    public class DateCreatedEdited
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }



}
