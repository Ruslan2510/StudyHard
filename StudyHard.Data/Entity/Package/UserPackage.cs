using StudyHard.Data.Entity.Payment;
using System;

namespace StudyHard.Data.Entity.Package
{
    public class UserPackage
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public Guid? TransactionId { get; set; }
        public LiqpayTransaction LiqpayTransaction { get; set; }
    }
}