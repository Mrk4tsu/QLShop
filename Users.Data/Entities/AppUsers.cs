using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Users.Data.Entities
{
    public class AppUsers : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DoB { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
