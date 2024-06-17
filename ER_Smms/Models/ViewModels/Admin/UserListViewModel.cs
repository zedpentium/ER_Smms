using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class UserListViewModel
    {
        public List<IdentityAppUser> UserListView { get; set; }
    }
}
