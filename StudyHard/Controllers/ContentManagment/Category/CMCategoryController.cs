using Microsoft.AspNetCore.Mvc;
using StudyHard.Common.Dto;
using StudyHard.ContentManagement.Dto.Category;
using StudyHard.ContentManagement.Services.Category;
using StudyHard.Web.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Web.Controllers.ContentManagment.Category
{
    [Route("api/[controller]")]
    [ApiController]
    [ItlegAuthorizationFilter]
    public class CMCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CMCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("categorylist")]
        public async Task<PaginatedDto<CategoryDto>> GetPaginatedCategoriesAsync(CategoryPaginationDto categoryPaginationDto, CancellationToken cancellationToken)
        {
            return await _categoryService.GetPaginatedCategoriesBySubjectId(categoryPaginationDto, cancellationToken);
        }

        [HttpPost("category")]
        public async Task CreateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            await _categoryService.CreateCategoryAsync(categoryDto, cancellationToken);
        }

        [HttpPost("categoryupdate")]
        public async Task UpdateCategoryAsync(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            await _categoryService.UpdateCategoryAsync(categoryDto, cancellationToken);
        }

    }
}
