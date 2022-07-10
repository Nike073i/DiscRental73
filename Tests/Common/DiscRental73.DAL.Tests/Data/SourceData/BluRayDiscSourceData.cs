using DiscRental73.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscRental73.DAL.Tests.Data.SourceData;

internal class BluRayDiscSourceData
{
    private static readonly BluRayDisc[] BluRayDiscs =
    {
        new()
        {
            Title = "Lost Judgment",
            DateOfRelease = new DateTime(2021, 09, 24),
            Publisher = "SEGA",
            Info = "Описание игры 'Lost Judgment'",
            SystemRequirements = "Системные требования игры 'Lost Judgment'"
        },
        new()
        {
            Title = "Elden Ring",
            DateOfRelease = new DateTime(2022, 02, 25),
            Publisher = "Bandai Namco",
            Info = "Описание игры 'Elden Ring'",
            SystemRequirements = null
        },
        new()
        {
            Title = "Jurassic World Evolition 2",
            DateOfRelease = new DateTime(2021, 11, 09),
            Publisher = "Frontier Developments",
            Info = null,
            SystemRequirements = "Системные требования игры 'Jurassic World Evolition 2'"
        },
        new()
        {
            Title = "Sifu",
            DateOfRelease = new DateTime(2022, 02, 08),
            Publisher = "Sloclap",
            Info = "Описание игры 'Sifu'",
            SystemRequirements = "Системные требования игры 'Sifu'"
        },
        new()
        {
            Title = "Lost in Random",
            DateOfRelease = new DateTime(2021, 09, 10),
            Publisher = "Electronic Arts",
            Info = "Описание игры 'Lost in Random'",
            SystemRequirements = "Системные требования игры 'Lost in Random'"
        }
    };
    public static IEnumerable<BluRayDisc> GetBluRayDiscs() => BluRayDiscs.AsEnumerable();
}