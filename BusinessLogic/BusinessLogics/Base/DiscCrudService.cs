using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics.Base
{
    public abstract class DiscCrudService<Req, Res> : CrudService<Req, Res> where Req : DiscReqDto, new() where Res : DiscResDto, new()
    {
        #region Ограничения для сущности Disc

        protected const int _TitleMaxLength = 50;
        protected const int _TitleMinLength = 1;

        protected readonly DateTime _DateOfReleaseMaxDate = new DateTime(2100, 1, 1);
        protected readonly DateTime _DateOfReleaseMinDate = new DateTime(1900, 1, 1);

        #endregion

        protected DiscCrudService(IDiscRepository<Req, Res> repository) : base(repository)
        {
        }
    }
}
