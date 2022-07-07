using System.Collections.Generic;
using System.Linq;
using DiscRental73.DAL.Entities;

namespace DiscRental73.DAL.Tests.Data.SourceData;

internal class ClientSourceData
{
    private static readonly Client[] Clients =
    {
        new()
        {
            ContactNumber = "+79176306250",
            FirstName = "Николай",
            SecondName = "Степанов",
            Address = "г.Ульяновск, ул.Полбина д. 54 кв. 15"
        },
        new()
        {
            ContactNumber = "+79176306251",
            FirstName = "Иван",
            SecondName = "Семенов",
            Address = "г.Ульяновск, ул.Камышинская д. 89 кв. 17"
        },
        new()
        {
            ContactNumber = "+79176306252",
            FirstName = "Леонид",
            SecondName = "Петров",
            Address = "г.Ульяновск, ул.Октябрьская д. 18 кв. 35"
        },
        new()
        {
            ContactNumber = "+79176306253",
            FirstName = "Юрий",
            SecondName = "Михайлов",
            Address = "г.Ульяновск, ул.Пушкарева д. 20 кв. 45"
        },
        new()
        {
            ContactNumber = "+79176306254",
            FirstName = "Дмитрий",
            SecondName = "Номов",
            Address = "г.Ульяновск, ул.Свободы д. 1 кв. 154"
        }
    };
    public static IEnumerable<Client> GetClients() => Clients.AsEnumerable();
}