using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DiscRental73.DAL.Repositories.Base
{
    public abstract class DbRepository<T>
        where T : Entity, new()
    {
        #region readonly fields

        protected readonly DiscRentalDb Db;
        protected readonly DbSet<T> Set;

        #endregion

        #region properties

        protected virtual IQueryable<T> Items => Set;

        #endregion

        #region constructors

        protected DbRepository(DiscRentalDb db)
        {
            Db = db;
            Set = Db.Set<T>();
        }

        #endregion

        #region public methods

        public bool Exist(int id) => Set.Find(id) is not null;

        public IEnumerable<T> GetAllLazy() => Set.ToList();

        public IEnumerable<T> GetAll() => Items.ToList();

        public T? GetById(int id) => Items.FirstOrDefault(rec => rec.Id.Equals(id));

        public T? GetByIdLazy(int id) => Set.Find(id);

        public virtual int Insert(T entity)
        {
            Set.Add(entity);
            Db.SaveChanges();
            return entity.Id;
        }

        public virtual bool DeleteById(int id)
        {
            var entity = GetByIdLazy(id);
            if (entity is null) throw new Exception("Ошибка удаления по Id: Запись не найдена");
            entity.IsDeleted = true;
            Set.Update(entity).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        public virtual void Update(T entity)
        {
            var originalEntity = GetByIdLazy(entity.Id);
            if (originalEntity is null) throw new Exception("Ошибка обновления записи: Запись не найдена");
            Db.Entry(originalEntity).State = EntityState.Detached;
            Set.Update(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        #endregion
    }
}