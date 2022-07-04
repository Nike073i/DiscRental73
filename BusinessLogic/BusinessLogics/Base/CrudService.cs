using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.BusinessLogics.Base;

public abstract class CrudService<TReq, TRes>
    where TReq : ReqDto, new()
    where TRes : ResDto, new()
{
    #region readonly fields

    protected readonly ICrudRepository<TReq, TRes> Repository;

    #endregion

    #region constructors

    protected CrudService(ICrudRepository<TReq, TRes> repository)
    {
        Repository = repository;
    }

    #endregion

    #region public methods

    public TRes? GetById(int id)
    {
        try
        {
            var item = Repository.GetById(id);
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записи по Id:" + ex.Message, ex.InnerException);
        }
    }

    public IEnumerable<TRes> GetAll()
    {
        try
        {
            return Repository.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записей:" + ex.Message, ex.InnerException);
        }
    }

    public int Save(TReq reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при сохранении записи: модель некорректна");
        try
        {
            if (!reqDto.Id.HasValue) return Repository.Insert(reqDto);
            Repository.Update(reqDto);
            return reqDto.Id.Value;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при сохранении записи:" + ex.Message, ex.InnerException);
        }
    }

    public bool DeleteById(int id)
    {
        try
        {
            return Repository.DeleteById(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при удалении записи по Id:" + ex.Message);
        }
    }

    #endregion

    #region template-methods

    /// <summary>
    ///     Проверка валидации значений модели для сохранения
    /// </summary>
    /// <param name="reqDto">Модель для сохранения</param>
    /// <returns>bool - Результат валидации</returns>
    protected abstract bool IsCorrectReqDto(TReq reqDto);

    #endregion
}