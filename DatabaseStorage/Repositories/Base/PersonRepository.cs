using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories.Base
{
    public abstract class PersonRepository<Req, Res, T> : DbRepository<Req, Res, T>, IPersonRepository<Req, Res> where Req : PersonReqDto, new() where Res : PersonResDto, new() where T : Person, new()
    {
        protected PersonRepository(DiscRentalDb db) : base(db)
        {
        }

        public virtual Res GetByContactNumber(Req reqDto)
        {
            T? entity = _set.SingleOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        public override void Update(Req reqDto)
        {
            T? entity = _set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка обновления записи: Запись не найдена");
            }
            T? entityWithNumber = _set.FirstOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entityWithNumber is not null) throw new Exception("Ошибка обновления записи: Номер уже занят");
            try
            {
                _mapper.MapToEntity(in entity, reqDto);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка удаления по Id: " + ex.Message);
            }
        }

        public override void Insert(Req reqDto)
        {
            T? entityFromDb = _set.SingleOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entityFromDb is not null) throw new Exception("Ошибка добавления записи: Номер уже занят");

            try
            {
                var entity = new T();
                _mapper.MapToEntity(in entity, reqDto);
                _set.Add(entity);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка добавления записи: " + ex.Message);
            }
        }
    }
}
