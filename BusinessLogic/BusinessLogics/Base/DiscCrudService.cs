using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.BusinessLogics.Base
{
    public abstract class DiscCrudService<Req, Res> : CrudService<Req, Res> where Req : DiscReqDto, new() where Res : DiscResDto, new()
    {
        #region Ограничения для сущности Disc

        protected const int _TitleMaxLength = 50;
        public int TitleMaxLength => _TitleMaxLength;

        protected const int _TitleMinLength = 1;
        public int TitleMinLength => _TitleMinLength;

        protected readonly DateTime _DateOfReleaseMaxDate = new DateTime(2100, 1, 1);
        public DateTime DateOfReleaseMaxDate => _DateOfReleaseMaxDate;

        protected readonly DateTime _DateOfReleaseMinDate = new DateTime(1900, 1, 1);
        public DateTime DateOfReleaseMinDate => _DateOfReleaseMinDate;

        #endregion

        protected DiscCrudService(IDiscRepository<Req, Res> repository) : base(repository)
        {
        }
    }
}
