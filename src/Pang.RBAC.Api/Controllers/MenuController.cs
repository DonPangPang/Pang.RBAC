using System;
using System.Runtime.InteropServices;
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
    public class MenuController : MyControllerBase<MenuRepository, Menu>
    {
        private readonly MenuRepository _menuRepository;
        public MenuController(MenuRepository repository) : base(repository)
        {
            _menuRepository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildrens(Guid id)
        {
            var childrens = await _menuRepository.GetChildrens(id);

            return Ok(childrens);
        }
    }
}