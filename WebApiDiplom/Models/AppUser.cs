using Microsoft.AspNetCore.Identity;

namespace WebApiDiplom.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Passport { get; set; }
        public string Phone { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
