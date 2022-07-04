using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

namespace BusinessLogic.BusinessLogics;

public class SellService : ISellService
{
    #region readonly fields

    private readonly IProductService _ProductService;
    private readonly ISellRepository _Repository;

    #endregion

    #region constuctors

    public SellService(ISellRepository repository, IProductService productService)
    {
        _Repository = repository;
        _ProductService = productService;
    }

    #endregion

    #region public methods


    public bool SellProduct(SellReqDto reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при создании записи: модель некорректна");
        try
        {
            _ProductService.EditProductQuantity(reqDto.ProductId, -1);
            _Repository.Insert(reqDto);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при создании записи:" + ex.Message, ex.InnerException);
        }
    }

    public IEnumerable<SellResDto> GetAll()
    {
        try
        {
            return _Repository.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения продаж : " + ex.Message, ex.InnerException);
        }
    }

    public IEnumerable<ProductResDto> GetProducts()
    {
        try
        {
            return _ProductService.GetAvailable();
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения продуктов" + ex.Message, ex.InnerException);
        }
    }

    public bool CancelSell(SellReqDto reqDto)
    {
        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
        if (reqDto.Id is null) throw new Exception("Ошибка отмены продажи: Id не указан");
        try
        {
            var item = _Repository.GetById(reqDto.Id.Value);
            if (item == null) throw new Exception("Ошибка отмены продажи: Продажа не найдена");
            _ProductService.EditProductQuantity(item.ProductId, 1);
            return _Repository.DeleteById(reqDto.Id.Value);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при отмене проката :" + ex.Message, ex.InnerException);
        }
    }

    #endregion

    #region private methods

    private bool IsCorrectReqDto(SellReqDto reqDto)
    {
        #region Проверка полученных параметров

        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

        #endregion

        #region Проверка области допустимых значений

        if (reqDto.DateOfSell < DateMinValue || reqDto.DateOfSell > DateMaxValue) return false;

        #endregion

        return true;
    }

    #endregion

    #region Ограничения для сущности Sell

    public DateTime DateMaxValue { get; } = new(2100, 1, 1);

    public DateTime DateMinValue { get; } = new(2000, 1, 1);

    #endregion
}