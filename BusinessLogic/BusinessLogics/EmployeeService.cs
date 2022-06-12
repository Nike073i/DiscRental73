using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

namespace BusinessLogic.BusinessLogics;

public class EmployeeService : PersonCrudService<EmployeeReqDto, EmployeeResDto>, IEmployeeService
{
    public EmployeeService(IEmployeeRepository repository) : base(repository)
    {
    }

    public EmployeeResDto? Authorization(string contactNumber, string password)
    {
        if (string.IsNullOrEmpty(password)) throw new Exception("Ошибка авторизации: Не указан пароль");

        try
        {
            var employee = GetByContactNumber(contactNumber);
            if (employee == null) throw new Exception("Ошибка авторизации: Пользователь не найден");
            EmployeeResDto? currentEmployee = null;
            if (password.ToLower().Equals(employee.Password.ToLower())) currentEmployee = employee;
            return currentEmployee;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка авторизации:" + ex.Message);
        }
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

        if (reqDto.ContactNumber.Length != ContactNumberLength) return false;
        if (reqDto.FirstName.Length < FirstNameMinLength || reqDto.FirstName.Length > FirstNameMaxLength) return false;
        if (reqDto.SecondName.Length < SecondNameMinLength || reqDto.SecondName.Length > SecondNameMaxLength)
            return false;

        if (reqDto.Password.Length < PasswordMinLength || reqDto.Password.Length > PasswordMaxLength) return false;
        if (reqDto.Prize is not null && (reqDto.Prize < PrizeMinValue || reqDto.Prize > PrizeMaxValue)) return false;

        #endregion

        return true;
    }

    #region Ограничения для сущности Employee

    private const int _PasswordMaxLength = 25;
    public int PasswordMaxLength => _PasswordMaxLength;

    private const int _PasswordMinLength = 5;
    public int PasswordMinLength => _PasswordMinLength;

    private const float _PrizeMaxValue = 100000f;
    public float PrizeMaxValue => _PrizeMaxValue;

    private const float _PrizeMinValue = 1f;
    public float PrizeMinValue => _PrizeMinValue;

    #endregion
}