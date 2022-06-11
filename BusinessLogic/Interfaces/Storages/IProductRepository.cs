using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages.Base;
using BusinessLogic.Interfaces.Storages.Base.Actions;

namespace BusinessLogic.Interfaces.Storages;

public interface IProductRepository : IRepository<ProductReqDto, ProductResDto>, IUpdateAction<ProductReqDto>
{
}