using Microsoft.AspNetCore.Mvc;
using StudyHard.ContentManagement.Dto.Package;
using StudyHard.ContentManagement.Services.Package;
using StudyHard.Web.Filters;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Web.Controllers.ContentManagment.Package
{
    [Route("api/[controller]")]
    [ApiController]
    //[ItlegAuthorizationFilter]
    public class CMPackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public CMPackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet("packageslist")]
        public async Task<List<PackageDto>> GetAllPackagesAsync(CancellationToken cancellationToken)
        {
            return await _packageService.GetAllPackagesAsync(cancellationToken);
        }

        [HttpPost("package")]
        public async Task CreatePackageAsync(PackageDto packageDto, CancellationToken cancellationToken)
        {
            await _packageService.CreatePackageAsync(packageDto, cancellationToken);
        }

        [HttpPost("packageupdate")]
        public async Task UpdatePackageAsync(PackageDto packageDto, CancellationToken cancellationToken)
        {
            await _packageService.UpdatePackageAsync(packageDto, cancellationToken);
        }

        [HttpGet("package/{id}/changeactive")]
        public async Task ChangePackagePropertyActiveAsync(Guid id, CancellationToken cancellationToken)
        {
            await _packageService.ChangePropertyActivePackageAsync(id, cancellationToken);
        }

        [HttpGet("package/{id}")]
        public async Task<PackageDto> GetPackageById(Guid id, CancellationToken cancellationToken)
        {
            return await _packageService.GetPackageByIdAsync(id, cancellationToken);
        }
    }
}
