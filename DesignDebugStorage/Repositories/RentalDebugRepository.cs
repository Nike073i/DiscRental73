using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DesignDebugStorage.Repositories
{
    public class RentalDebugRepository : IRepository<RentalDto>
    {
        private readonly IEnumerable<RentalDto> _Rentals = Enumerable.Range(1, 10).Select(i => new RentalDto
        {
            Id = i,
            //ClientCNumber = $"н.т - {i}",
            ClientId = i,
            DateOfIssue = DateTime.Now,
            DateOfRental = DateTime.Now,
            //DiscTitle = $"Диск - {i}",
            //EmployeeFName = $"Сотрудник - {i}",
            EmployeeId = i,
            PledgeSum = i,
            ProductId = i
        });

        public int Insert(RentalDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(RentalDto dto)
        {
            throw new NotImplementedException();
        }

        public RentalDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentalDto> GetAll()
        {
            return _Rentals.ToList();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}