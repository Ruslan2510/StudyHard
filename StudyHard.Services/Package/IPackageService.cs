using StudyHard.Dto.Package;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.Package
{
    public interface IPackageService
    {
        Task<List<PackageDto>> GetAllUserPackagesAsync(Guid userId, CancellationToken cancellationToken);
        Task<PackageDto> GetPackageByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
