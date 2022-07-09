using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Interfaces.Repositories.Base;

namespace DesignDebugStorage.Repositories
{
    public class BluRayDiscDebugRepository : IRepository<BluRayDiscDto>
    {
        private readonly IEnumerable<BluRayDiscDto> _Discs = Enumerable.Range(1, 10).Select(i => new BluRayDiscDto
        {
            Id = i,
            Title = $"BluRay-диск {i}",
            DiscType = DiscType.BluRay,
            DateOfRelease = DateTime.Now,
            Publisher = $"Издатель - {i}"
        });

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(BluRayDiscDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(BluRayDiscDto dto)
        {
            throw new NotImplementedException();
        }

        public BluRayDiscDto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BluRayDiscDto> GetAll() => _Discs;
    }
}