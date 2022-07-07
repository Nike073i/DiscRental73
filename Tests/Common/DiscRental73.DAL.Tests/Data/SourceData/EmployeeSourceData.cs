using System.Collections.Generic;
using System.Linq;
using DiscRental73.DAL.Entities;
using DiscRental73.Enums.ModelEnums;

namespace DiscRental73.DAL.Tests.Data.SourceData;

internal class EmployeeSourceData
{
    private static readonly Employee[] Employees =
    {
        new()
        {
            ContactNumber = "+79176306255",
            FirstName = "Степан",
            SecondName = "Куйбышев",
            Position = UserPosition.Employee,
            Password = "dhgdfhdf",
            Prize = null
        },
        new()
        {
            ContactNumber = "+79176306258",
            FirstName = "Тимур",
            SecondName = "Греков",
            Position = UserPosition.Employee,
            Password = "grekov",
            Prize = 750M
        },
        new()
        {
            ContactNumber = "+79176306260",
            FirstName = "Никита",
            SecondName = "Филиппов",
            Position = UserPosition.Administrator,
            Password = "filippov",
            Prize = 1500M
        }
    };
    public static IEnumerable<Employee> GetEmployees() => Employees.AsEnumerable();
}