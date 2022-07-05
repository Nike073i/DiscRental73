using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class EmployeeRepository : DbRepository<EmployeeDto, Employee>,
        IPersonRepository<EmployeeDto>
    {
        #region readonly fields

        private readonly EmployeeMapper _Mapper;

        #endregion

        #region constructors

        public EmployeeRepository(DiscRentalDb db)
        {
            _Mapper = new EmployeeMapper();
            DbRepos = new DAL.Repositories.EmployeeRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<EmployeeDto, Employee> Mapper => _Mapper;
        internal override DAL.Repositories.EmployeeRepository DbRepos { get; }

        #endregion

        #region public methods

        public EmployeeDto? GetByContactNumber(string contactNumber)
        {
            var entity = DbRepos.GetByContactNumber(contactNumber);
            return entity is null ? null : Mapper.MapToDto(entity);
        }

        #endregion
    }
}