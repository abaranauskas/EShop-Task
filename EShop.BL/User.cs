using EShop.BL.Common;
using System.Collections.Generic;

namespace EShop.BL
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}