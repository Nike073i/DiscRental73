using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics.Base
{
    public abstract class PersonCrudService<Req, Res> : CrudService<Req, Res> where Req : ReqDto, new() where Res : ResDto, new()
    {
        #region Ограничения для сущности Person

        protected const int _ContactNumberLength = 12;

        protected const int _FirstNameMaxLength = 25;
        protected const int _FirstNameMinLength = 1;

        protected const int _SecondNameMaxLength = 25;
        protected const int _SecondNameMinLength = 1;

        #endregion

        protected PersonCrudService(IRepository<Req, Res> repository) : base(repository)
        {
        }
    }
}
