using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes.Base;
using DatabaseStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    public class DbRepository<Req, Res, T> : IRepository<Req, Res> where Req : ReqDto, new() where Res : ResDto, new() where T : Entity, new()
    {
        protected readonly DiscRentalDb _db;
        protected readonly DbSet<T> _set;
        protected readonly IDbMapper<Req, Res, T> _mapper;

        public DbRepository(DiscRentalDb db, IDbMapper<Req, Res, T> mapper)
        {
            _db = db;
            _set = db.Set<T>();
            _mapper = mapper;
        }

        public virtual ICollection<Res> GetAll()
        {
            return _set.Where(entity => !entity.IsDeleted).Select(rec => _mapper.MapToRes(rec)).ToList();
        }

        public virtual void Insert(Req reqDto)
        {
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

        public virtual void DeleteById(Req reqDto)
        {
            T? entity = _set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка удаления по Id: Запись не найдена");
            }
            try
            {
                entity.IsDeleted = true;
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка удаления по Id: " + ex.Message);
            }
        }

        public virtual Res GetById(Req reqDto)
        {
            T? entity = _set.SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            return _mapper.MapToRes(entity);
        }

        public virtual void Update(Req reqDto)
        {
            T? entity = _set.FirstOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Ошибка обновления записи: Запись не найдена");
            }
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
    }
}
