using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;

namespace DatabaseStorage.Repositories.Base
{
    public abstract class PersonRepository<TReq, TRes, T> : DbRepository<TReq, TRes, T> where TReq : PersonReqDto, new() where TRes : PersonResDto, new() where T : Person, new()
    {
        protected PersonRepository(DiscRentalDb db) : base(db)
        {
        }

        public virtual TRes GetByContactNumber(TReq reqDto)
        {
            try
            {
                var set = Db.Set<T>();

                var entity = set.SingleOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
                if (entity is null || entity.IsDeleted)
                {
                    throw new Exception("Запись не найдена");
                }

                return Mapper.MapToRes(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения записи по н.телефона : " + ex.Message, ex.InnerException);
            }
        }

        protected override void DoUpdate(in DiscRentalDb db, TReq reqDto)
        {
            var set = db.Set<T>();

            var entity = set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка обновления записи: Запись не найдена");
            }
            var entityWithNumber = db.Persons.FirstOrDefault(rec => !rec.Id.Equals(reqDto.Id) && rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entityWithNumber is not null) throw new Exception("Ошибка обновления записи: Номер уже занят");
            Mapper.MapToEntity(in entity, reqDto);
            set.Update(entity);
            db.SaveChanges();
        }

        protected override void DoInsert(in DiscRentalDb db, TReq reqDto)
        {
            var set = db.Set<T>();

            var entityFromDb = db.Persons.SingleOrDefault(rec => rec.ContactNumber.Equals(reqDto.ContactNumber));
            if (entityFromDb is not null) throw new Exception("Ошибка добавления записи: Номер уже занят");

            var entity = new T();
            Mapper.MapToEntity(in entity, reqDto);
            set.Add(entity);
            db.SaveChanges();
        }
    }
}
