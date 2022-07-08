using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories;
using DiscRental73.DAL.Tests.Context;
using DiscRental73.DAL.Tests.Data.TestData;
using NUnit.Framework;
using System.Collections.Generic;

namespace DiscRental73.DAL.Tests.Tests.Repositories
{
    internal class CdDiscRepositoryTestSuite
    {
        private DiscRentalDb? _Db;
        private CdDiscRepository? _Repository;

        [OneTimeSetUp]
        public void TestSuiteStartUp()
        {
            _Db = DatabaseContext.Instance;
            _Repository = new CdDiscRepository(_Db);
        }

        private static bool IsEqualsEntities<T>(T? awaitData, T? responseData)
        {
            if (ReferenceEquals(awaitData, responseData)) return true;
            if (awaitData is null || responseData is null) return false;

            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var awaitValue = property.GetValue(awaitData);
                var responseValue = property.GetValue(responseData);
                if (ReferenceEquals(awaitValue, responseValue)) continue;
                if (awaitValue is null || responseValue is null) return false;
                if (propertyType.IsGenericType &&
                    propertyType.GetGenericTypeDefinition() == typeof(ICollection<>)) continue;
                if (!awaitValue.Equals(responseValue)) return false;
            }

            return true;
        }


        #region Test TestGetById-method

        [TestCaseSource(typeof(CdDiscTestData), nameof(CdDiscTestData.GetByIdDataObjects))]
        public void TestGetById(int id, CdDisc awaitData) =>
            Assert.IsTrue(IsEqualsEntities(awaitData, _Repository?.GetById(id)));

        #endregion

        #region Test GetAll-method



        #endregion

        #region Test Insert-method



        #endregion


        #region Test Delete-method



        #endregion


        #region Test Update-method



        #endregion
    }
}
