using StudyHard.ContentManagement.Dto.Theory;
using System.Collections.Generic;
using System.Linq;
using TheoryEntity = StudyHard.Data.Entity.Theory.Theory;

namespace StudyHard.ContentManagement.Services.Mappers.Theory
{
    public static class TheoryMapper
    {
        public static TheoryEntity MapToEntity(this TheoryDto theoryDto)
        {
            return new TheoryEntity
            {
                Id = theoryDto.Id,
                CategoryId = theoryDto.CategoryId,
                Content = theoryDto.Content,
                CreatedDateUTC = theoryDto.CreatedDateUTC,
                Name = theoryDto.Name
            };
        }

        public static TheoryDto MapToDto(this TheoryEntity theory)
        {
            return new TheoryDto
            {
                Id = theory.Id,
                CategoryId = theory.CategoryId,
                Content = theory.Content,
                CreatedDateUTC = theory.CreatedDateUTC,
                Name = theory.Name
            };
        }

        public static List<TheoryEntity> MapToEntities(this List<TheoryDto> theoryDtos)
        {
            if (theoryDtos == null)
            {
                return new List<TheoryEntity>();
            }

            return theoryDtos.Select(x => x.MapToEntity()).ToList();
        }

        public static List<TheoryDto> MapToDtos(this List<TheoryEntity> theories)
        {
            if (theories == null)
            {
                return new List<TheoryDto>();
            }

            return theories.Select(x => x.MapToDto()).ToList();
        }
    }
}