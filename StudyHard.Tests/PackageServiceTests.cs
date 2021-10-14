using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageEntity = StudyHard.Data.Entity.Package.Package;
using StudyHard.Data.Repository;
using StudyHard.Tests.Infra;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using StudyHard.ContentManagement.Services.Package;
using StudyHard.Data.Entity.Package;
using StudyHard.ContentManagement.Services.Mappers.Package;
using StudyHard.Data.Entity;

namespace StudyHard.Tests
{
    [TestClass]
    public class PackageServiceTests : BaseTest
    {
        //CM methods
        [TestMethod]
        public async Task GetAllPackagesAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            const int PACKAGESOUNT = 6;
            var packagesList = new List<PackageEntity>();

            for (int i = 0; i < PACKAGESOUNT; i++)
            {
                PackageEntity package = CreatePackage();
                await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

                packagesList.Add(package);
            }

            var packageService = ServiceProvider.GetRequiredService<IPackageService>();

            var packages = await packageService.GetAllPackagesAsync(tokenSource.Token);

            Assert.AreEqual(packages.Count, PACKAGESOUNT);

            foreach (var package in packagesList)
            {
                await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
            }
        }


        [TestMethod]
        public async Task CreatePackageAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            PackageEntity package = CreatePackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            var addedPackage = await _repository.PackageDataAccess.GetPackageByIdAsync(package.Id, tokenSource.Token);

            AreEquals(package, addedPackage);

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        [TestMethod]
        public async Task UpdatePackageAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            PackageEntity package = CreatePackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            package.CreatedDateUTC = DateTime.UtcNow;
            package.Description = "Updated package description test";
            package.IsActive = !package.IsActive;
            package.Name = "Updated package name test";
            package.Price = 3000;

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            var packageService = ServiceProvider.GetRequiredService<IPackageService>();
            await packageService.UpdatePackageAsync(package.MapToDto(), tokenSource.Token);

            var updatedPackage = await _repository.PackageDataAccess.GetPackageByIdAsync(package.Id, tokenSource.Token);

            AreEquals(updatedPackage, package);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        [TestMethod]
        public async Task ChangePropertyActivePackageAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            PackageEntity package = CreatePackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            var packageService = ServiceProvider.GetRequiredService<IPackageService>();
            await packageService.ChangePropertyActivePackageAsync(package.Id, tokenSource.Token);

            var updatedPackage = await _repository.PackageDataAccess.GetPackageByIdAsync(package.Id, tokenSource.Token);

            RenewServiceProvider();
            _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();

