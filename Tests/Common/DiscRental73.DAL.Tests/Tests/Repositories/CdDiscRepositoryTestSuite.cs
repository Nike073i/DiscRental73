using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Repositories;
using DiscRental73.DAL.Tests.Context;
using DiscRental73.DAL.Tests.Data.TestData;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
                    propertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    var awaitCount = (awaitValue as ICollection)?.Count;
                    var responseCount = (responseValue as ICollection)?.Count;
                    if (awaitCount != responseCount) return false;
                    continue;
                }
                if (!awaitValue.Equals(responseValue)) return false;
            }

            return true;
        }


        #region Test TestGetById-method

        [TestCaseSource(typeof(CdDiscTestData), nameof(CdDiscTestData.GetByIdDataObjects))]
        [Test]
        public void TestGetById(int id, CdDisc awaitData) =>
            Assert.IsTrue(IsEqualsEntities(awaitData, _Repository?.GetById(id)));

        #endregion

        #region Test GetAll-method

        [TestCaseSource(typeof(CdDiscTestData), nameof(CdDiscTestData.GetAllDataObjects))]
        public void TestGetAll(CdDisc[]? awaitData)
        {
            var dataFromDb = _Repository?.GetAll();
            if (ReferenceEquals(awaitData, dataFromDb)) Assert.Pass();
            if (awaitData is null || dataFromDb is null)
            {
                Assert.Fail();
                return;
            }

            var cdDiscs = dataFromDb.ToList();
            if (cdDiscs.Count() != awaitData.Length)
            {
                Assert.Fail();
                return;
            }
            for (var i = 0; i < cdDiscs.Count(); i++)
            {
                Assert.IsTrue(IsEqualsEntities(awaitData[i], cdDiscs[i]));
            }
        }

        #endregion

        #region Test Insert-method

        [TestCaseSource(typeof(CdDiscTestData), nameof(CdDiscTestData.InsertCorrectData))]
        public void TestInsertCorrect(CdDisc newEntity)
        {
            var id = _Repository?.Insert(newEntity);
            Assert.IsTrue(id != default(int));
        }

        [TestCaseSource(typeof(CdDiscTestData), nameof(CdDiscTestData.InsertBadData))]
        public void TestInsertBadModel(CdDisc badModel, Type exceptionType)
        {
            var ex = Assert.Throws(exceptionType, () => _Repository?.Insert(badModel));
            Assert.IsTrue(ex is not null);
        }

        #endregion

        #region Test Delete-method



        #endregion

        //public void TestDeleteById(int id, bool awaitData)
        //{

        //}

        #region Test Update-method


        #endregion
    }
}
