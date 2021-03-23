using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class PermissionPageElementAssController : MyControllerBase<PermissionPageElementAssRepository, PermissionPageElementAss, PermissionPageElementAssDto>
    {
        public PermissionPageElementAssController(PermissionPageElementAssRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}