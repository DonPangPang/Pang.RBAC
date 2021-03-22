using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;
using Microsoft.AspNetCore.Authorization;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [Authorize("Identify")]
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
            var childrens = await _functionOperationRepository.GetChildrens(id);

            var returnDtos = _mapper.Map<IEnumerable<FunctionOperationDto>>(childrens);

            return Ok(returnDtos);
        }
    }
}