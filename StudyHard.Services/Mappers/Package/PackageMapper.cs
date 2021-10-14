using StudyHard.Dto.Package;
using System.Collections.Generic;
using System.Linq;
using PackageEntity = StudyHard.Data.Entity.Package.Package;

namespace StudyHard.Services.Mappers.Package
{
    public static class PackageMapper
    {
        public static PackageEntity MaptToEntity(this PackageDto packageDto)
        {
            return new PackageEntity
            {
                Id = packageDto.Id,
                Description = packageDto.Description,
                IsActive = packageDto.IsActive,
                Name = packageDto.Name,
                Price = packageDto.Price
            };
        }

        public static PackageDto MapToDto(this PackageEntity package)
        {
            return new PackageDto
            {
                Id = package.Id,
                CreatedDateUTC = package.CreatedDateUTC.ToString("dd-MM-yyyy"),
                Description = package.Description,
                IsActive = package.IsActive,
                Name = package.Name,
                Price = package.Price
            };
        }

        public static List<PackageEntity> MapToEntities(this List<PackageDto> packageDtos)
        {
            if (packageDtos == null)
            {
                return new List<PackageEntity>();
            }

            return packageDtos.Select(x => x.MaptToEntity()).ToList();
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
