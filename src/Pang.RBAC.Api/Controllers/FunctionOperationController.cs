using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [Authorize("Identify")]
    [EnableCors("Any")]
    public class FunctionOperationController : MyControllerBase<FunctionOperationRepository, FunctionOperation, FunctionOperationDto>
    {
        private readonly FunctionOperationRepository _functionOperationRepository;
        private readonly IMapper _mapper;

        public FunctionOperationController(FunctionOperationRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _functionOperationRepository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildrens(Guid id)
        {
            var childrens = await _functionOperationRepository.GetChildren(id);

            var returnDtos = _mapper.Map<IEnumerable<FunctionOperationDto>>(childrens);

            return Ok(returnDtos);
        }
    }
}