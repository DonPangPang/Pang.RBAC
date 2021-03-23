using System;

namespace Pang.RBAC.Api.Entities
{
    public class UserRoleAss : Entity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}