using StudyHard.ContentManagement.Dto.Subject;
using System;

namespace StudyHard.ContentManagement.Dto.Package
{
    public class PackageConfigurationDto
    {
        public Guid Id { get; set; }
        public bool TheoryAvaliable { get; set; }
        public bool TasksAvaliable { get; set; }
        public Guid SubjectId { get; set; }
        public SubjectDto SubjectDto { get; set; }
        public Guid PackageId { get; set; }
    }
}