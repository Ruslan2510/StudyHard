using StudyHard.ContentManagement.Dto.Package;
using StudyHard.ContentManagement.Services.Mappers.Package;
using StudyHard.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.ContentManagement.Services.Package
{
    public class PackageService : IPackageService
    {
        private readonly StudyHardRepository _repository;
        public PackageService(StudyHardRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PackageDto>> GetAllPackagesAsync(CancellationToken cancellationToken)
        {
            var result =  await _repository.PackageDataAccess.GetAllPackagesAsync(cancellationToken);
            return result.MapToDtos();
        }

        public async Task CreatePackageAsync(PackageDto packageDto, CancellationToken cancellationToken)
        {
            packageDto.CreatedDateUTC = DateTime.UtcNow;
            var package = packageDto.MapToEntity();
            await _repository.PackageDataAccess.AddAsync(package, cancellationToken);
        }

        public async Task UpdatePackageAsync(PackageDto packageDto, CancellationToken cancellationToken)
        {
            var package = packageDto.MapToEntity();
            await _repository.PackageDataAccess.UpdatePackageAsync(package, cancellationToken);
        }

        public async Task ChangePropertyActivePackageAsync(Guid id, CancellationToken cancellationToken)
        {
            var package = await _repository.PackageDataAccess.GetPackageByIdAsync(id, cancellationToken);
            package.IsActive = !package.IsActive;
            await _repository.PackageDataAccess.ChangePackagePropertyActiveAsync(package, cancellationToken);
        }

        public async Task<PackageDto> GetPackageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var package = await _repository.PackageDataAccess.GetPackageByIdAsync(id, cancellationToken);
            return package.MapToDto();
        }
    }
}