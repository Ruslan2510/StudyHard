using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyHard.Common.Dto;
using StudyHard.ContentManagement.Services.Mappers.Subject;
using StudyHard.Data.Entity.Category;
using StudyHard.Data.Entity.Exam;
using StudyHard.Data.Entity.Package;
using StudyHard.Data.Entity.Subject;
using StudyHard.Data.Repository;
using StudyHard.Services.ContentManagment.Subject;
using StudyHard.Tests.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyHard.Tests
{
    [TestClass]
    public class SubjectServiceTests : BaseTest
    {
        //CM methods start
        [TestMethod]
        public async Task CreateSubjectAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var package = CreateNewPackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            Subject subject = CreateNewSubject(package);

            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            var addedSubject = await _repository.SubjectDataAccess.GetSubjectByIdAsync(subject.Id, tokenSource.Token);

            AreEquals(subject, addedSubject);

            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        [TestMethod]
        public async Task UpdateSubjectAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var package = CreateNewPackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            Subject subject = CreateNewSubject(package);

            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            subject.Name = "Updated subject name";
            subject.IsActive = !subject.IsActive;
            subject.CreatedDateUTC = DateTime.UtcNow;

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            var subjectService = ServiceProvider.GetRequiredService<ISubjectService>();

            await subjectService.UpdateSubjectAsync(subject.MapToDto(), tokenSource.Token);

            var updatedSubject = await _repository.SubjectDataAccess.GetSubjectByIdAsync(subject.Id, tokenSource.Token);

            AreEquals(subject, updatedSubject);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        [TestMethod]
        public async Task GetSubjectByIdAsync()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var package = CreateNewPackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            Subject subject = CreateNewSubject(package);

            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            var subjectService = ServiceProvider.GetRequiredService<ISubjectService>();

            var currentSubject = await subjectService.GetSubjectByIdAsync(subject.Id, tokenSource.Token);

            AreEquals(subject, currentSubject.MapToEntity());

            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        [TestMethod]
        public async Task ChangeSubjectPropertyActiveAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var package = CreateNewPackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            Subject subject = CreateNewSubject(package);

            await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);

            var subjectService = ServiceProvider.GetRequiredService<ISubjectService>();

            await subjectService.ChangePropertyActiveSubjectAsync(subject.Id, tokenSource.Token);

            var currentSubject = await _repository.SubjectDataAccess.GetSubjectByIdAsync(subject.Id, tokenSource.Token);

            Assert.AreEqual(subject.IsActive, currentSubject.IsActive);

            await _repository.SubjectDataAccess.DeleteAsync(subject, tokenSource.Token);

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        [TestMethod]
        public async Task SubjectPaginationAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var subjectList = new List<Subject>();

            const int SUBJECTCOUNT = 6;

            var package = CreateNewPackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            for (int i = 0; i < SUBJECTCOUNT; i++)
            {
                var subject = CreateNewSubject(package);
                await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);
                subjectList.Add(subject);
            }

            var subjectService = ServiceProvider.GetRequiredService<ISubjectService>();

            PaginationDto paginationDto = new PaginationDto
            {
                Page = 0,
                PageSize = int.MaxValue
            };

            var subjects = await subjectService.GetPaginatedSubjectsAsync(paginationDto, tokenSource.Token);

            paginationDto.PageSize = subjects.Count - 1;

            var paginatedSubjects = await subjectService.GetPaginatedSubjectsAsync(paginationDto, tokenSource.Token);

            Assert.AreEqual(subjects.Count, paginatedSubjects.PaginatedList.Count + 1);

            foreach (var item in subjectList)
            {
                await _repository.SubjectDataAccess.DeleteAsync(item, tokenSource.Token);
            }

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        [TestMethod]
        public async Task SubjectTurnPaginationAsync()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            const int SUBJECTCOUNT = 10;

            var subjects = new List<Subject>();

            var package = CreateNewPackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            for (int i = 0; i < SUBJECTCOUNT; i++)
            {
                var subject = CreateNewSubject(package);
                await _repository.SubjectDataAccess.AddAsync(subject, tokenSource.Token);
                subjects.Add(subject);
            }

            var subjectService = ServiceProvider.GetRequiredService<ISubjectService>();

            PaginationDto paginationDto = new PaginationDto
            {
                Page = 0
            };

            for (int i = 1; i < SUBJECTCOUNT; i++)
            {
                paginationDto.PageSize = i;
                var subjectList = await subjectService.GetPaginatedSubjectsAsync(paginationDto, tokenSource.Token);
                Assert.AreEqual(subjectList.PaginatedList.Count, i);
            }

            foreach (var item in subjects)
            {
                await _repository.SubjectDataAccess.DeleteAsync(item, tokenSource.Token);
            }

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }


        //CM methods end

        public Subject CreateNewSubject(Package package)
        {
            return new Subject
            {
                Name = "testsubject",
                CreatedDateUTC = DateTime.UtcNow,
                IsActive = true,
                Categories = new List<Category>(),
                ExamResults = new List<ExamResult>(),
                PackageConfiguration = new PackageConfiguration()
                {
                    PackageId = package.Id
                }
            };
        }

        public Package CreateNewPackage()
        {
            return new Package
            {
                CreatedDateUTC = DateTime.UtcNow,
                Description = "Test Package",
                IsActive = true,
                Name = "Test package Name",
                PackageConfigurations = new List<PackageConfiguration>(),
                Price = 200,
                UserPackages = new List<UserPackage>()
            };
        }
        
        public void AreEquals(Subject firstSubject, Subject secondSubject)
        {
            Assert.AreEqual(firstSubject.Id, secondSubject.Id);
            Assert.AreEqual(firstSubject.IsActive, secondSubject.IsActive);
            Assert.AreEqual(firstSubject.CreatedDateUTC, secondSubject.CreatedDateUTC);
            Equals(firstSubject.Categories, secondSubject.Categories);
            Equals(firstSubject.ExamResults, secondSubject.ExamResults);
            Equals(firstSubject.PackageConfiguration, secondSubject.PackageConfiguration);
        }
    }
}
