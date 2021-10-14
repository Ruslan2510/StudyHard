using System;
using System.Collections.Generic;

namespace StudyHard.Data.Entity.Package
{
    public class Package
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }

        public List<PackageConfiguration> PackageConfigurations { get; set; }
        public List<UserPackage> UserPackages { get; set; }
    }
}
