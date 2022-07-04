using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage.Base;

namespace BusinessLogic.BusinessLogics.Base;

public abstract class DiscCrudService<TReq, TRes> : CrudService<TReq, TRes>
    where TReq : DiscReqDto, new()
    where TRes : DiscResDto, new()
{
    #region constructors

    protected DiscCrudService(ICrudRepository<TReq, TRes> repository) : base(repository)
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