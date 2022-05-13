using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class CdDiscLogic
    {
        private readonly IRepository<CdDiscReqDto, CdDiscResDto> _repository;
        public CdDiscLogic(IRepository<CdDiscReqDto, CdDiscResDto> repository)
        {
            _repository = repository;
        }
        public CdDiscResDto GetById(CdDiscReqDto reqDto)
        {
            if (reqDto == null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }

            if (reqDto.Id == null)
            {
                throw new Exception("Ошибка получения записи по Id: Id не указан");
            }

            try
            {
                var cdDisk = _repository.GetById(reqDto);
                return cdDisk;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записи по Id:" + ex.Message);
            }
        }
        public ICollection<CdDiscResDto> GetAll()
        {
            var listItems = _repository.GetAll();
            return listItems;
        }
        public void Save(CdDiscReqDto reqDto)
        {
            if (reqDto == null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }
            try
            {
                if (reqDto.Id.HasValue)
                {
                    _repository.Update(reqDto);
                }
                else
                {
                    _repository.Insert(reqDto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при сохранении записи:" + ex.Message);
            }
        }

        public void DeleteById(CdDiscReqDto reqDto)
        {
            if (reqDto == null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }

            if (reqDto.Id == null)
            {
                throw new Exception("Ошибка удаления записи по Id: Id не указан");
            }

            try
            {
                _repository.DeleteById(reqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении записи по Id:" + ex.Message);
            }
        }
    }
}
