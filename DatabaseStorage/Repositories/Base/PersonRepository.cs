using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entities.Base;

namespace DatabaseStorage.Repositories.Base;

public abstract class PersonRepository<TReq, TRes, T> : DbRepository<TReq, TRes, T>
    where TReq : PersonReqDto, new()
    where TRes : PersonResDto, new()
    where T : Person, new()
{
    #region constructors

    protected PersonRepository(DiscRentalDb db) : base(db) { }

    #endregion

    #region methods

    public virtual TRes? GetByContactNumber(string contactNumber)
    {
        try
        {
            var entity = Set.SingleOrDefault(rec => rec.ContactNumber.Equals(contactNumber));
            if (entity is null || entity.IsDeleted) return null;

            return Mapper.MapToRes(entity);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения записи по н.телефона : " + ex.Message, ex.InnerException);
        }
    }

    protected override TRes? DoUpdate(in DiscRentalDb db, TReq reqDto)
    {
        var entity = Set.Find(reqDto.Id);
        if (entity is null || entity.IsDeleted) throw new Exception("Ошибка обновления записи: Запись не найдена");

        var busyNumberEntity = db.Persons.FirstOrDefault(rec =>
            !rec.Id.Equals(reqDto.Id) && rec.ContactNumber.Equals(reqDto.ContactNumber));
        if (busyNumberEntity is not null) throw new Exception("Ошибка обновления записи: Номер уже занят");
        Mapper.MapToEntity(entity, reqDto);
        var changedEntity = Set.Update(entity).Entity;
        if (changedEntity is null) return null;
        db.SaveChanges();
        return Mapper.MapToRes(changedEntity);
    }

    #endregion

    #region override template-methods

    protected override TRes? DoInsert(in DiscRentalDb db, TReq reqDto)
    {
        var storedEntity = db.Persons.SingleOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
        if (storedEntity is not null) throw new Exception("Ошибка добавления записи: Номер уже занят");

        var model = new T();
        Mapper.MapToEntity(model, reqDto);
        var entity = Set.Add(model).Entity;
        if (entity is null) return null;
        db.SaveChanges();
        return Mapper.MapToRes(entity);
    }

    #endregion
}