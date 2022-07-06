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
            // Подключение к тестовой БД (Пересоздание, в случае отсутствия и инициализация БД тестовыми значениями)
            // [DataTestMethod]
            // [DynamicData(nameof(ProjectTestData), DynamicDataSourceType.Method)]
            //
            var test = DatabaseContext.Instance;
        }

        [OneTimeTearDown]
        public void OnStop()
        {
            DatabaseContext.KillDbConnection();
        }
    }
}
