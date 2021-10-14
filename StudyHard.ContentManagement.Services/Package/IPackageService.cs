using StudyHard.ContentManagement.Dto.Package;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.ContentManagement.Services.Package
{
    public interface IPackageService
    {
        Task<List<PackageDto>> GetAllPackagesAsync(CancellationToken cancellationToken);
        Task CreatePackageAsync(PackageDto packageDto, CancellationToken cancellationToken);
        Task UpdatePackageAsync(PackageDto packageDto, CancellationToken cancellationToken);
        Task ChangePropertyActivePackageAsync(Guid id, CancellationToken cancellationToken);
        Task<PackageDto> GetPackageByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
