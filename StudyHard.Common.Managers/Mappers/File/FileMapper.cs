using StudyHard.Common.Dto.File;
using System.Collections.Generic;
using System.Linq;
using FileEntity = StudyHard.Data.Entity.File;

namespace StudyHard.Common.Managers.Mappers.File
{
    public static class FileMapper
    {
        public static FileEntity MapToEntity(this FileDto fileDto)
        {
            return new FileEntity
            {
                Id = fileDto.Id,
                Extention = fileDto.Extention,
                Name = fileDto.Name,
            };
        }

        public static List<FileEntity> MapToEntity(this List<FileDto> fileDtos)
        {
            if (fileDtos == null)
            {
                return new List<FileEntity>();
            }

            return fileDtos.Select(x => x.MapToEntity()).ToList();
        }

        public static FileDto MapToDto(this FileEntity file)
        {
            return new FileDto
            {
                Id = file.Id,
                Extention = file.Extention,
                Name = file.Name,
            };
        }

        public static List<FileDto> MapToDto(this List<FileEntity> files)
        {
            if (files == null)
            {
                return new List<FileDto>();
            }

            return files.Select(x => x.MapToDto()).ToList();
        }
    }
}