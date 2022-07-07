using System;
using System.Collections.Generic;
using System.Linq;
using DiscRental73.DAL.Entities;

namespace DiscRental73.DAL.Tests.Data.SourceData;

internal class SellSourceData
{
    private static readonly Sell[] Sells =
    {
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(1).First().Id,
            DateOfSell = new DateTime(2022, 04, 03),
            Price = ProductSourceData.GetProducts().Skip(1).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(4).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 03),
            Price = ProductSourceData.GetProducts().Skip(4).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 03),
            Price = ProductSourceData.GetProducts().Skip(1).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 03),
            Price = ProductSourceData.GetProducts().Skip(1).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(2).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(2).First().Id,
            DateOfSell = new DateTime(2022, 04, 04),
            Price = ProductSourceData.GetProducts().Skip(2).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(2).First().Id,
            DateOfSell = new DateTime(2022, 04, 04),
            Price = ProductSourceData.GetProducts().Skip(1).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(4).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 04),
            Price = ProductSourceData.GetProducts().Skip(4).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(2).First().Id,
            DateOfSell = new DateTime(2022, 04, 04),
            Price = ProductSourceData.GetProducts().First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 05),
            Price = ProductSourceData.GetProducts().Skip(1).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(2).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 05),
            Price = ProductSourceData.GetProducts().Skip(2).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(3).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 05),
            Price = ProductSourceData.GetProducts().Skip(3).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(2).First().Id,
            DateOfSell = new DateTime(2022, 04, 05),
            Price = ProductSourceData.GetProducts().First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(2).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(1).First().Id,
            DateOfSell = new DateTime(2022, 04, 05),
            Price = ProductSourceData.GetProducts().Skip(2).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(2).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfSell = new DateTime(2022, 04, 06),
            Price = ProductSourceData.GetProducts().Skip(2).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(1).First().Id,
            DateOfSell = new DateTime(2022, 04, 06),
            Price = ProductSourceData.GetProducts().Skip(1).First().Cost
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(4).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(2).First().Id,
            DateOfSell = new DateTime(2022, 04, 07),
            Price = ProductSourceData.GetProducts().Skip(4).First().Cost
        }
    };
    public static IEnumerable<Sell> GetSells() => Sells.AsEnumerable();
}