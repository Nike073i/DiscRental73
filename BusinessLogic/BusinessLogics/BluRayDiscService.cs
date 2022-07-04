using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

namespace BusinessLogic.BusinessLogics;

public class BluRayDiscService : DiscCrudService<BluRayDiscReqDto, BluRayDiscResDto>, IBluRayDiscService
{
    #region constructors

    public BluRayDiscService(IBluRayDiscRepository repository) : base(repository) { }

    #endregion

    #region override template-methods

    protected override bool IsCorrectReqDto(BluRayDiscReqDto reqDto)
    {
        #region Проверка пустых/нулевых значений обязательных полей

        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
        if (string.IsNullOrEmpty(reqDto.Title)) return false;
        if (string.IsNullOrEmpty(reqDto.Publisher)) return false;

        #endregion

        #region Проверка области допустимых значений

        if (reqDto.Title.Length < TitleMinLength || reqDto.Title.Length > TitleMaxLength) return false;
        if (reqDto.DateOfRelease < DateOfReleaseMinDate || reqDto.DateOfRelease > DateOfReleaseMaxDate) return false;
        if (reqDto.Title.Length < TitleMinLength || reqDto.Title.Length > TitleMaxLength) return false;

        if (reqDto.Publisher.Length < PublisherMinLength || reqDto.Publisher.Length > PublisherMaxLength) return false;
        if (!string.IsNullOrEmpty(reqDto.Info) &&
            (reqDto.Info.Length < InfoMinLength || reqDto.Info.Length > InfoMaxLength)) return false;
        return string.IsNullOrEmpty(reqDto.SystemRequirements) ||
               (reqDto.SystemRequirements.Length >= SystemRequirementsMinLength
                && reqDto.SystemRequirements.Length <= SystemRequirementsMaxLength);

        #endregion
    }

    #endregion

    #region Ограничения для сущности BluRayDisc

    private const int _PublisherMaxLength = 50;
    public int PublisherMaxLength => _PublisherMaxLength;

    private const int _PublisherMinLength = 1;
    public int PublisherMinLength => _PublisherMinLength;

    private const int _InfoMaxLength = 1023;
    public int InfoMaxLength => _InfoMaxLength;

    private const int _InfoMinLength = 1;
    public int InfoMinLength => _InfoMinLength;

    private const int _SystemRequirementsMaxLength = 1023;
    public int SystemRequirementsMaxLength => _SystemRequirementsMaxLength;

    private const int _SystemRequirementsMinLength = 1;
    public int SystemRequirementsMinLength => _SystemRequirementsMinLength;

    #endregion
}