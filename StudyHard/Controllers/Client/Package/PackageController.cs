using Microsoft.AspNetCore.Mvc;
using StudyHard.Dto.Package;
using StudyHard.Services.Package;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Web.Controllers.Client.Package
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet("userpackages/{userId}")]
        public async Task<List<PackageDto>> GetAllUserPackagesAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _packageService.GetAllUserPackagesAsync(userId, cancellationToken);
        }

        [HttpGet("package/{id}")]
        public async Task<PackageDto> GetPackageById(Guid id, CancellationToken cancellationToken)
        {
            return await _packageService.GetPackageByIdAsync(id, cancellationToken);
        }
    }
}
