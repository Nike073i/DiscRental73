﻿using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

namespace BusinessLogic.BusinessLogics;

public class ProductService : IProductService
{
    #region readonly fields

    private readonly IProductRepository _Repository;

    #endregion

    #region constructors

    public ProductService(IProductRepository repository)
    {
        _Repository = repository;
    }

    #endregion

    #region public methods

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
            throw new Exception("Ошибка изменения количества продукции: " + ex.Message, ex.InnerException);
        }
    }

    public bool ChangeProductCost(int productId, decimal cost)
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
            throw new Exception("Ошибка изменения количества продукции: " + ex.Message, ex.InnerException);
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
            throw new Exception("Ошибка изменения количества продукции: " + ex.Message, ex.InnerException);
        }
    }

    public int Create(ProductReqDto reqDto)
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
        try
        {
            return _Repository.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка получения продуктов: " + ex.Message, ex.InnerException);
        }
    }

    public IEnumerable<ProductResDto> GetAvailable()
    {
        try
        {
            return _Repository.GetAll()
                .Where(rec => rec.IsAvailable && rec.Quantity >= AvailableQuantityMinValue);
        }
        catch (Exception e)
        {
            throw new Exception("Ошибка получения доступных продуктов : " + e.Message, e.InnerException);
        }

    }

    public ProductResDto? GetById(int id)
    {
        try
        {
            return _Repository.GetById(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при получении записи по Id:" + ex.Message, ex.InnerException);
        }
    }

    #endregion

    #region override template-methods

    private bool IsCorrectReqDto(ProductReqDto reqDto)
    {
        #region Проверка полученных аргументов

        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

        #endregion

        #region Проверка области допустимых значений

        if (reqDto.Cost < CostMinValue || reqDto.Cost > CostMaxValue) return false;
        if (reqDto.Quantity < QuantityMinValue || reqDto.Quantity > QuantityMaxValue) return false;

        #endregion

        return true;
    }

    #endregion

    #region Ограничения для сущности Product

    private const int _AvailableQuantityMinValue = 5;
    public int AvailableQuantityMinValue => _AvailableQuantityMinValue;

    private const int _QuantityMaxValue = 100000;
    public int QuantityMaxValue => _QuantityMaxValue;

    private const int _QuantityMinValue = 0;
    public int QuantityMinValue => _QuantityMinValue;

    private const decimal _CostMaxValue = 100000M;
    public decimal CostMaxValue => _CostMaxValue;

    private const decimal _CostMinValue = 1M;
    public decimal CostMinValue => _CostMinValue;

    #endregion
}