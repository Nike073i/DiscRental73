using BusinessLogic.Interfaces.Storages.Base;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes.Base;
using DatabaseStorage.Mappers.Base;

namespace DatabaseStorage.Repositories
{
    public abstract class DbRepository<Req, Res, T> where Req : ReqDto, new() where Res : ResDto, new() where T : Entity, new()
    {
        protected readonly IDbMapper<Req, Res, T> _mapper;

        public DbRepository()
        {
            _mapper = CreateMapper();
        }

        protected abstract IDbMapper<Req, Res, T> CreateMapper();

        public virtual ICollection<Res> GetAll()
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            return set.Where(entity => !entity.IsDeleted)
                .Select(rec => _mapper.MapToRes(rec))
                .ToList();
        }

        public virtual void Insert(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();
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

        public virtual void DeleteById(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            T? entity = set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка удаления по Id: Запись не найдена");
            }
            try
            {
                entity.IsDeleted = true;
                set.Update(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка удаления по Id: " + ex.Message);
            }
        }

        public virtual Res GetById(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            T? entity = set.SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        public virtual void Update(Req reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<T>();

            T? entity = set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка обновления записи: Запись не найдена");
            }
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
    }
}
