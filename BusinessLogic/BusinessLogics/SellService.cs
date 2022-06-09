using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics;

public class SellService : ISellService
{
    protected readonly IProductService ProductService;
    protected readonly ISellRepository Repository;

    public SellService(ISellRepository repository, IProductService productService)
    {
        Repository = repository;
        ProductService = productService;
    }

    public void SellProduct(SellReqDto reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при создании записи: модель некорректна");
        try
        {
            ProductService.EditProductQuantity(new EditProductQuantityReqDto
            { ProductId = reqDto.ProductId, EditQuantity = -1 });
            Repository.Insert(reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при создании записи:" + ex.Message);
        }
    }

    public IEnumerable<SellResDto> GetAll() => Repository.GetAll();

    public IEnumerable<ProductResDto> GetProducts() => ProductService.GetAvailable();

    public void CancelSell(SellReqDto reqDto)
    {
        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

        if (reqDto.Id is null) throw new Exception("Ошибка отмены продажи: Id не указан");

        try
        {
            var item = Repository.GetById(new SellReqDto { Id = reqDto.Id });
            if (item == null) throw new Exception("Ошибка отмены продажи: Продажа не найдена");
            ProductService.EditProductQuantity(new EditProductQuantityReqDto
            { ProductId = item.ProductId, EditQuantity = +1 });
            Repository.DeleteById(reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при отмене проката :" + ex.Message);
        }
    }

    private bool IsCorrectReqDto(SellReqDto reqDto)
    {
        #region Проверка области допустимых значений

        if (reqDto.DateOfSell < DateMinValue || reqDto.DateOfSell > DateMaxValue) return false;

        #endregion

        return true;
    }

    #region Ограничения для сущности Sell

    public DateTime DateMaxValue { get; } = new(2100, 1, 1);

    public DateTime DateMinValue { get; } = new(2000, 1, 1);

    #endregion
}