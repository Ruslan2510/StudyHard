using System;

namespace StudyHard.Data.Entity.Package
{
    public class PackageConfiguration
    {
        public Guid Id { get; set; }
        public bool TheoryAvaliable { get; set; }
        public bool TasksAvaliable { get; set; }

        public Guid SubjectId { get; set; }
        public Subject.Subject Subject { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }
    }
}