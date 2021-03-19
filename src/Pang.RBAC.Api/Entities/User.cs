using System.Collections.Generic;

namespace Pang.RBAC.Api.Entities
{
    public partial class User: Entity
    {
        public string Username{get; set;}
        public string Password{get; set;}
        public bool IsSuper{get; set;} = false;
        
        public ICollection<UserRoleAss> UserRoleAsses{get; set;}
        public UserUserGroupAss UserUserGroupAss{get; set;}
    }
}