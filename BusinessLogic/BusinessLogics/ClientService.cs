using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class ClientService : PersonCrudService<ClientReqDto, ClientResDto>
    {
        #region Ограничения для сущности Client

        private const int _AddressMaxLength = 255;
        public int AddressMaxLength => _AddressMaxLength;

        private const int _AddressMinLength = 1;
        public int AddressMinLength => _AddressMinLength;

        #endregion

        public ClientService(IClientRepository repository) : base(repository)
        {
        }

        protected override bool IsCorrectReqDto(ClientReqDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) return false;
            if (string.IsNullOrEmpty(reqDto.ContactNumber)) return false;
            if (string.IsNullOrEmpty(reqDto.FirstName)) return false;
            if (string.IsNullOrEmpty(reqDto.SecondName)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.ContactNumber.Length != ContactNumberLength) return false;
            if (reqDto.FirstName.Length < FirstNameMinLength || reqDto.FirstName.Length > FirstNameMaxLength) return false;
            if (reqDto.SecondName.Length < SecondNameMinLength || reqDto.SecondName.Length > SecondNameMaxLength) return false;

            if (reqDto.Address.Length < AddressMinLength || reqDto.Address.Length > AddressMaxLength) return false;

            #endregion

            return true;
        }
    }
}
