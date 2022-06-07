using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Storages
{
    public interface ISellRepository
    {
        IEnumerable<SellResDto> GetAll();
        SellResDto GetById(SellReqDto reqDto);
        void Insert(SellReqDto reqDto);
        void DeleteById(SellReqDto reqDto);
    }
}
