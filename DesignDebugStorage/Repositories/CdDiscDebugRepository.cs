using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Interfaces.Repositories.Base;

namespace DesignDebugStorage.Repositories
{
    public class CdDiscDebugRepository : IRepository<CdDiscDto>
    {
        private readonly IEnumerable<CdDiscDto> _Discs = Enumerable.Range(1, 10).Select(i => new CdDiscDto
        {
            Id = i,
            Title = $"CD-диск {i}",
            DiscType = DiscType.Cd,
            DateOfRelease = DateTime.Now,
            Performer = $"Исполнитель - {i}",
        });

        public IEnumerable<CdDiscDto> GetAll() => _Discs;

        public int Insert(CdDiscDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(CdDiscDto dto)
        {
            throw new NotImplementedException();
        }

        public CdDiscDto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}