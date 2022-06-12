using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

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

    public bool SellProduct(SellReqDto reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при создании записи: модель некорректна");
        try
        {
            ProductService.EditProductQuantity(reqDto.ProductId, -1);
            Repository.Insert(reqDto);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при создании записи:" + ex.Message);
        }
    }

    public IEnumerable<SellResDto> GetAll() => Repository.GetAll();

    public IEnumerable<ProductResDto> GetProducts() => ProductService.GetAvailable();

    public bool CancelSell(SellReqDto reqDto)
    {
        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

        if (reqDto.Id is null) throw new Exception("Ошибка отмены продажи: Id не указан");

        try
        {
            var item = Repository.GetById(reqDto.Id.Value);
            if (item == null) throw new Exception("Ошибка отмены продажи: Продажа не найдена");
            ProductService.EditProductQuantity(item.ProductId, 1);
            return Repository.DeleteById(reqDto.Id.Value);
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