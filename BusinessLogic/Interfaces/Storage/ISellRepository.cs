using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage.Base;
using BusinessLogic.Interfaces.Storage.Base.Actions;

namespace BusinessLogic.Interfaces.Storage;

public interface ISellRepository : IRepository<SellReqDto, SellResDto>, IDeleteAction
{
}