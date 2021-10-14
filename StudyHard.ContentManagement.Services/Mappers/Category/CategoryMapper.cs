using StudyHard.ContentManagement.Dto.Category;
using System.Collections.Generic;
using System.Linq;
using CategoryEntity = StudyHard.Data.Entity.Category.Category;

namespace StudyHard.ContentManagement.Services.Mappers.Category
{
    public static class CategoryMapper
    {
        public static CategoryEntity MapToEntity(this CategoryDto categoryDto)
        {
            return new CategoryEntity
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                CreatedDateUTC = categoryDto.CreatedDateUTC,
                SubjectId = categoryDto.SubjectId,
            };
        }

        public static CategoryDto MapToDto(this CategoryEntity category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                CreatedDateUTC = category.CreatedDateUTC,
                Name = category.Name,
                SubjectId = category.SubjectId,
            };
        }

        public static List<CategoryEntity> MapToEntities(this List<CategoryDto> categoryDtos)
        {
            if (categoryDtos == null)
            {
                return new List<CategoryEntity>();
            }

            return categoryDtos.Select(x => x.MapToEntity()).ToList();
        }

        public static List<CategoryDto> MapToDtos(this List<CategoryEntity> categories)
        {
            if (categories == null)
            {
                return new List<CategoryDto>();
            }

            return categories.Select(x => x.MapToDto()).ToList();
        }
    }
}
