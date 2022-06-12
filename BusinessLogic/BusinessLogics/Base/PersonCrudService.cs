using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.BusinessLogics.Base;

public abstract class PersonCrudService<TReq, TRes> : CrudService<TReq, TRes>
    where TReq : PersonReqDto, new() where TRes : PersonResDto, new()
{
    protected PersonCrudService(IPersonRepository<TReq, TRes> repository) : base(repository)
    {
    }

    public TRes GetByContactNumber(string contactNumber)
    {
        if (string.IsNullOrEmpty(contactNumber))
            throw new Exception("Ошибка получения записи по номеру: Номер не указан");

        try
        {
            var personRepos = Repository as IPersonRepository<TReq, TRes>;
            var item = personRepos.GetByContactNumber(contactNumber);
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записи по номеру:" + ex.Message);
        }
    }

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