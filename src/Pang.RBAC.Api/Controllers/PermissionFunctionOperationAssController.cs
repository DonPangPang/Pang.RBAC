using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class PermissionFunctionOperationAssController : MyControllerBase<PermissionFunctionOperationAssRepository, PermissionFunctionOperationAss>
    {
        public PermissionFunctionOperationAssController(PermissionFunctionOperationAssRepository repository) : base(repository)
        {
        }
        
    }
}