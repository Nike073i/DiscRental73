using DiscRental73.DAL.Context;
using DiscRental73.DAL.Repositories;
using DiscRental73.DAL.Tests.Context;
using NUnit.Framework;
using System.Collections.Generic;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Tests.Data.TestData;

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


        #region Test GetById-method

        [TestCaseSource(typeof(CdDiscTestData))]
        public void GetById(int id, CdDisc awaitData)
        {
            var data = _Repository?.GetById(id);
            Assert.IsTrue(IsEqualsEntities(awaitData, data));
        }

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
