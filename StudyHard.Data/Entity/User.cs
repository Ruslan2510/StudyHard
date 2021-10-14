using StudyHard.Data.Entity.Exam;
using StudyHard.Data.Entity.Package;
using StudyHard.Data.Entity.Theory;
using System;
using System.Collections.Generic;

namespace StudyHard.Data.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        
        public int? UniversityId { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string TelegramUserName { get; set; }

        public List<UserPackage> UserPackages { get; set; }
        public List<ExamResult> ExamResults { get; set; }
        public University University { get; set; }
        public List<TheoryNote> TheoryNotes { get; set; }        
        public UserSession UserSession { get; set; }
    }
}
