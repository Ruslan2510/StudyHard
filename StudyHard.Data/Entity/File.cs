using StudyHard.Data.Entity.Blog;
using System;
using System.Collections.Generic;

namespace StudyHard.Data.Entity
{
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public State State { get; set; }
        public string ErrorMessage { get; set; }

        public List<BlogSection> BlogSections { get; set; }
    }

    public enum State
    {
        InProcess = 1,
        Done = 2,
        Error = 3
    }
}