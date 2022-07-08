using System;
using System.Collections.Generic;
using System.Linq;
using DiscRental73.DAL.Entities;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.DAL.Tests.Data.SourceData;

internal class DvdDiscSourceData
{
    private static readonly DvdDisc[] DvdDiscs =
    {
        new()
        {
            Title = "Как Витька Чеснок вез Леху Штыря в дом инвалидов",
            DiscType = DiscType.Dvd,
            DateOfRelease = new DateTime(2020, 06, 07),
            Director = "А.В. Смирнов",
            Info = "Описание фильма 'Как Витька Чеснок вез Леху Штыря в дом инвалидов'",
            Plot = "Криминал, драма"
        },
        new()
        {
            Title = "Дурак",
            DiscType = DiscType.Dvd,
            DateOfRelease = new DateTime(2017, 07, 03),
            Director = "Ю.А. Быков",
            Info = "Описание фильма 'Дурак'",
            Plot = "Драма, Триллер"
        },
        new()
        {
            Title = "Война",
            DiscType = DiscType.Dvd,
            DateOfRelease = new DateTime(2002, 05, 07),
            Director = "А.О. Балабанов",
            Info = null,
            Plot = "Военный, боевик, драма, криминал"
        },
        new()
        {
            Title = "Карты, деньги, 2 ствола",
            DiscType = DiscType.Dvd,
            DateOfRelease = new DateTime(2001, 04, 02),
            Director = "Г.С. Ричи",
            Info = "Описание фильма 'Карты, деньги, 2 ствола'",
            Plot = null
        },
        new()
        {
            Title = "Убить Билла",
            DiscType = DiscType.Dvd,
            DateOfRelease = new DateTime(1996, 11, 15),
            Director = "К.Д. Тарантино",
            Info = "Описание фильма 'Убить Билла'",
            Plot = "Боевик, криминал"
        }
    };
    public static IEnumerable<DvdDisc> GetDvdDiscs() => DvdDiscs.AsEnumerable();
}