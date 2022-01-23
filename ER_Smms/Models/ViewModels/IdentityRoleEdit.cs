using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ER_Smms.Models.ViewModels
{
    public class IdentityRoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityAppUser> Members { get; set; }
        public IEnumerable<IdentityAppUser> NonMembers { get; set; }
    }
}