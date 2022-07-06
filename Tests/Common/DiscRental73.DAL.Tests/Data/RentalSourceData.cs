using DiscRental73.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscRental73.DAL.Tests.Data;

internal class RentalSourceData
{
    private static readonly Rental[] Rentals =
    {
        new()
        {
            ProductId = ProductSourceData.GetProducts().First().Id,
            ClientId = ClientSourceData.GetClients().First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfIssue = new DateTime(2022, 04, 03),
            DateOfRental = new DateTime(2022, 04, 10),
            PledgeSum = 450,
            ReturnSum = 400
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            ClientId = ClientSourceData.GetClients().First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfIssue = new DateTime(2022, 04, 03),
            DateOfRental = new DateTime(2022, 04, 10),
            PledgeSum = 2500,
            ReturnSum = 2300
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().First().Id,
            ClientId = ClientSourceData.GetClients().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(1).First().Id,
            DateOfIssue = new DateTime(2022, 04, 03),
            DateOfRental = new DateTime(2022, 04, 10),
            PledgeSum = 450,
            ReturnSum = 400
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(1).First().Id,
            ClientId = ClientSourceData.GetClients().Skip(1).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(1).First().Id,
            DateOfIssue = new DateTime(2022, 04, 03),
            DateOfRental = new DateTime(2022, 04, 10),
            PledgeSum = 500,
            ReturnSum = null
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(4).First().Id,
            ClientId = ClientSourceData.GetClients().Skip(2).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfIssue = new DateTime(2022, 04, 05),
            DateOfRental = new DateTime(2022, 04, 11),
            PledgeSum = 300,
            ReturnSum = 250
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(4).First().Id,
            ClientId = ClientSourceData.GetClients().Skip(4).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(2).First().Id,
            DateOfIssue = new DateTime(2022, 04, 05),
            DateOfRental = new DateTime(2022, 04, 11),
            PledgeSum = 300,
            ReturnSum = 250
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(3).First().Id,
            ClientId = ClientSourceData.GetClients().Skip(3).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(2).First().Id,
            DateOfIssue = new DateTime(2022, 04, 07),
            DateOfRental = new DateTime(2022, 04, 13),
            PledgeSum = 500,
            ReturnSum = 400
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().Skip(2).First().Id,
            ClientId = ClientSourceData.GetClients().Skip(2).First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().Skip(1).First().Id,
            DateOfIssue = new DateTime(2022, 04, 07),
            DateOfRental = new DateTime(2022, 04, 13),
            PledgeSum = 550,
            ReturnSum = null
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().First().Id,
            ClientId = ClientSourceData.GetClients().First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfIssue = new DateTime(2022, 04, 08),
            DateOfRental = new DateTime(2022, 04, 14),
            PledgeSum = 650,
            ReturnSum = 600
        },
        new()
        {
            ProductId = ProductSourceData.GetProducts().First().Id,
            ClientId = ClientSourceData.GetClients().First().Id,
            EmployeeId = EmployeeSourceData.GetEmployees().First().Id,
            DateOfIssue = new DateTime(2022, 04, 08),
            DateOfRental = new DateTime(2022, 04, 14),
            PledgeSum = 650,
            ReturnSum = 600
        }
    };
    public static IEnumerable<Rental> GetRentals() => Rentals.AsEnumerable();
}