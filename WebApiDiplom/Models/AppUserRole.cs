﻿using Microsoft.AspNetCore.Identity;

namespace WebApiDiplom.Models
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
