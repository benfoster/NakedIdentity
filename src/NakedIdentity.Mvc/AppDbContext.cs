using Microsoft.AspNet.Identity.EntityFramework;

namespace NakedIdentity.Mvc
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }
    }
}