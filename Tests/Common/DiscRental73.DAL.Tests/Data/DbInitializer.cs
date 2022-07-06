using DiscRental73.DAL.Context;

namespace DiscRental73.DAL.Tests.Data
{
    internal class DbInitializer
    {
        public static void InsertTestData(DiscRentalDb db)
        {
            db.CdDiscs.AddRange(CdDiscSourceData.GetCdDiscs());
            db.DvdDiscs.AddRange(DvdDiscSourceData.GetDvdDiscs());
            db.BluRayDiscs.AddRange(BluRayDiscSourceData.GetBluRayDiscs());
            db.SaveChanges();
        }
    }
}
