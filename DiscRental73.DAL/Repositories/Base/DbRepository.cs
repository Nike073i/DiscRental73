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

        #region constructors

        protected DbRepository(DiscRentalDb db)
        {
            Db = db;
            Set = Db.Set<T>();
        }

        #endregion

        #region public methods

        public IEnumerable<T> GetAll()
        {
            try
            {
                return DoGetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения записей : " + ex.Message, ex.InnerException);
            }
        }

        public T? GetById(int id)
        {
            try
            {
                return DoGetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения записи : " + ex.Message, ex.InnerException);
            }
        }

        public int Insert(T entity)
        {
            try
            {
                return DoInsert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка добавления записи: " + ex.Message, ex.InnerException);
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                return DoDeleteById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка удаления по Id: " + ex.Message, ex.InnerException);
            }
        }

        public void Update(T entity)
        {
            try
            {
                DoUpdate(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка обновления записи: " + ex.Message, ex.InnerException);
            }
        }

        #endregion

        #region template-methods

        protected virtual IEnumerable<T> DoGetAll() => Set;

        protected virtual T? DoGetById(int id) => DoGetAll().AsQueryable().FirstOrDefault(rec => rec.Id.Equals(id));

        protected virtual int DoInsert(T newEntity)
        {
            Set.Add(newEntity);
            Db.SaveChanges();
            return newEntity.Id;
        }

        protected virtual bool DoDeleteById(int id)
        {
            var entity = Set.Find(id);
            if (entity is null) throw new Exception("Ошибка удаления по Id: Запись не найдена");
            entity.IsDeleted = true;
            Set.Update(entity).State = EntityState.Modified;
            Db.SaveChanges();
            return true;
        }

        protected virtual void DoUpdate(T newEntity)
        {
            if (!Set.Any(rec => rec.Id.Equals(newEntity.Id)))
                throw new Exception("Ошибка обновления записи: Запись не найдена");
            Set.Update(newEntity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        #endregion
    }
}