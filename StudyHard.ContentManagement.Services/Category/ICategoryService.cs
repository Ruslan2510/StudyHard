using StudyHard.Common.Dto;
using StudyHard.ContentManagement.Dto.Category;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.ContentManagement.Services.Category
{
    public interface ICategoryService
    {
        Task<PaginatedDto<CategoryDto>> GetPaginatedCategoriesBySubjectId(CategoryPaginationDto subjectPaginationDto, CancellationToken cancellationToken);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken);
        Task UpdateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken);
        Task DeleteCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken);
    }
}
