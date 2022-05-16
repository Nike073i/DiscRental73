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
        private const int _AddressMinLength = 1;

        #endregion

        public ClientService(IRepository<ClientReqDto, ClientResDto> repository) : base(repository)
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

            if (reqDto.ContactNumber.Length != _ContactNumberLength) return false;
            if (reqDto.FirstName.Length < _FirstNameMinLength || reqDto.FirstName.Length > _FirstNameMaxLength) return false;
            if (reqDto.SecondName.Length < _SecondNameMinLength || reqDto.SecondName.Length > _SecondNameMaxLength) return false;

            if (reqDto.Address.Length < _AddressMinLength || reqDto.Address.Length > _AddressMaxLength) return false;

            #endregion

            return true;
        }
    }
}
