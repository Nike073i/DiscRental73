using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DesignDebugStorage.Repositories
{
    public class ClientDebugRepository : IPersonRepository<ClientDto>
    {
        private readonly IEnumerable<ClientDto> _Clients = Enumerable.Range(1, 10).Select(i => new ClientDto
        {
            Id = i,
            Address = $"Адрес - {i}",
            ContactNumber = $"н.тел - {i}",
            FirstName = $"Имя - {i}",
            SecondName = $"Фамилия - {i}"
        });

        public int Insert(ClientDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientDto dto)
        {
            throw new NotImplementedException();
        }

        public ClientDto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientDto> GetAll() => _Clients;

        public ClientDto? GetByContactNumber(string contactNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}