using StudyHard.Data.Entity.Exam;
using StudyHard.Data.Entity.Package;
using System;
using System.Collections.Generic;
using CategoryEntity = StudyHard.Data.Entity.Category.Category;

namespace StudyHard.Data.Entity.Subject
{
    public class Subject 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public PackageConfiguration PackageConfiguration { get; set; }

        public List<CategoryEntity> Categories { get; set; }
        public List<ExamResult> ExamResults { get; set; }
    }
}