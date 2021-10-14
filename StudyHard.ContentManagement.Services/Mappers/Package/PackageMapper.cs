using StudyHard.ContentManagement.Dto.Package;
using StudyHard.Data.Entity.Package;
using System.Collections.Generic;
using System.Linq;
using PackageEntity = StudyHard.Data.Entity.Package.Package;

namespace StudyHard.ContentManagement.Services.Mappers.Package
{
    public static class PackageMapper
    {
        public static PackageEntity MapToEntity(this PackageDto packageDto)
        {
            var packageConfigurations = new List<PackageConfigurationDto>();
            if (packageDto.PackageConfigurationDtos != null)
            {
                packageDto.PackageConfigurationDtos.ForEach(x => 
                {
                    packageConfigurations.Add(x);
                });
            }

            return new PackageEntity
            {
                Id = packageDto.Id,
                CreatedDateUTC = packageDto.CreatedDateUTC,
                Description = packageDto.Description,
                IsActive = packageDto.IsActive,
                Name = packageDto.Name,
                Price = packageDto.Price,
                PackageConfigurations = packageConfigurations.MapToEntities()
            };
        }

        public static PackageDto MapToDto(this PackageEntity package)
        {
            var packageConfigurations = new List<PackageConfiguration>();
            if (package.PackageConfigurations != null)
            {
                package.PackageConfigurations.ForEach(x =>
                {
                    packageConfigurations.Add(x);
                });
            }

            return new PackageDto
            {
                Id = package.Id,
                CreatedDateUTC = package.CreatedDateUTC,
                Description = package.Description,
                IsActive = package.IsActive,
                Name = package.Name,
                Price = package.Price,
                PackageConfigurationDtos = packageConfigurations.MapToDtos()
            };
        }

        public static List<PackageEntity> MapToEntities(this List<PackageDto> packageDtos)
        {
            if (packageDtos == null)
            {
                return new List<PackageEntity>();
            }

            return packageDtos.Select(x => x.MapToEntity()).ToList();
        }

        public static List<PackageDto> MapToDtos(this List<PackageEntity> packages)
        {
            if (packages == null)
            {
                return new List<PackageDto>();
            }

            return packages.Select(x => x.MapToDto()).ToList();
        }
    }
}
