using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

namespace BusinessLogic.BusinessLogics;

public class ProductService : IProductService
{
    private readonly IProductRepository _Repository;

    public ProductService(IProductRepository repository)
    {
        _Repository = repository;
    }

    public bool EditProductQuantity(int productId, int editQuantity)
    {
        if (editQuantity > QuantityMaxValue || editQuantity < -QuantityMaxValue)
            throw new Exception("Ошибка изменения количества продукции: Указано некорректное значение");
        try
        {
            var item = _Repository.GetById(productId);
            if (item == null) throw new Exception("Ошибка изменения количества продукции: Продукт не найден");
            var changedReqDto = new ProductReqDto
            {
                Id = item.Id,
                Cost = item.Cost,
                Quantity = editQuantity + item.Quantity,
                DiscId = item.DiscId,
                IsAvailable = item.IsAvailable
            };
            if (!IsCorrectReqDto(changedReqDto))
                throw new Exception("Ошибка изменения количества продукции: Модель имеет некорректное значение");
            _Repository.Update(changedReqDto);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
        }
    }

    public bool ChangeProductCost(int productId, double cost)
    {
        try
        {
            var item = _Repository.GetById(productId);
            if (item == null) throw new Exception("Ошибка изменения цены продукции: Продукт не найден");
            var changedReqDto = new ProductReqDto
            {
                Id = item.Id,
                Cost = cost,
                Quantity = item.Quantity,
                DiscId = item.DiscId,
                IsAvailable = item.IsAvailable
            };
            if (!IsCorrectReqDto(changedReqDto))
                throw new Exception("Ошибка изменения цены продукции: Модель имеет некорректное значение");
            _Repository.Update(changedReqDto);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
        }
    }

    public bool ChangeAvailable(int productId, bool isAvailable)
    {
        try
        {
            var item = _Repository.GetById(productId);
            if (item == null) throw new Exception("Ошибка изменения доступности продукции: Продукт не найден");
            if (item.IsAvailable.Equals(isAvailable)) return true;
            var changedReqDto = new ProductReqDto
            {
                Id = item.Id,
                Cost = item.Id,
                Quantity = item.Quantity,
                DiscId = item.DiscId,
                IsAvailable = isAvailable
            };
            _Repository.Update(changedReqDto);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
        }
    }

    public ProductResDto Create(ProductReqDto reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при создании записи: модель некорректна");
        try
        {
            return _Repository.Insert(reqDto);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при создании записи:" + ex.Message);
        }
    }

    public IEnumerable<ProductResDto> GetAll()
    {
        var listItems = _Repository.GetAll();
        return listItems;
    }

    public IEnumerable<ProductResDto> GetAvailable()
    {
        var listItems = _Repository.GetAll().Where(rec => rec.IsAvailable && rec.Quantity >= AvailableQuantityMinValue);
        return listItems;
    }

    public ProductResDto GetById(int id)
    {
        try
        {
            var item = _Repository.GetById(id);
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записи по Id:" + ex.Message);
        }
    }

    private bool IsCorrectReqDto(ProductReqDto reqDto)
    {
        #region Проверка области допустимых значений

        if (reqDto.Cost < CostMinValue || reqDto.Cost > CostMaxValue) return false;
        if (reqDto.Quantity < QuantityMinValue || reqDto.Quantity > QuantityMaxValue) return false;

        #endregion

        return true;
    }

    #region Ограничения для сущности Product

    private const int _AvailableQuantityMinValue = 5;
    public int AvailableQuantityMinValue => _AvailableQuantityMinValue;

    private const int _QuantityMaxValue = 100000;
    public int QuantityMaxValue => _QuantityMaxValue;

    private const int _QuantityMinValue = 0;
    public int QuantityMinValue => _QuantityMinValue;

    private const double _CostMaxValue = 100000d;
    public double CostMaxValue => _CostMaxValue;

    private const double _CostMinValue = 1d;
    public double CostMinValue => _CostMinValue;

    #endregion
}