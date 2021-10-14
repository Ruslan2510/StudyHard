using System;

namespace StudyHard.ContentManagement.Dto.Blog
{
    public class BlogSectionDto
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public DateTime DatePublicationUTC { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public bool IsActive { get; set; }
        public string PreviewText { get; set; }
        public string Content { get; set; }
        public Guid? ImageId { get; set; }
        public string SEOKeywords { get; set; }
        public string SEODescription { get; set; }
    }
}
