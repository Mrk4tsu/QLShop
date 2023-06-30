using Microsoft.AspNetCore.Identity;
using System;

namespace Users.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }

    }
}
