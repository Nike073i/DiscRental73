using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages.Base;
using BusinessLogic.Interfaces.Storages.Base.Actions;

namespace BusinessLogic.Interfaces.Storages;

public interface ISellRepository : IRepository<SellReqDto, SellResDto>, IDeleteAction<SellReqDto>
{
}