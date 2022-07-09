using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Interfaces.Repositories.Base;

namespace DesignDebugStorage.Repositories
{
    public class DvdDiscDebugRepository : IRepository<DvdDiscDto>
    {
        private readonly IEnumerable<DvdDiscDto> _Discs = Enumerable.Range(1, 10).Select(i => new DvdDiscDto
        {
            Id = i,
            Title = $"DVD-диск {i}",
            DiscType = DiscType.Dvd,
            DateOfRelease = DateTime.Now,
            Director = $"Режиссер - {i}",
        });

        public int Insert(DvdDiscDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(DvdDiscDto dto)
        {
            throw new NotImplementedException();
        }

        public DvdDiscDto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DvdDiscDto> GetAll() => _Discs;
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}