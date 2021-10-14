using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StudyHard.Tests.Infra
{
    [TestClass]
    public abstract class BaseTest
    {
        [TestInitialize]
        public void Initalize()
        {
            RenewServiceProvider();
        }

        public void RenewServiceProvider()
        {
            ServiceProvider = Infra.Program.ServiceCollection.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; set; }
    }
}
