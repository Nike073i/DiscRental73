using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class EmployeeMapper : IDbMapper<EmployeeDto, EmployeeDetailDto, Employee>
    {
        #region readonly fields

        private readonly IDbMapper<SellDto, SellDetailDto, Sell> _SellMapper;
        private readonly IDbMapper<RentalDto, RentalDetailDto, Rental> _RentalMapper;

        #endregion

        #region constructors

        public EmployeeMapper()
        {
            _SellMapper = new SellMapper();
            _RentalMapper = new RentalMapper();
        }

        #endregion

        public Employee MapToEntity(in EmployeeDto reqDto)
        {
            var entity = new Employee
            {
                Id = reqDto.Id,
                ContactNumber = reqDto.ContactNumber,
                FirstName = reqDto.FirstName,
                SecondName = reqDto.SecondName,
                Password = reqDto.Password,
                Position = reqDto.Position,
                Prize = reqDto.Prize
            };
            return entity;
        }

        public EmployeeDto MapToDto(in Employee entity)
        {
            var resDto = new EmployeeDto
            {
                Id = entity.Id,
                ContactNumber = entity.ContactNumber,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                Password = entity.Password,
                Position = entity.Position,
                Prize = entity.Prize
            };
            return resDto;
        }

        public EmployeeDetailDto MapToDetailDto(in Employee entity)
        {
            if (entity.Rentals is null) throw new ArgumentNullException(nameof(entity.Rentals));
            if (entity.Sells is null) throw new ArgumentNullException(nameof(entity.Sells));
            var dto = this.MapToDto(entity);
            if (dto is not EmployeeDetailDto detailDto) throw new InvalidCastException("Ошибка приведения типа dto к detailDto");
            detailDto.Rentals = entity.Rentals.Select(rec => _RentalMapper.MapToDetailDto(rec)).ToList();
            detailDto.Sells = entity.Sells.Select(rec => _SellMapper.MapToDetailDto(rec)).ToList();
            return detailDto;
        }
    }
}
