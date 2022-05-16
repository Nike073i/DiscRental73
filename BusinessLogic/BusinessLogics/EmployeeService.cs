using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class EmployeeService : PersonCrudService<EmployeeReqDto, EmployeeResDto>
    {
        #region Ограничения для сущности Employee

        private const int _PasswordMaxLength = 25;
        private const int _PasswordMinLength = 5;

        private const float _PrizeMaxValue = 100000f;
        private const float _PrizeMinValue = 1f;

        #endregion

        public EmployeeService(IPersonRepository<EmployeeReqDto, EmployeeResDto> repository) : base(repository)
        {
        }

        protected override bool IsCorrectReqDto(EmployeeReqDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) return false;
            if (string.IsNullOrEmpty(reqDto.ContactNumber)) return false;
            if (string.IsNullOrEmpty(reqDto.FirstName)) return false;
            if (string.IsNullOrEmpty(reqDto.SecondName)) return false;

            if (string.IsNullOrEmpty(reqDto.Password)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.ContactNumber.Length != _ContactNumberLength) return false;
            if (reqDto.FirstName.Length < _FirstNameMinLength || reqDto.FirstName.Length > _FirstNameMaxLength) return false;
            if (reqDto.SecondName.Length < _SecondNameMinLength || reqDto.SecondName.Length > _SecondNameMaxLength) return false;

            if (reqDto.Password.Length < _PasswordMinLength || reqDto.Password.Length > _PasswordMaxLength) return false;
            if (reqDto.Prize is not null && (reqDto.Prize < _PrizeMinValue || reqDto.Prize > _PrizeMaxValue)) return false;

            #endregion

            return true;
        }
    }
}
