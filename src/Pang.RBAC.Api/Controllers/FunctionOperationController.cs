using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class FunctionOperationController : MyControllerBase<FunctionOperationRepository, FunctionOperation>
    {
        private readonly FunctionOperationRepository _functionOperationRepository;
        public FunctionOperationController(FunctionOperationRepository repository) : base(repository)
        {
            _functionOperationRepository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildrens(Guid id)
        {
            var childrens = await _functionOperationRepository.GetChildrens(id);

            return Ok(childrens);
        }
    }
}