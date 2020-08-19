using EShop.BL.Common;
using System.Collections.Generic;

namespace EShop.BL
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}