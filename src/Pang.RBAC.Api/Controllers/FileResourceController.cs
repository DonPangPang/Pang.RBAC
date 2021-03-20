using System.Security.AccessControl;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    [Authorize("Identify")]
    public class FileResourceController : MyControllerBase<FileResourceRepository, FileResource, FileResourceDto>
    {
        private readonly FileResourceRepository _fileResourceRepository;
        public FileResourceController(FileResourceRepository fileResourceRepository, IMapper mapper) : base(fileResourceRepository, mapper)
        {
            _fileResourceRepository = fileResourceRepository ?? throw new System.ArgumentNullException(nameof(fileResourceRepository));
        }
    }
}