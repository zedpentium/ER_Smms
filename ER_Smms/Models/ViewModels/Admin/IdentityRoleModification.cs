using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{
    public class IdentityRoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }
}