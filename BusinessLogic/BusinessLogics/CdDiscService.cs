using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class CdDiscService : DiscCrudService<CdDiscReqDto, CdDiscResDto>
    {
        #region Ограничения для сущности CdDisc

        private const int _PerformerMaxLength = 50;
        private const int _PerformerMinLength = 1;

        private const int _GenreMaxLength = 50;
        private const int _GenreMinLength = 1;

        private const int _NumberOfTracksMaxValue = 100;
        private const int _NumberOfTracksMinValue = 1;

        #endregion

        public CdDiscService(IDiscRepository<CdDiscReqDto, CdDiscResDto> repository) : base(repository)
        {
        }

        protected override bool IsCorrectReqDto(CdDiscReqDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) return false;
            if (string.IsNullOrEmpty(reqDto.Title)) return false;
            if (string.IsNullOrEmpty(reqDto.Performer)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.Title.Length < _TitleMinLength || reqDto.Title.Length > _TitleMaxLength) return false;
            if (reqDto.DateOfRelease < _DateOfReleaseMinDate || reqDto.DateOfRelease > _DateOfReleaseMaxDate) return false;
            if (reqDto.Title.Length < _TitleMinLength || reqDto.Title.Length > _TitleMaxLength) return false;

            if (reqDto.Performer.Length < _PerformerMinLength || reqDto.Performer.Length > _PerformerMaxLength) return false;
            if (!string.IsNullOrEmpty(reqDto.Genre) && (reqDto.Genre.Length < _GenreMinLength || reqDto.Genre.Length > _GenreMaxLength)) return false;
            if (reqDto.NumberOfTracks is not null && (reqDto.NumberOfTracks < _NumberOfTracksMinValue || reqDto.NumberOfTracks > _NumberOfTracksMaxValue)) return false;

            #endregion

            return true;
        }
    }
}
