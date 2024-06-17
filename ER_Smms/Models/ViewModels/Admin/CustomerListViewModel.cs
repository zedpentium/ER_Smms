using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.ViewModels.Admin
{
    public class CustomerListViewModel
    {
        public List<CustomerAllInfoDTO> CustomerAllInfoListView { get; set; }
    }
}
