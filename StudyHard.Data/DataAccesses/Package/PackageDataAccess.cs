using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PackageEntity = StudyHard.Data.Entity.Package.Package;

namespace StudyHard.Data.DataAccesses.Package
{
    public class PackageDataAccess : BaseDataAccess<PackageEntity>
    {
        internal PackageDataAccess(StudyHardApplicationContext applicationContext)
                    : base(applicationContext)
        {
        }

        public async Task<List<PackageEntity>> GetAllPackagesAsync(CancellationToken cancellationToken)
        {
            return await _appContext.Packages
                .Include(x => x.PackageConfigurations)
                .ThenInclude(x => x.Subject)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<PackageEntity>> GetAllUserPackagesAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _appContext.Packages
                                            .Include(x => x.UserPackages)
                                            .Include(x => x.PackageConfigurations)
                                            .ThenInclude(x => x.Subject)
                                            .Where(x => x.UserPackages.Any(x => x.UserId == userId) || x.IsActive)
                                            .ToListAsync(cancellationToken);
        }

        public async Task UpdatePackageAsync(PackageEntity package, CancellationToken cancellationToken)
        {
            _appContext.Update(package);
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangePackagePropertyActiveAsync(PackageEntity package, CancellationToken cancellationToken)
        {
            _appContext.Entry(package).Property(nameof(PackageEntity.IsActive)).IsModified = true;
            await _appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<PackageEntity> GetPackageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _appContext.Packages
                                            .Include(x => x.PackageConfigurations)
                                            .ThenInclude(x => x.Subject)
                                            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
