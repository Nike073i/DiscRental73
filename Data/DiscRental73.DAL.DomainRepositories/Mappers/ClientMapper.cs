using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Mappers
{
    public class ClientMapper : IDbMapper<ClientDto, ClientDetailDto, Client>
    {
        #region readonly fields

        private readonly IDbMapper<RentalDto, RentalDetailDto, Rental> _RentalMapper;

        #endregion

        #region constructors

        public ClientMapper()
        {
            _RentalMapper = new RentalMapper();
        }

        #endregion

        public Client MapToEntity(in ClientDto reqDto)
        {
            var entity = new Client
            {
                Id = reqDto.Id,
                ContactNumber = reqDto.ContactNumber,
                FirstName = reqDto.FirstName,
                SecondName = reqDto.SecondName,
                Address = reqDto.Address
            };
            return entity;
        }

        public ClientDto MapToDto(in Client entity)
        {
            var resDto = new ClientDto
            {
                Id = entity.Id,
                ContactNumber = entity.ContactNumber,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                Address = entity.Address
            };
            return resDto;
        }

        public ClientDetailDto MapToDetailDto(in Client entity)
        {
            if (entity.Rentals is null) throw new ArgumentNullException(nameof(entity.Rentals));
            var dto = this.MapToDto(entity);
            if (dto is not ClientDetailDto detailDto) throw new InvalidCastException("Ошибка приведения типа dto к detailDto");
            detailDto.Rentals = entity.Rentals.Select(rec => _RentalMapper.MapToDetailDto(rec)).ToList();
            return detailDto;
        }
    }
}
