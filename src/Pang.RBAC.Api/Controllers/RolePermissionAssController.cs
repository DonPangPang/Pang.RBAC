using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [Authorize("Identify")]
    [EnableCors("Any")]
    public class RolePermissionAssController : MyControllerBase<RolePermissionAssRepository, RolePermissionAss, RolePermissionAssDto>
    {
        public RolePermissionAssController(RolePermissionAssRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}