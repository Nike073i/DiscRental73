using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.BusinessLogics.Base;

public abstract class CrudService<Req, Res> where Req : ReqDto, new() where Res : ResDto, new()
{
    protected readonly IRepository<Req, Res> _repository;

    public CrudService(IRepository<Req, Res> repository)
    {
        _repository = repository;
    }

    public Res GetById(Req reqDto)
    {
        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

        if (reqDto.Id is null) throw new Exception("Ошибка получения записи по Id: Id не указан");

        try
        {
            var item = _repository.GetById(reqDto);
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записи по Id:" + ex.Message);
        }
    }

    public IEnumerable<Res> GetAll()
    {
        var listItems = _repository.GetAll();
        return listItems;
    }

    public void Save(Req reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при сохранении записи: модель некорректна");
        try
        {
            if (reqDto.Id.HasValue)
                _repository.Update(reqDto);
            else
                _repository.Insert(reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при сохранении записи:" + ex.Message);
        }
    }

    public void DeleteById(Req reqDto)
    {
        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

        if (reqDto.Id is null) throw new Exception("Ошибка удаления записи по Id: Id не указан");

        try
        {
            _repository.DeleteById(reqDto);
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
    protected abstract bool IsCorrectReqDto(Req reqDto);
}