using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class BluRayService : DiscCrudService<BluRayDiscReqDto, BluRayDiscResDto>
    {
        #region Ограничения для сущности BluRayDisc

        private const DiscType _DiscType = DiscType.BluRay;

        private const int _PublisherMaxLength = 50;
        private const int _PublisherMinLength = 1;

        private const int _InfoMaxLength = 1023;
        private const int _InfoMinLength = 1;

        private const int _SystemRequirementsMaxLength = 1023;
        private const int _SystemRequirementsMinLength = 1;

        #endregion

        public BluRayService(IRepository<BluRayDiscReqDto, BluRayDiscResDto> repository) : base(repository)
        {
        }

        protected override bool IsCorrectReqDto(BluRayDiscReqDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) return false;
            if (string.IsNullOrEmpty(reqDto.Title)) return false;
            if (string.IsNullOrEmpty(reqDto.Publisher)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.Title.Length < _TitleMinLength || reqDto.Title.Length > _TitleMaxLength) return false;
            if (reqDto.DiscType != _DiscType) return false;
            if (reqDto.DateOfRelease < _DateOfReleaseMinDate || reqDto.DateOfRelease > _DateOfReleaseMaxDate) return false;
            if (reqDto.Title.Length < _TitleMinLength || reqDto.Title.Length > _TitleMaxLength) return false;

            if (reqDto.Publisher.Length < _PublisherMinLength || reqDto.Publisher.Length > _PublisherMaxLength) return false;
            if (reqDto.Info is not null && (reqDto.Info.Length < _InfoMinLength || reqDto.Info.Length > _InfoMaxLength)) return false;
            if (reqDto.SystemRequirements is not null && (reqDto.SystemRequirements.Length < _SystemRequirementsMinLength || reqDto.SystemRequirements.Length > _SystemRequirementsMaxLength)) return false;

            #endregion

            return true;
        }
    }
}
