using StudyHard.ContentManagement.Dto.Package;
using StudyHard.ContentManagement.Services.Mappers.Subject;
using StudyHard.Data.Entity.Package;
using System.Collections.Generic;
using System.Linq;

namespace StudyHard.ContentManagement.Services.Mappers.Package
{
    public static class PackageConfigurationMapper
    {
        public static PackageConfiguration MapToEntity(this PackageConfigurationDto packageConfigDto)
        {
            return new PackageConfiguration
            {
                Id = packageConfigDto.Id,
                TasksAvaliable = packageConfigDto.TasksAvaliable,
                TheoryAvaliable = packageConfigDto.TheoryAvaliable,
                PackageId = packageConfigDto.PackageId,
                SubjectId = packageConfigDto.SubjectId
            };
        }

        public static PackageConfigurationDto MapToDto(this PackageConfiguration packageConfig)
        {
            return new PackageConfigurationDto
            {
                Id = packageConfig.Id,
                TheoryAvaliable = packageConfig.TheoryAvaliable,
                TasksAvaliable = packageConfig.TasksAvaliable,
                PackageId = packageConfig.PackageId,
                SubjectId = packageConfig.SubjectId,
                SubjectDto = packageConfig.Subject.MapToDto()
            };
        }

        public static List<PackageConfiguration> MapToEntities(this List<PackageConfigurationDto> packageConfigDtos)
        {
            if (packageConfigDtos == null)
            {
                return new List<PackageConfiguration>();
            }

            return packageConfigDtos.Select(x => x.MapToEntity()).ToList();
        }

        public static List<PackageConfigurationDto> MapToDtos(this List<PackageConfiguration> packageConfig)
        {
            if (packageConfig == null)
            {
                return new List<PackageConfigurationDto>();
            }

            return packageConfig.Select(x => x.MapToDto()).ToList();
        }
    }
}