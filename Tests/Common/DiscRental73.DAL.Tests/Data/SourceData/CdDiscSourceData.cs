using System;
using System.Collections.Generic;
using System.Linq;
using DiscRental73.DAL.Entities;

namespace DiscRental73.DAL.Tests.Data.SourceData;

internal class CdDiscSourceData
{
    private static readonly CdDisc[] CdDiscs =
    {
        new()
        {
            Title = "Театръ Теней",
            DateOfRelease = new DateTime(2008, 08, 07),
            Performer = "Король и Шут",
            Genre = "Хоррор-панк",
            NumberOfTracks = 15
        },
        new()
        {
            Title = "Пропавший без вести",
            DateOfRelease = new DateTime(2006, 04, 03),
            Performer = "ДДТ",
            Genre = "Рок",
            NumberOfTracks = null
        },
        new()
        {
            Title = "Алхимия",
            DateOfRelease = new DateTime(2016, 01, 07),
            Performer = "Мельница",
            Genre = null,
            NumberOfTracks = 15
        },
        new()
        {
            Title = "Альтависта",
            DateOfRelease = new DateTime(2001, 03, 02),
            Performer = "Сплин",
            Genre = "Рок",
            NumberOfTracks = null
        },
        new()
        {
            Title = "Армагедон",
            DateOfRelease = new DateTime(1999, 10, 10),
            Performer = "Ария",
            Genre = "Металл",
            NumberOfTracks = 12
        }
    };
    public static IEnumerable<CdDisc> GetCdDiscs() => CdDiscs.AsEnumerable();
}