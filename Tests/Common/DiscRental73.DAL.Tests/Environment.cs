using DiscRental73.DAL.Tests.Context;
using NUnit.Framework;

namespace DiscRental73.DAL.Tests
{
    [SetUpFixture]
    internal class Environment
    {
        [OneTimeSetUp]
        public void OnStart()
        {

        }

        [OneTimeTearDown]
        public void OnStop()
        {
            DatabaseContext.KillDbConnection();
        }
    }
}
