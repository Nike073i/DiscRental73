using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Repositories;
using DiscRental73.Interfaces.Services.Base;

namespace DiscRental73.Domain.BusinessLogic.Base
{
    public abstract class PersonCrudService<TDto, TDetailDto> : CrudService<TDto, TDetailDto>, IPersonService<TDto, TDetailDto>
        where TDto : PersonDto
        where TDetailDto : PersonDto, IDetailDto
    {
        #region readonly fields

        protected new IPersonRepository<TDto, TDetailDto> Repository;

        #endregion

        #region constructors

        protected PersonCrudService(IPersonRepository<TDto, TDetailDto> repository) : base(repository)
        {
            Repository = repository;
        }

        #endregion

        #region public methods

        public TDto? GetByContactNumber(string contactNumber)
        {
            if (string.IsNullOrEmpty(contactNumber))
                throw new ArgumentNullException(nameof(contactNumber), "Ошибка получения записи по номеру: Номер не указан");
            try
            {
                return Repository.GetByContactNumber(contactNumber);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записи по номеру:" + ex.Message);
            }
        }

        public TDetailDto? GetByContactNumberDetail(string contactNumber)
        {
            if (string.IsNullOrEmpty(contactNumber))
                throw new ArgumentNullException(nameof(contactNumber), "Ошибка получения записи по номеру: Номер не указан");
            try
            {
                return Repository.GetByContactNumberDetail(contactNumber);
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