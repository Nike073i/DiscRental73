using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    internal class DvdDiscService : DiscCrudService<DvdDiscReqDto, DvdDiscResDto>
    {
        #region Ограничения для сущности DvdDisc

        private const DiscType _DiscType = DiscType.DVD;

        private const int _DirectorMaxLength = 50;
        private const int _DirectorMinLength = 1;

        private const int _InfoMaxLength = 1023;
        private const int _InfoMinLength = 1;

        private const int _PlotMaxLength = 50;
        private const int _PlotMinLength = 1;

        #endregion

        public DvdDiscService(IRepository<DvdDiscReqDto, DvdDiscResDto> repository) : base(repository)
        {
        }

        protected override bool IsCorrectReqDto(DvdDiscReqDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) return false;
            if (string.IsNullOrEmpty(reqDto.Title)) return false;
            if (string.IsNullOrEmpty(reqDto.Director)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.Title.Length < _TitleMinLength || reqDto.Title.Length > _TitleMaxLength) return false;
            if (reqDto.DiscType != _DiscType) return false;
            if (reqDto.DateOfRelease < _DateOfReleaseMinDate || reqDto.DateOfRelease > _DateOfReleaseMaxDate) return false;
            if (reqDto.Title.Length < _TitleMinLength || reqDto.Title.Length > _TitleMaxLength) return false;

            if (reqDto.Director.Length < _DirectorMinLength || reqDto.Director.Length > _DirectorMaxLength) return false;
            if (reqDto.Info is not null && (reqDto.Info.Length < _InfoMinLength || reqDto.Info.Length > _InfoMaxLength)) return false;
            if (reqDto.Plot is not null && (reqDto.Plot.Length < _PlotMinLength || reqDto.Plot.Length > _PlotMaxLength)) return false;

            #endregion

            return true;
        }
    }
}
