using System;

namespace Pang.RBAC.Api.Entities
{
    public class RolePermissionAss : Entity
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}