            Assert.AreEqual(package.IsActive, !updatedPackage.IsActive);
            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }
        //CM methods end


        //Client methods

        [TestMethod]
        public async Task GetAllUserPackagesAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            var firstUser = CreateUser();
            firstUser.Username = "user 1";
            var secondUser = CreateUser();
            secondUser.Username = "user 2";

            await _repository.UsersDataAccess.AddAsync(firstUser, tokenSource.Token);
            await _repository.UsersDataAccess.AddAsync(secondUser, tokenSource.Token);

            var packagesList = new List<PackageEntity>();


            PackageEntity firstPackage = CreatePackage();
            firstPackage.IsActive = false;
            await _repository.PackageDataAccess.AddAsync(firstPackage, tokenSource.Token);
            packagesList.Add(firstPackage);

            PackageEntity secondPackage = CreatePackage();
            await _repository.PackageDataAccess.AddAsync(secondPackage, tokenSource.Token);
            packagesList.Add(secondPackage);

            PackageEntity thirdPackage = CreatePackage();
            thirdPackage.IsActive = false;
            await _repository.PackageDataAccess.AddAsync(thirdPackage, tokenSource.Token);
            packagesList.Add(thirdPackage);

            PackageEntity fourthPackage = CreatePackage();
            await _repository.PackageDataAccess.AddAsync(fourthPackage, tokenSource.Token);
            packagesList.Add(fourthPackage);


            var userPackages = new List<UserPackage>();

            //first user package
            var firstUserPackage = CreateUserPackage(firstUser, firstPackage);
            await _repository.UserPackageDataAccess.AddAsync(firstUserPackage, tokenSource.Token);
            userPackages.Add(firstUserPackage);

            //second user package
            var secondUserPackage = CreateUserPackage(firstUser, secondPackage);
            await _repository.UserPackageDataAccess.AddAsync(secondUserPackage, tokenSource.Token);
            userPackages.Add(secondUserPackage);

            //second user package
            var thirdUserPackage = CreateUserPackage(secondUser, thirdPackage);
            await _repository.UserPackageDataAccess.AddAsync(thirdUserPackage, tokenSource.Token);
            userPackages.Add(thirdUserPackage);

            //fourth user package
            var fourthUserPackage = CreateUserPackage(secondUser, fourthPackage);
            await _repository.UserPackageDataAccess.AddAsync(fourthUserPackage, tokenSource.Token);
            userPackages.Add(fourthUserPackage);


            var packageService = ServiceProvider.GetRequiredService<StudyHard.Services.Package.IPackageService>();

            var currentUserPackages = await packageService.GetAllUserPackagesAsync(secondUser.Id, tokenSource.Token);

            Assert.AreEqual(currentUserPackages.Count, packagesList.Count - 1);
        
            foreach (var package in userPackages)
            {
                await _repository.UserPackageDataAccess.DeleteAsync(package, tokenSource.Token);
            }

            foreach (var package in packagesList)
            {
                await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
            }

            await _repository.UsersDataAccess.DeleteAsync(firstUser, tokenSource.Token);
            await _repository.UsersDataAccess.DeleteAsync(secondUser, tokenSource.Token);
        }

        public User CreateUser()
        {
            return new User
            {
                Name = "User"
            };
        }

        public UserPackage CreateUserPackage(User user, PackageEntity package)
        {
            return new UserPackage
            {
                CreatedDateUTC = DateTime.UtcNow,
                Package = package,
                PackageId = package.Id,
                User = user,
                UserId = user.Id
            };
        }

        //Client methods end

        [TestMethod]
        public async Task GetPackageByIdAsyncTest()
        {
            var _repository = ServiceProvider.GetRequiredService<StudyHardRepository>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            PackageEntity package = CreatePackage();
            await _repository.PackageDataAccess.AddAsync(package, tokenSource.Token);

            var packageService = ServiceProvider.GetRequiredService<IPackageService>();
            var currentPackage = await packageService.GetPackageByIdAsync(package.Id, tokenSource.Token);

            AreEquals(currentPackage.MapToEntity(), package);

            await _repository.PackageDataAccess.DeleteAsync(package, tokenSource.Token);
        }

        public void AreEquals(PackageEntity firstPackage, PackageEntity secondPackage)
        {
            Assert.AreEqual(firstPackage.CreatedDateUTC, secondPackage.CreatedDateUTC);
            Assert.AreEqual(firstPackage.Description, secondPackage.Description);
            Assert.AreEqual(firstPackage.Price, secondPackage.Price);
            Assert.AreEqual(firstPackage.IsActive, secondPackage.IsActive);
            Assert.AreEqual(firstPackage.Name, secondPackage.Name);
            Equals(firstPackage.UserPackages, secondPackage.UserPackages);
            Equals(firstPackage.PackageConfigurations, secondPackage.PackageConfigurations);
        }

        public PackageEntity CreatePackage()
        {
            return new PackageEntity
            {
                Description = "Package test description",
                CreatedDateUTC = DateTime.UtcNow,
                IsActive = true,
                Name = "Package test name",
                Price = 2000,
                UserPackages = new List<UserPackage>(),
                PackageConfigurations = new List<PackageConfiguration>()
            };
        }
    }
}
