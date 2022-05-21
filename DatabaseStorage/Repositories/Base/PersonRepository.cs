using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Repositories.Base
{
    public abstract class PersonRepository<Req, Res, T> : DbRepository<Req, Res, T> where Req : PersonReqDto, new() where Res : PersonResDto, new() where T : Person, new()
    {
        public virtual Res GetByContactNumber(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            T? entity = set.SingleOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        public override void Update(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            T? entity = set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка обновления записи: Запись не найдена");
            }
            Person? entityWithNumber = db.Persons.FirstOrDefault(rec => !rec.Id.Equals(reqDto.Id) && rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entityWithNumber is not null) throw new Exception("Ошибка обновления записи: Номер уже занят");
            try
            {
                _mapper.MapToEntity(in entity, reqDto);
                set.Update(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка обновления записи: " + ex.Message);
            }
        }

        public override void Insert(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            Person? entityFromDb = db.Persons.SingleOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entityFromDb is not null) throw new Exception("Ошибка добавления записи: Номер уже занят");

            try
            {
                var entity = new T();
                _mapper.MapToEntity(in entity, reqDto);
                set.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка добавления записи: " + ex.Message);
            }
        }
    }
}
