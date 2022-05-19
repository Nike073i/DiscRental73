using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.BusinessLogics.Base
{
    public abstract class PersonCrudService<Req, Res> : CrudService<Req, Res> where Req : PersonReqDto, new() where Res : PersonResDto, new()
    {
        #region Ограничения для сущности Person

        protected const int _ContactNumberLength = 12;
        public int ContactNumberLength => _ContactNumberLength;

        protected const int _FirstNameMaxLength = 25;
        public int FirstNameMaxLength => _FirstNameMaxLength;

        protected const int _FirstNameMinLength = 1;
        public int FirstNameMinLength => _FirstNameMinLength;

        protected const int _SecondNameMaxLength = 25;
        public int SecondNameMaxLength => _SecondNameMaxLength;

        protected const int _SecondNameMinLength = 1;
        public int SecondNameMinLength => _SecondNameMinLength;

        #endregion

        protected PersonCrudService(IPersonRepository<Req, Res> repository) : base(repository)
        {
        }

        public Res GetByContactNumber(Req reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }

            if (string.IsNullOrEmpty(reqDto.ContactNumber))
            {
                throw new Exception("Ошибка получения записи по номеру: Номер не указан");
            }

            try
            {
                var personRepos = _repository as IPersonRepository<Req, Res>;
                var item = personRepos.GetByContactNumber(reqDto);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записи по Id:" + ex.Message);
            }
        }
    }
}
