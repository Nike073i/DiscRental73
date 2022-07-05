using DiscRental73.Domain.BusinessLogic.Base;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.Domain.BusinessLogic
{
    public class DvdDiscService : DiscCrudService<DvdDiscDto>
    {
        #region constructors

        public DvdDiscService(IRepository<DvdDiscDto> repository) : base(repository) { }

        #endregion

        #region override template-methods

        protected override bool IsCorrectReqDto(DvdDiscDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (string.IsNullOrEmpty(reqDto.Title)) return false;
            if (string.IsNullOrEmpty(reqDto.Director)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.Title.Length < TitleMinLength || reqDto.Title.Length > TitleMaxLength) return false;
            if (reqDto.DateOfRelease < DateOfReleaseMinDate || reqDto.DateOfRelease > DateOfReleaseMaxDate) return false;
            if (reqDto.Title.Length < TitleMinLength || reqDto.Title.Length > TitleMaxLength) return false;

            if (reqDto.Director.Length < DirectorMinLength || reqDto.Director.Length > DirectorMaxLength) return false;
            if (!string.IsNullOrEmpty(reqDto.Info) &&
                (reqDto.Info.Length < InfoMinLength || reqDto.Info.Length > InfoMaxLength)) return false;
            if (!string.IsNullOrEmpty(reqDto.Plot) &&
                (reqDto.Plot.Length < PlotMinLength || reqDto.Plot.Length > PlotMaxLength)) return false;

            #endregion

            return true;
        }

        #endregion

        #region Ограничения для сущности DvdDisc

        private const int _DirectorMaxLength = 50;
        public int DirectorMaxLength => _DirectorMaxLength;

        private const int _DirectorMinLength = 1;
        public int DirectorMinLength => _DirectorMinLength;

        private const int _InfoMaxLength = 1023;
        public int InfoMaxLength => _InfoMaxLength;

        private const int _InfoMinLength = 1;
        public int InfoMinLength => _InfoMinLength;

        private const int _PlotMaxLength = 50;
        public int PlotMaxLength => _PlotMaxLength;

        private const int _PlotMinLength = 1;
        public int PlotMinLength => _PlotMinLength;

        #endregion
    }
}