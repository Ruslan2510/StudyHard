using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyHard.ContentManagement.Dto.Category;
using StudyHard.ContentManagement.Services.Category;
using StudyHard.ContentManagement.Services.Mappers.Category;
using StudyHard.Data.Entity.Category;
using StudyHard.Data.Entity.Subject;
using StudyHard.Data.Entity.Task;
using StudyHard.Data.Entity.Theory;
using StudyHard.Data.Repository;
using StudyHard.Tests.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Tests
{
    [TestClass]
    public class CategoryServiceTests : BaseTest
    {
        //CM methods start

        [TestMethod]
        public async Task CreateCategoryAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            var addedCategory = await _repository.CategoryDataAccess.GetCategoryByIdAsync(category.Id, tokenSource.Token);

            AreEquals(category, addedCategory);

            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task GetCategoryByIdAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            var categoryService = ServiceProvider.GetRequiredService<ICategoryService>();
            var currentCategory = await categoryService.GetCategoryByIdAsync(category.Id, tokenSource.Token);

            AreEquals(category, currentCategory.MapToEntity());

            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task DeleteCategoryAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);

            var currentCategory = await _repository.CategoryDataAccess.GetCategoryByIdAsync(category.Id, tokenSource.Token);

            Assert.IsNull(currentCategory);

            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task UpdateCategoryAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            category.CreatedDateUTC = DateTime.UtcNow;
            category.Name = "Updated category name";
            category.Theories = new List<Theory>();
            category.TaskLists = new List<TaskList>();
            category.Subject = subject;

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            var categoryService = ServiceProvider.GetRequiredService<ICategoryService>();

            await categoryService.UpdateCategoryAsync(category.MapToDto(), tokenSource.Token);

            var updatedCategory = await _repository.CategoryDataAccess.GetCategoryByIdAsync(category.Id, tokenSource.Token);

            AreEquals(category, updatedCategory);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task GetPaginatedCategoriesBySubjectIdTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            const int COUNT = 10;

            var categories = new List<Category>();

            for (int i = 0; i < COUNT; i++)
            {
                var category = CreateNewCategory(subject.Id);
                await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);
                categories.Add(category);
            }

            var categoryService = ServiceProvider.GetRequiredService<ICategoryService>();

            CategoryPaginationDto paginationDto = new CategoryPaginationDto
            {
                Page = 0,
                SubjectId = subject.Id
            };

            for (int i = 1; i < COUNT; i++)
            {
                paginationDto.PageSize = i;
                var categoryList = await categoryService.GetPaginatedCategoriesBySubjectId(paginationDto, tokenSource.Token);
                Assert.AreEqual(categoryList.PaginatedList.Count, i);
            }

            foreach (var item in categories)
            {
                await _repository.CategoryDataAccess.DeleteAsync(item, tokenSource.Token);
            }

            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        //CM methods end


        public Category CreateNewCategory(Guid subjectId)
        {
            return new Category
            {
                Name = "testNameCategory",
                CreatedDateUTC = DateTime.UtcNow,
                Theories = new List<Theory>(),
                TaskLists = new List<TaskList>(),
                SubjectId = subjectId
            };
        }

        public Subject CreateNewSubject()
        {
            return new Subject
            {
                CreatedDateUTC = DateTime.UtcNow,
                Name = "testNameSubject",
                IsActive = true
            };
        }

        public void AreEquals(Category firstCategory, Category secondCategory)
        {
            Assert.AreEqual(firstCategory.Id, secondCategory.Id);
            Assert.AreEqual(firstCategory.Name, secondCategory.Name);
            Assert.AreEqual(firstCategory.CreatedDateUTC, secondCategory.CreatedDateUTC);
            Equals(firstCategory.Subject, secondCategory.Subject);
            Equals(firstCategory.TaskLists, secondCategory.TaskLists);
            Equals(firstCategory.Theories, secondCategory.Theories);
        }
    }
}
