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
        public int PerformerMaxLength => _PerformerMaxLength;

        private const int _PerformerMinLength = 1;
        public int PerformerMinLength => _PerformerMinLength;

        private const int _GenreMaxLength = 50;
        public int GenreMaxLength => _GenreMaxLength;

        private const int _GenreMinLength = 1;
        public int GenreMinLength => _GenreMinLength;

        private const int _NumberOfTracksMaxValue = 100;
        public int NumberOfTracksMaxValue => _NumberOfTracksMaxValue;

        private const int _NumberOfTracksMinValue = 1;
        public int NumberOfTracksMinValue => _NumberOfTracksMinValue;

        #endregion

        public CdDiscService(ICdDiscRepository repository) : base(repository)
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

            if (reqDto.Title.Length < TitleMinLength || reqDto.Title.Length > TitleMaxLength) return false;
            if (reqDto.DateOfRelease < DateOfReleaseMinDate || reqDto.DateOfRelease > DateOfReleaseMaxDate) return false;
            if (reqDto.Title.Length < TitleMinLength || reqDto.Title.Length > TitleMaxLength) return false;

            if (reqDto.Performer.Length < PerformerMinLength || reqDto.Performer.Length > PerformerMaxLength) return false;
            if (!string.IsNullOrEmpty(reqDto.Genre) && (reqDto.Genre.Length < GenreMinLength || reqDto.Genre.Length > GenreMaxLength)) return false;
            if (reqDto.NumberOfTracks is not null && (reqDto.NumberOfTracks < NumberOfTracksMinValue || reqDto.NumberOfTracks > NumberOfTracksMaxValue)) return false;

            #endregion

            return true;
        }
    }
}
