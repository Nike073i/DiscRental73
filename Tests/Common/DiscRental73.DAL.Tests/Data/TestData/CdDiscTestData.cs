using DiscRental73.DAL.Entities;
using DiscRental73.DAL.Tests.Data.SourceData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DiscRental73.DAL.Tests.Data.TestData
{
    internal class CdDiscTestData
    {
        public static object[] GetByIdDataObjects =
        {
            new object[]
            {
                1,
                CdDiscSourceData.GetCdDiscs().First()
            },

            new object?[]
            {
                0,
                null
            },
            new object?[]
            {
                CdDiscSourceData.GetCdDiscs().Count() + 1,
                null
            },
            new object?[]
            {
                CdDiscSourceData.GetCdDiscs().Count(),
                CdDiscSourceData.GetCdDiscs().Last()
            },
            new object?[]
            {
                -1,
                null
            },
        };

        public static object[] GetAllDataObjects =
        {
            CdDiscSourceData.GetCdDiscs()
        };

        public static object[] InsertBadData =
        {
            new object[]
            {
                new CdDisc(),
                typeof(DbUpdateException)
            },
            new object[]
            {
                new CdDisc
                {
                    IsDeleted = true,
                    DateOfRelease = DateTime.Now,
                    Performer = "Тестовый диск. Исполнитель",
                    Genre = "Тестовый диск. Жанр",
                    NumberOfTracks = 100
                },
                typeof(DbUpdateException)
            },
            new object[]
            {
                new CdDisc
                {
                    Id = 100,
                    Title = "Тестовый диск. Название",
                    IsDeleted = true,
                    DateOfRelease = DateTime.Now,
                    Performer = "Тестовый диск. Исполнитель",
                    Genre = "Тестовый диск. Жанр",
                    NumberOfTracks = 100
                },
                typeof(DbUpdateException)
            }
        };

        public static object[] InsertCorrectData =
        {
            new CdDisc
            {
                IsDeleted = true,
                Title = "Тестовый диск. Название1",
                DateOfRelease = DateTime.Now,
                Performer = "Тестовый диск. Исполнитель1",
                Genre = "Тестовый диск. Жанр1",
                NumberOfTracks = 100
            },
            new CdDisc
            {
                IsDeleted = true,
                Title = "Тестовый диск. Название2",
                DateOfRelease = DateTime.Now.AddDays(1),
                Performer = "Тестовый диск. Исполнитель2",
                NumberOfTracks = 200
            },
            new CdDisc
            {
                IsDeleted = true,
                Title = "Тестовый диск. Название3",
                DateOfRelease = DateTime.Now.AddDays(2),
                Performer = "Тестовый диск. Исполнитель3",
            }
        };
    }
}
