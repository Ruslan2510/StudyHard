using System;

namespace StudyHard.Data.Entity
{
    public class UserSession
    {
        public Guid Id { get; set; }
        public string SessionId { get; set; }
        public string LastLoginDateUTC { get; set; }

        public User User { get; set; }
    }
}