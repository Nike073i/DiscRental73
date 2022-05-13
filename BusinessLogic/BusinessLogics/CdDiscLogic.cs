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
            return new CdDiscResDto();
        }
        public List<CdDiscResDto> GetAll()
        {
            return new List<CdDiscResDto>();
        }
        public void Save(CdDiscReqDto reqDto)
        {

        }
        public void DeleteById(CdDiscReqDto reqDto)
        {

        }
    }
}
