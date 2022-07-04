using DiscRental73.Domain.BusinessLogic.Base;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DiscRental73.Domain.BusinessLogic
{
    public class ClientService : PersonCrudService<ClientDto>
    {
        #region constructors

        public ClientService(IPersonRepository<ClientDto> repository) : base(repository) { }

        #endregion

        #region override template-methods

        protected override bool IsCorrectReqDto(ClientDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
            if (string.IsNullOrEmpty(reqDto.ContactNumber)) return false;
            if (string.IsNullOrEmpty(reqDto.FirstName)) return false;
            if (string.IsNullOrEmpty(reqDto.SecondName)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.ContactNumber.Length != ContactNumberLength) return false;
            if (reqDto.FirstName.Length < FirstNameMinLength || reqDto.FirstName.Length > FirstNameMaxLength) return false;
            if (reqDto.SecondName.Length < SecondNameMinLength || reqDto.SecondName.Length > SecondNameMaxLength)
                return false;

            if (reqDto.Address.Length < AddressMinLength || reqDto.Address.Length > AddressMaxLength) return false;

            #endregion

            return true;
        }

        #endregion

        #region Ограничения для сущности Client

        private const int _AddressMaxLength = 255;
        public int AddressMaxLength => _AddressMaxLength;

        private const int _AddressMinLength = 1;
        public int AddressMinLength => _AddressMinLength;

        #endregion
    }
}