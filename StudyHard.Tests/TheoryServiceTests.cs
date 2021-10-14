using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyHard.ContentManagement.Dto.Theory;
using StudyHard.ContentManagement.Services.Mappers.Theory;
using StudyHard.ContentManagement.Services.Theory;
using StudyHard.Data.Entity.Category;
using StudyHard.Data.Entity.Subject;
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
    public class TheoryServiceTests : BaseTest
    {
        //CM methods start
        [TestMethod]
        public async Task CreateTheoryAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);

            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            Theory theory = CreateNewTheory(category.Id);

            await _repository.TheoryDataAccess.AddAsync(theory, tokenSource.Token);

            var addedTheory = await _repository.TheoryDataAccess.GetTheoryByIdAsync(theory.Id, tokenSource.Token);

            AreEquals(addedTheory, theory);

            await _repository.TheoryDataAccess.DeleteAsync(theory, tokenSource.Token);
            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task GetTheoryByIdAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            Theory theory = CreateNewTheory(category.Id);
            await _repository.TheoryDataAccess.AddAsync(theory, tokenSource.Token);

            var theoryService = ServiceProvider.GetRequiredService<ITheoryService>();
            var currentTheory = await theoryService.GetTheoryByIdAsync(theory.Id, tokenSource.Token);

            AreEquals(currentTheory.MapToEntity(), theory);

            await _repository.TheoryDataAccess.DeleteAsync(theory, tokenSource.Token);
            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task DeleteTheoryAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            Theory theory = CreateNewTheory(category.Id);
            await _repository.TheoryDataAccess.AddAsync(theory, tokenSource.Token);

            await _repository.TheoryDataAccess.DeleteAsync(theory, tokenSource.Token);

            var currentTheory = await _repository.TheoryDataAccess.GetTheoryByIdAsync(theory.Id, tokenSource.Token);

            Assert.IsNull(currentTheory);

            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task UpdateTheoryAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            Theory theory = CreateNewTheory(category.Id);
            await _repository.TheoryDataAccess.AddAsync(theory, tokenSource.Token);

            theory.Name = "updatedTestNameTheory";
            theory.Content = "updatedtestContentTheory";
            theory.CreatedDateUTC = DateTime.UtcNow;
            theory.CategoryId = category.Id;
            theory.Category = category;

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            var theoryService = ServiceProvider.GetRequiredService<ITheoryService>();

            await theoryService.UpdateTheoryAsync(theory.MapToDto(), tokenSource.Token);

            var updatedTheory = await _repository.TheoryDataAccess.GetTheoryByIdAsync(theory.Id, tokenSource.Token);

            AreEquals(theory, updatedTheory);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            await _repository.TheoryDataAccess.DeleteAsync(theory, tokenSource.Token);
            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task TheoryByCategoryIdTurnPaginationAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();

            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            Category category = CreateNewCategory(subject.Id);

            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            const int COUNT = 10;

            var theories = new List<Theory>();

            for (int i = 0; i < COUNT; i++)
            {
                var theory = CreateNewTheory(category.Id);
                await _repository.TheoryDataAccess.AddAsync(theory, tokenSource.Token);
                theories.Add(theory);
            }

            var theoryService = ServiceProvider.GetRequiredService<ITheoryService>();
            
            TheoryPaginationDto paginationDto = new TheoryPaginationDto
            {
                Page = 0,
                CategoryId = category.Id
            };

            for (int i = 1; i < COUNT; i++)
            {
                paginationDto.PageSize = i;
                var theoryList = await theoryService.GetPaginatedTheoriesByCategoryIdAsync(paginationDto, tokenSource.Token);
                Assert.AreEqual(theoryList.PaginatedList.Count, i);
            }

            foreach (var item in theories)
            {
                await _repository.TheoryDataAccess.DeleteAsync(item, tokenSource.Token);
            }

            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        [TestMethod]
        public async Task TheoryPaginationAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Subject subject = CreateNewSubject();
            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);
            
            Category category = CreateNewCategory(subject.Id);
            await _repository.CategoryDataAccess.AddAsync(category, tokenSource.Token);

            var theoryList = new List<Theory>();

            const int THEORYCOUNT = 6;

            for(int i = 0; i < THEORYCOUNT; i++)
            {
                var theory = CreateNewTheory(category.Id);
                await _repository.TheoryDataAccess.AddAsync(theory, tokenSource.Token);
                theoryList.Add(theory);
            }

            var theoryService = ServiceProvider.GetRequiredService<ITheoryService>();

            TheoryPaginationDto paginationDto = new TheoryPaginationDto
            {
                Page = 0,
                PageSize = int.MaxValue,
                CategoryId = category.Id
            };

            var theories = await theoryService.GetPaginatedTheoriesByCategoryIdAsync(paginationDto, tokenSource.Token);

            paginationDto.PageSize = theories.Count - 1;

            var paginatedTheories = await theoryService.GetPaginatedTheoriesByCategoryIdAsync(paginationDto, tokenSource.Token);

            Assert.AreEqual(theories.Count, paginatedTheories.PaginatedList.Count + 1);

            foreach (var item in theoryList)
            {
                await _repository.TheoryDataAccess.DeleteAsync(item, tokenSource.Token);
            }

            await _repository.CategoryDataAccess.DeleteAsync(category, tokenSource.Token);
            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);
        }

        //CM methods end

        public Theory CreateNewTheory(Guid categoryId)
        {
            return new Theory
            {
                Name = "testNameTheory",
                Content = "testContentTheory",
                CreatedDateUTC = DateTime.UtcNow,
                CategoryId = categoryId
            };
        }

        public Category CreateNewCategory(Guid subjectId)
        {
            return new Category
            {
                Name = "testNameCategory",
                SubjectId = subjectId,
                CreatedDateUTC = DateTime.UtcNow
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

        public void AreEquals(Theory firstTheory, Theory secondTheory)
        {
            Assert.AreEqual(firstTheory.Id, secondTheory.Id);
            Assert.AreEqual(firstTheory.Name, secondTheory.Name);
            Assert.AreEqual(firstTheory.CreatedDateUTC, secondTheory.CreatedDateUTC);
            Assert.AreEqual(firstTheory.Content, secondTheory.Content);
            Assert.AreEqual(firstTheory.CategoryId, secondTheory.CategoryId);
        }
    }
}
