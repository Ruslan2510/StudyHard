using StudyHard.Common.Dto;
using StudyHard.ContentManagement.Dto.Category;
using StudyHard.ContentManagement.Services.Mappers.Category;
using StudyHard.Data.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.ContentManagement.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly StudyHardRepository _repository;
        public CategoryService(StudyHardRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedDto<CategoryDto>> GetPaginatedCategoriesBySubjectId(CategoryPaginationDto subjectPaginationDto, CancellationToken cancellationToken)
        {
            var result = await _repository.CategoryDataAccess.GetPaginatedCategoriesBySubjectId(subjectPaginationDto.Page, subjectPaginationDto.PageSize,
                subjectPaginationDto.SubjectId, cancellationToken);

            return new PaginatedDto<CategoryDto>
            {
                Count = result.Count,
                PaginatedList = result.Elements.MapToDtos(),
                Page = subjectPaginationDto.Page,
                PageSize = subjectPaginationDto.PageSize
            };
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _repository.CategoryDataAccess.GetCategoryByIdAsync(id, cancellationToken);
            return category.MapToDto();
        }

        public async Task CreateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            categoryDto.CreatedDateUTC = DateTime.UtcNow;
            var category = categoryDto.MapToEntity();
            await _repository.CategoryDataAccess.AddAsync(category, cancellationToken);
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = categoryDto.MapToEntity();
            await _repository.CategoryDataAccess.UpdateCategoryAsync(category, cancellationToken);
        }

        public async Task DeleteCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = categoryDto.MapToEntity();
            await _repository.CategoryDataAccess.DeleteAsync(category, cancellationToken);
        }
    }
}
