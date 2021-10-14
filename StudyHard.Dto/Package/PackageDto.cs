using System;

namespace StudyHard.Dto.Package
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDateUTC { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
    }
}
