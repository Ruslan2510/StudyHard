using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.File;
using StudyHard.Common.Managers.Mappers.File;
using StudyHard.ContentManagement.Services.Blog;
using StudyHard.Data.Entity.Blog;
using StudyHard.Data.Repository;
using StudyHard.Tests.Infra;
using StudyHard.ContentManagement.Services.Mappers.Blog;

namespace StudyHard.Tests
{
    [TestClass]
    public class BlogServiceTests : BaseTest
    {
        //CM methods
        [TestMethod]
        public async Task BlogPaginationTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var blogService = ServiceProvider.GetRequiredService<IBlogService>();

            var blogList = new List<BlogSection>();

            const int BLOGCOUNT = 6;

            for (int i = 0; i < BLOGCOUNT; i++)
            {
                BlogSection blogSection = CreateNewBlog();

                await _repository.BlogDataAccess.AddAsync(blogSection, tokenSource.Token);

                RenewServiceProvider();

                _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

                blogList.Add(blogSection);
            }

            PaginationDto paginationDto = new PaginationDto
            {
                Page = 0,
                PageSize = int.MaxValue
            };

            var blogSections = await blogService.GetPaginatedBlogsAsync(paginationDto, tokenSource.Token);

            paginationDto.PageSize = blogSections.Count - 1;

            var pagingBlogSections = await blogService.GetPaginatedBlogsAsync(paginationDto, tokenSource.Token);

            Assert.AreEqual(blogSections.Count, pagingBlogSections.PaginatedList.Count + 1);

            foreach (var item in blogList)
            {
                await _repository.BlogDataAccess.DeleteAsync(item, tokenSource.Token);
            }
        }

        [TestMethod]
        public async Task BlogTurnPaginationAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var blogService = ServiceProvider.GetRequiredService<IBlogService>();

            var blogList = new List<BlogSection>();

            const int BLOGCOUNT = 10;

            for (int i = 0; i < BLOGCOUNT; i++)
            {
                BlogSection blogSection = CreateNewBlog();

                await _repository.BlogDataAccess.AddAsync(blogSection, tokenSource.Token);

                RenewServiceProvider();

                _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

                blogList.Add(blogSection);
            }

            PaginationDto paginationDto = new PaginationDto
            {
                Page = 0
            };

            for (int i = 1; i < BLOGCOUNT; i++)
            {
                paginationDto.PageSize = i;
                var blogSections = await blogService.GetPaginatedBlogsAsync(paginationDto, tokenSource.Token);
                Assert.AreEqual(blogSections.PaginatedList.Count, i);
            }

