using System;
using System.Collections.Generic;

namespace StudyHard.Data.Entity
{
    public class University
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<User> User { get; set; }
    }
}