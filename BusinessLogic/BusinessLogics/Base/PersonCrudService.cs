using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.BusinessLogics.Base;

public abstract class PersonCrudService<TReq, TRes> : CrudService<TReq, TRes>
    where TReq : PersonReqDto, new() where TRes : PersonResDto, new()
{
    #region constructors

    protected PersonCrudService(IPersonRepository<TReq, TRes> repository) : base(repository) { }

    #endregion

    #region public methods

    public TRes? GetByContactNumber(string contactNumber)
    {
        if (string.IsNullOrEmpty(contactNumber))
            throw new Exception("Ошибка получения записи по номеру: Номер не указан");
        try
        {
            if (Repository is not IPersonRepository<TReq, TRes> repos) throw new Exception("Неверный тип репозитория!");
            return repos.GetByContactNumber(contactNumber);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записи по номеру:" + ex.Message);
        }
    }

    #endregion

    #region Ограничения для сущности Person

    protected const int _ContactNumberLength = 12;
    public int ContactNumberLength => _ContactNumberLength;

    protected const int _FirstNameMaxLength = 25;
    public int FirstNameMaxLength => _FirstNameMaxLength;

    protected const int _FirstNameMinLength = 1;
    public int FirstNameMinLength => _FirstNameMinLength;

    protected const int _SecondNameMaxLength = 25;
    public int SecondNameMaxLength => _SecondNameMaxLength;

    protected const int _SecondNameMinLength = 1;
    public int SecondNameMinLength => _SecondNameMinLength;

    #endregion
}