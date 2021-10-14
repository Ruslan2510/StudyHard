using StudyHard.Data.Entity.Package;
using System.Threading.Tasks;

namespace StudyHard.Data.DataAccesses.Package
{
    public class UserPackageDataAccess : BaseDataAccess<UserPackage>
    {
        internal UserPackageDataAccess(StudyHardApplicationContext applicationContext) : base(applicationContext)
        { }
    }
}
