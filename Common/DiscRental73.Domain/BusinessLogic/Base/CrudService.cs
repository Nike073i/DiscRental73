using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Repositories.Base;
using DiscRental73.Interfaces.Services.Base;

namespace DiscRental73.Domain.BusinessLogic.Base
{
    public abstract class CrudService<TDto> : ICrudService<TDto>
        where TDto : DtoBase
    {
        #region readonly fields

        protected readonly IRepository<TDto> Repository;

        #endregion

        #region constructors

        protected CrudService(IRepository<TDto> repository)
        {
            Repository = repository;
        }

        #endregion

        #region public methods

        public TDto? GetById(int id)
        {
            try
            {
                return Repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записи по Id:" + ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<TDto> GetAll()
        {
            try
            {
                return Repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записей:" + ex.Message, ex.InnerException);
            }
        }

        public int Save(TDto reqDto)
        {
            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
            if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при сохранении записи: модель некорректна");
            try
            {
                if (reqDto.Id.Equals(default)) return Repository.Insert(reqDto);
                Repository.Update(reqDto);
                return reqDto.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при сохранении записи:" + ex.Message, ex.InnerException);
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                return Repository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении записи по Id:" + ex.Message);
            }
        }

        #endregion

        #region template-methods

        /// <summary>
        ///     Проверка валидации значений модели для сохранения
        /// </summary>
        /// <param name="reqDto">Модель для сохранения</param>
        /// <returns>bool - Результат валидации</returns>
        protected abstract bool IsCorrectReqDto(TDto reqDto);

        #endregion
    }

    public abstract class CrudService<TDto, TDetailDto> : CrudService<TDto>, ICrudService<TDto, TDetailDto>
        where TDto : DtoBase
        where TDetailDto : DtoBase, IDetailDto
    {
        #region readonly fields

        protected new readonly IRepository<TDto, TDetailDto> Repository;

        #endregion

        #region constructors

        protected CrudService(IRepository<TDto, TDetailDto> repository) : base(repository)
        {
            Repository = repository;
        }

        #endregion

        #region public methods

        public TDetailDto? GetByIdDetail(int id)
        {
            try
            {
                return Repository.GetByIdDetail(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записи по Id:" + ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<TDetailDto> GetAllDetail()
        {
            try
            {
                return Repository.GetAllDetail();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записей:" + ex.Message, ex.InnerException);
            }
        }

        #endregion
    }
}