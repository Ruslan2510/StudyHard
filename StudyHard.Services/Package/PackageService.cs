using StudyHard.Data.Repository;
using StudyHard.Dto.Package;
using StudyHard.Services.Mappers.Package;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Services.Package
{
    public class PackageService : IPackageService
    {
        private readonly StudyHardRepository _repository;
        public PackageService(StudyHardRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PackageDto>> GetAllUserPackagesAsync(Guid userId, CancellationToken cancellationToken)
        {
            var result = await _repository.PackageDataAccess.GetAllUserPackagesAsync(userId, cancellationToken);
            return result.MapToDtos();
        }

        public async Task<PackageDto> GetPackageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var package = await _repository.PackageDataAccess.GetPackageByIdAsync(id, cancellationToken);
            return package.MapToDto();
        }
    }
}
