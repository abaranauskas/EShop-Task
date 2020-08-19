using EShop.BL.Common;

namespace EShop.BL
{
    public class UserRole : Entity
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}