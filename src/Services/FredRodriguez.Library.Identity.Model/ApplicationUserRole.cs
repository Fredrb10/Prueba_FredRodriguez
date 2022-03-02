using Microsoft.AspNetCore.Identity;

namespace FredRodriguez.Library.Identity.Model
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}
