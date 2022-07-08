using DiscRental73.DAL.Tests.Data.SourceData;
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
    }
}
