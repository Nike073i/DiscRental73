using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Interfaces.Repositories;

namespace DiscRental73.Domain.BusinessLogic.Base
{
    public abstract class PersonCrudService<TDto> : CrudService<TDto>
        where TDto : PersonDto
    {
        #region constructors

        protected PersonCrudService(IPersonRepository<TDto> repository) : base(repository) { }

        #endregion

        #region public methods

        public TDto? GetByContactNumber(string contactNumber)
        {
            if (string.IsNullOrEmpty(contactNumber))
                throw new Exception("Ошибка получения записи по номеру: Номер не указан");
            try
            {
                if (Repository is not IPersonRepository<TDto> repos) throw new Exception("Неверный тип репозитория!");
                return repos.GetByContactNumber(contactNumber);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записи по номеру:" + ex.Message);
            }
        }

        #endregion

        #region Ограничения для сущности Person

        protected const int _ContactNumberLength = 12;
        public int ContactNumberLength => _ContactNumberLength;

        protected const int _FirstNameMaxLength = 25;
        public int FirstNameMaxLength => _FirstNameMaxLength;

        protected const int _FirstNameMinLength = 1;
        public int FirstNameMinLength => _FirstNameMinLength;

        protected const int _SecondNameMaxLength = 25;
        public int SecondNameMaxLength => _SecondNameMaxLength;

        protected const int _SecondNameMinLength = 1;
        public int SecondNameMinLength => _SecondNameMinLength;

        #endregion
    }
}