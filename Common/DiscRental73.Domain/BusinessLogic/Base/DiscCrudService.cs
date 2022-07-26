using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Interfaces.Repositories.Base;
using DiscRental73.Interfaces.Services;

namespace DiscRental73.Domain.BusinessLogic.Base
{
    public abstract class DiscCrudService<TDto> : CrudService<TDto>
        where TDto : DtoBase
    {
        #region constructors

        protected DiscCrudService(IRepository<TDto> repository) : base(repository)
        {
            DateOfReleaseMaxDate = new DateTime(2100, 1, 1);
            DateOfReleaseMinDate = new DateTime(1900, 1, 1);
        }

        #endregion

        #region Ограничения для сущности Disc

        protected const int _TitleMaxLength = 50;
        public int TitleMaxLength => _TitleMaxLength;

        protected const int _TitleMinLength = 1;
        public int TitleMinLength => _TitleMinLength;
        public DateTime DateOfReleaseMaxDate { get; }
        public DateTime DateOfReleaseMinDate { get; }

        #endregion
    }
}