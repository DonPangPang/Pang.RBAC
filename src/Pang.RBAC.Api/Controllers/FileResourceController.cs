using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pang.RBAC.Api.Controllers.Base;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Repository;

namespace Pang.RBAC.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class FileResourceController : MyControllerBase<FileResourceRepository, FileResource>
    {
        private readonly FileResourceRepository _fileResourceRepository;
        public FileResourceController(FileResourceRepository fileResourceRepository) : base(fileResourceRepository)
        {
            _fileResourceRepository = fileResourceRepository ?? throw new System.ArgumentNullException(nameof(fileResourceRepository));
        }
    }
}