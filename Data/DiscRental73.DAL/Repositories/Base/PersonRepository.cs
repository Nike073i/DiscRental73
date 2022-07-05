using DiscRental73.DAL.Context;
using DiscRental73.DAL.Entities.Base;

namespace DiscRental73.DAL.Repositories.Base
{
    public abstract class PersonRepository<T> : DbRepository<T>
        where T : Person, new()
    {
        #region constructors

        protected PersonRepository(DiscRentalDb db) : base(db) { }

        #endregion

        #region public methods

        public T? GetByContactNumber(string contactNumber) => Items
            .FirstOrDefault(rec => rec.ContactNumber.Equals(contactNumber));

        public T? GetByContactNumberLazy(string contactNumber) => Set
            .FirstOrDefault(rec => rec.ContactNumber.Equals(contactNumber));

        #endregion

        #region private methods

        private bool IsUniqueInsert(T entity) =>
            !Db.Persons.Any(rec => rec.ContactNumber.Equals(entity.ContactNumber) && !rec.Id.Equals(entity.Id));

        #endregion

        #region override methods

        public override void Update(T newEntity)
        {
            if (!IsUniqueInsert(newEntity))
                throw new Exception("Ошибка обновления записи: Номер уже занят");
            base.Update(newEntity);
        }

        public override int Insert(T newEntity)
        {
            if (!IsUniqueInsert(newEntity))
                throw new Exception("Ошибка добавления записи: Номер уже занят");
            return base.Insert(newEntity);
        }

        #endregion
    }
}