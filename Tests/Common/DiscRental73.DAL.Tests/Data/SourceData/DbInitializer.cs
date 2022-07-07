using DiscRental73.DAL.Context;

namespace DiscRental73.DAL.Tests.Data.SourceData
{
    internal class DbInitializer
    {
        public static void InsertTestData(DiscRentalDb db)
        {
            db.CdDiscs.AddRange(CdDiscSourceData.GetCdDiscs());
            db.DvdDiscs.AddRange(DvdDiscSourceData.GetDvdDiscs());
            db.BluRayDiscs.AddRange(BluRayDiscSourceData.GetBluRayDiscs());
            db.SaveChanges();
            db.Products.AddRange(ProductSourceData.GetProducts());
            db.Clients.AddRange(ClientSourceData.GetClients());
            db.Employees.AddRange(EmployeeSourceData.GetEmployees());
            db.SaveChanges();
            db.Rentals.AddRange(RentalSourceData.GetRentals());
            db.Sells.AddRange(SellSourceData.GetSells());
            db.SaveChanges();
        }
    }
}
