using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using Pang.RBAC.Api.Repository.Base;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class MenuController : MyControllerBase<MenuRepository, Menu, MenuDto>
    {
        private readonly MenuRepository _menuRepository;
        private readonly IMapper _mapper;
        public MenuController(MenuRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _menuRepository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildrens(Guid id)
        {
            var childrens = await _menuRepository.GetChildrens(id);

            var returnDtos = _mapper.Map<IEnumerable<MenuDto>>(childrens);

            return Ok(returnDtos);
        }
    }
}