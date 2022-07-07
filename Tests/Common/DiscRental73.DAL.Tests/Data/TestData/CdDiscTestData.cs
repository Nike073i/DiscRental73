using DiscRental73.DAL.Tests.Data.SourceData;
using System.Collections;
using System.Linq;

namespace DiscRental73.DAL.Tests.Data.TestData
{
    internal class CdDiscTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                1,
                CdDiscSourceData.GetCdDiscs().First()
            };

            yield return new object?[]
            {
                0,
                null
            };
            yield return new object?[]
            {
                CdDiscSourceData.GetCdDiscs().Count() + 1,
                null
            };
            yield return new object?[]
            {
                CdDiscSourceData.GetCdDiscs().Count(),
                CdDiscSourceData.GetCdDiscs().Last()
            };
            yield return new object?[]
            {
                -1,
                null
            };
        }
    }
}
