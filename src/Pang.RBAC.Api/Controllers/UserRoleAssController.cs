using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class UserRoleAssController : MyControllerBase<UserRoleAssRepository, UserRoleAss>
    {
        public UserRoleAssController(UserRoleAssRepository repository) : base(repository)
        {
        }
    }
}