            foreach (var item in blogList)
            {
                await _repository.BlogDataAccess.DeleteAsync(item, tokenSource.Token);
            }
        }

        [TestMethod]
        public async Task UpdateBlogAndGetAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            BlogSection blogSection = CreateNewBlog();

            await _repository.BlogDataAccess.AddAsync(blogSection, tokenSource.Token);
            var blogId = blogSection.Id;

            blogSection.Heading = "updated text";
            blogSection.DatePublicationUTC = DateTime.UtcNow;
            blogSection.IsActive = !blogSection.IsActive;
            blogSection.PreviewText = "updatedBlogSection preview text";
            blogSection.Content = "updated content";
            blogSection.SEOKeywords = "updated SEOKeywords";
            blogSection.SEODescription = "updated SEODescription";

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            var blogService = ServiceProvider.GetRequiredService<IBlogService>();
            await blogService.UpdateBlogAsync(blogSection.MapToDto(), tokenSource.Token);

            var updatedBlogSection = await _repository.BlogDataAccess.GetByIdAsync(blogId, tokenSource.Token);

            AreEquals(updatedBlogSection, blogSection);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            await _repository.BlogDataAccess.DeleteAsync(blogSection, tokenSource.Token);
        }

        [TestMethod]
        public async Task CreateBlogAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            BlogSection blogSection = CreateNewBlog();

            await _repository.BlogDataAccess.AddAsync(blogSection, tokenSource.Token);
            var blogId = blogSection.Id;

            var addedBlogSection = await _repository.BlogDataAccess.GetByIdAsync(blogId, tokenSource.Token);

            AreEquals(addedBlogSection, blogSection);

            await _repository.BlogDataAccess.DeleteAsync(blogSection, tokenSource.Token);
        }

        [TestMethod]
        public async Task ChangeBlogPropertyActiveAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            BlogSection blogSection = CreateNewBlog();

            await _repository.BlogDataAccess.AddAsync(blogSection, tokenSource.Token);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            var blogService = ServiceProvider.GetRequiredService<IBlogService>();
            await blogService.ChangeBlogPropertyActiveAsync(blogSection.Id, tokenSource.Token);

            var renewedBlogSection = await _repository.BlogDataAccess.GetByIdAsync(blogSection.Id, tokenSource.Token);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            Assert.AreEqual(blogSection.IsActive, !renewedBlogSection.IsActive);

            await _repository.BlogDataAccess.DeleteAsync(blogSection, tokenSource.Token);
        }

        //CM methods end



        //Client methods

        //Client methods end
        

        [TestMethod]
        public async Task GetBlogSectionByIdAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            BlogSection blogSection = CreateNewBlog();

            await _repository.BlogDataAccess.AddAsync(blogSection, tokenSource.Token);
            var blogId = blogSection.Id;

            var blogService = ServiceProvider.GetRequiredService<IBlogService>();
            var currentBlogSection = await blogService.GetBlogSectionByIdAsync(blogId, tokenSource.Token);

            AreEquals(currentBlogSection.MapToEntity(), blogSection);

            await _repository.BlogDataAccess.DeleteAsync(blogSection, tokenSource.Token);
        }

        public BlogSection CreateNewBlog()
        {
            return new BlogSection
            {
                Heading = "TestOfBlogCreation",
                DatePublicationUTC = DateTime.UtcNow,
                CreatedDateUTC = DateTime.UtcNow,
                IsActive = true,
                PreviewText = "Test of blog section creating",
                ImageId = null,
                Content = "Blog section test",
                SEOKeywords = "SEO keywords test",
                SEODescription = "SEO description test"
            };
        }

        public void AreEquals(BlogSection firstBlogSection, BlogSection secondBlogSection)
        {
            Assert.AreEqual(firstBlogSection.Id, secondBlogSection.Id);
            Assert.AreEqual(firstBlogSection.Content, secondBlogSection.Content);
            Assert.AreEqual(firstBlogSection.Heading, secondBlogSection.Heading);
            Assert.AreEqual(firstBlogSection.IsActive, secondBlogSection.IsActive);
            Assert.AreEqual(firstBlogSection.DatePublicationUTC, secondBlogSection.DatePublicationUTC);
            Assert.AreEqual(firstBlogSection.CreatedDateUTC, secondBlogSection.CreatedDateUTC);
            Assert.AreEqual(firstBlogSection.ImageId, secondBlogSection.ImageId);
            Assert.AreEqual(firstBlogSection.PreviewText, secondBlogSection.PreviewText);
            Assert.AreEqual(firstBlogSection.SEOKeywords, secondBlogSection.SEOKeywords);
            Assert.AreEqual(firstBlogSection.SEODescription, secondBlogSection.SEODescription);
        }

        [TestMethod]
        public async Task AddAndGetBlobAsyncTest()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            string name = "test";
            string ext = ".txt";

            using (StreamWriter sw = new StreamWriter($"{name}{ext}"))
            {
                sw.WriteLine("test");
            }

            IBlogService blogService = null;
            Guid fileId;

            using (Stream stream = new MemoryStream())
            {
                using (FileStream fileStream = new FileStream($"{name}{ext}", FileMode.Open))
                {
                    byte[] bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, (int)fileStream.Length);
                    stream.Write(bytes, 0, (int)fileStream.Length);

                    blogService = ServiceProvider.GetRequiredService<IBlogService>();

                    fileId = await blogService.AddBlobAsync(stream, name, ext, tokenSource.Token);

                    var blob = await blogService.GetBlobAsync(fileId, tokenSource.Token);

                    using (var ms = new MemoryStream())
                    {
                        blob.File.CopyTo(ms);
                        ms.ToArray();

                        Assert.AreEqual(bytes.Length, ms.Length);
                    }
                }
            }

            Data.Entity.File file = new Data.Entity.File
            {
                Id = fileId,
                Name = name,
                Extention = ext,
                State = Data.Entity.State.Done
            };

            RenewServiceProvider();
            blogService = ServiceProvider.GetRequiredService<IBlogService>();

            await blogService.DeleteBlobAsync(file.MapToDto(), tokenSource.Token);

            File.Delete($"{name}{ext}");
        }

        [TestMethod]
        public async Task DeleteBlobAsyncTest()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            string name = "test";
            string ext = ".txt";

            using (StreamWriter sw = new StreamWriter($"{name}{ext}"))
            {
                sw.WriteLine("test");
            }

            Guid fileId;
            IBlogService blogService = null;

            using (Stream stream = new MemoryStream())
            {
                using (FileStream fileStream = new FileStream($"{name}{ext}", FileMode.Open))
                {
                    byte[] bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, (int)fileStream.Length);
                    stream.Write(bytes, 0, (int)fileStream.Length);

                    RenewServiceProvider();
                    blogService = ServiceProvider.GetRequiredService<IBlogService>();

                    fileId = await blogService.AddBlobAsync(stream, name, ext, tokenSource.Token);
                }
            }

            var blob = await blogService.GetBlobAsync(fileId, tokenSource.Token);

            FileDto fileDto = new FileDto
            {
                Id = fileId,
                Name = name,
                Extention = ext,
            };

            RenewServiceProvider();
            blogService = ServiceProvider.GetRequiredService<IBlogService>();

            await blogService.DeleteBlobAsync(fileDto, tokenSource.Token);

            await Assert.ThrowsExceptionAsync<NullReferenceException>(async() => 
            { 
                await blogService.GetBlobAsync(fileDto.Id, tokenSource.Token); 
            });
        }
    }
}