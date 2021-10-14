using System;
using System.Collections.Generic;

namespace StudyHard.ContentManagement.Dto.Package
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public List<PackageConfigurationDto> PackageConfigurationDtos { get; set; }
    }
}
