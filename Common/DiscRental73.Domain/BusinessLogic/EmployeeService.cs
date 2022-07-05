using DiscRental73.Domain.BusinessLogic.Base;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories;

namespace DiscRental73.Domain.BusinessLogic
{
    public class EmployeeService : PersonCrudService<EmployeeDto>
    {
        #region constructors

        public EmployeeService(IPersonRepository<EmployeeDto> repository) : base(repository) { }

        #endregion

        #region public methods

        public EmployeeDto? Authorization(string contactNumber, string password)
        {
            if (string.IsNullOrEmpty(password)) throw new Exception("Ошибка авторизации: Не указан пароль");
            try
            {
                var employee = GetByContactNumber(contactNumber);
                if (employee == null) throw new Exception("Ошибка авторизации: Пользователь не найден");
                return (password.ToLower().Equals(employee.Password.ToLower())) ? employee : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка авторизации:" + ex.Message, ex.InnerException);
            }
        }

        #endregion

        #region override template-methods

        protected override bool IsCorrectReqDto(EmployeeDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
            if (string.IsNullOrEmpty(reqDto.ContactNumber)) return false;
            if (string.IsNullOrEmpty(reqDto.FirstName)) return false;
            if (string.IsNullOrEmpty(reqDto.SecondName)) return false;

            if (string.IsNullOrEmpty(reqDto.Password)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.ContactNumber.Length != ContactNumberLength) return false;
            if (reqDto.FirstName.Length < FirstNameMinLength || reqDto.FirstName.Length > FirstNameMaxLength) return false;
            if (reqDto.SecondName.Length < SecondNameMinLength || reqDto.SecondName.Length > SecondNameMaxLength)
                return false;

            if (reqDto.Password.Length < PasswordMinLength || reqDto.Password.Length > PasswordMaxLength) return false;
            if (reqDto.Prize is not null && (reqDto.Prize < PrizeMinValue || reqDto.Prize > PrizeMaxValue)) return false;

            #endregion

            return true;
        }

        #endregion

        #region Ограничения для сущности Employee

        private const int _PasswordMaxLength = 25;
        public int PasswordMaxLength => _PasswordMaxLength;

        private const int _PasswordMinLength = 5;
        public int PasswordMinLength => _PasswordMinLength;

        private const decimal _PrizeMaxValue = 100000M;
        public decimal PrizeMaxValue => _PrizeMaxValue;

        private const decimal _PrizeMinValue = 1M;
        public decimal PrizeMinValue => _PrizeMinValue;

        #endregion
    }
}