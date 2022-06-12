using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.BusinessLogics.Base;

public abstract class CrudService<TReq, TRes> where TReq : ReqDto, new() where TRes : ResDto, new()
{
    protected readonly ICrudRepository<TReq, TRes> Repository;

    protected CrudService(ICrudRepository<TReq, TRes> repository)
    {
        Repository = repository;
    }

    public TRes GetById(int id)
    {
        try
        {
            var item = Repository.GetById(id);
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записи по Id:" + ex.Message);
        }
    }

    public IEnumerable<TRes> GetAll()
    {
        var listItems = Repository.GetAll();
        return listItems;
    }

    public TRes Save(TReq reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при сохранении записи: модель некорректна");
        try
        {
            var resDto = reqDto.Id.HasValue ? Repository.Update(reqDto) : Repository.Insert(reqDto);
            return resDto;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при сохранении записи:" + ex.Message);
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

    /// <summary>
    ///     Проверка валидации значений модели для сохранения
    /// </summary>
    /// <param name="reqDto">Модель для сохранения</param>
    /// <returns>bool - Результат валидации</returns>
    protected abstract bool IsCorrectReqDto(TReq reqDto);
}