using StudyHard.Data.Entity.Package;
using System;

namespace StudyHard.Data.Entity.Payment
{
    public class LiqpayTransaction
    {
        public Guid Id { get; set; }

        public UserPackage UserPackage { get; set; }
    }
}