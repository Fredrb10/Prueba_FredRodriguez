using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FredRodriguez.Library.Identity.Model
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
