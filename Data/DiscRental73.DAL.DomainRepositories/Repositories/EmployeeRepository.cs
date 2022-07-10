using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class EmployeeRepository : DbRepository<EmployeeDto, EmployeeDetailDto, Employee>,
        IPersonRepository<EmployeeDto, EmployeeDetailDto>
    {
        #region readonly fields

        private readonly IDbMapper<EmployeeDto, EmployeeDetailDto, Employee> _DetailMapper;

        #endregion

        #region constructors

        public EmployeeRepository(DiscRentalDb db)
        {
            _DetailMapper = new EmployeeMapper();
            DbRepos = new DAL.Repositories.EmployeeRepository(db);
        }

        #endregion

        #region override abstract methods

        protected override IDbMapper<EmployeeDto, Employee> Mapper => _DetailMapper;
        protected override IDbMapper<EmployeeDto, EmployeeDetailDto, Employee> DetailMapper => _DetailMapper;
        protected override DAL.Repositories.EmployeeRepository DbRepos { get; }

        #endregion

        #region public methods

        public EmployeeDto? GetByContactNumber(string contactNumber)
        {
            var entity = DbRepos.GetByContactNumberLazy(contactNumber);
            return entity is null ? null : Mapper.MapToDto(entity);
        }

        public EmployeeDetailDto? GetByContactNumberDetail(string contactNumber)
        {
            var entity = DbRepos.GetByContactNumber(contactNumber);
            return entity is null ? null : DetailMapper.MapToDetailDto(entity);
        }

        #endregion
    }
}