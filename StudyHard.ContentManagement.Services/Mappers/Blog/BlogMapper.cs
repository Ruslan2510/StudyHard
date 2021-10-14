using StudyHard.ContentManagement.Dto.Blog;
using StudyHard.Data.Entity.Blog;
using System.Collections.Generic;
using System.Linq;

namespace StudyHard.ContentManagement.Services.Mappers.Blog
{
    public static class BlogMapper
    {
        public static BlogSection MapToEntity(this BlogSectionDto blogSectionDto)
        {
            return new BlogSection
            {
                Id = blogSectionDto.Id,
                Content = blogSectionDto.Content,
                CreatedDateUTC = blogSectionDto.CreatedDateUTC,
                DatePublicationUTC = blogSectionDto.DatePublicationUTC,
                Heading = blogSectionDto.Heading,
                ImageId = blogSectionDto.ImageId,
                IsActive = blogSectionDto.IsActive,
                PreviewText = blogSectionDto.PreviewText,
                SEODescription = blogSectionDto.SEODescription,
                SEOKeywords = blogSectionDto.SEOKeywords
            };
        }

        public static List<BlogSection> MapToEntity(this List<BlogSectionDto> blogSectionDtos)
        {
            if (blogSectionDtos == null)
            {
                return new List<BlogSection>();
            }

            return blogSectionDtos.Select(x => x.MapToEntity()).ToList();
        }

        public static BlogSectionDto MapToDto(this BlogSection blogSection)
        {
            return new BlogSectionDto
            {
                Id = blogSection.Id,
                Content = blogSection.Content,
                CreatedDateUTC = blogSection.CreatedDateUTC,
                DatePublicationUTC = blogSection.DatePublicationUTC,
                ImageId = blogSection.ImageId,
                Heading = blogSection.Heading,
                IsActive = blogSection.IsActive,
                PreviewText = blogSection.PreviewText,
                SEODescription = blogSection.SEODescription,
                SEOKeywords = blogSection.SEOKeywords
            };
        }

        public static List<BlogSectionDto> MapToDto(this List<BlogSection> blogSections)
        {
            if (blogSections == null)
            {
                return new List<BlogSectionDto>();
            }

            return blogSections.Select(x => x.MapToDto()).ToList();
        }
    }
}
