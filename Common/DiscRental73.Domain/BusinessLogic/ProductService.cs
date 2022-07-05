using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.Domain.BusinessLogic
{
    public class ProductService
    {
        #region readonly fields

        private readonly IRepository<ProductDto, ProductDetailDto> _Repository;

        #endregion

        #region constructors

        public ProductService(IRepository<ProductDto, ProductDetailDto> repository)
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
                var changedReqDto = new ProductDto
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
                var changedReqDto = new ProductDto
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
                var changedReqDto = new ProductDto
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

        public int Create(ProductDto reqDto)
        {
            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
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

        public IEnumerable<ProductDto> GetAll()
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

        public IEnumerable<ProductDetailDto> GetAllDetail()
        {
            try
            {
                return _Repository.GetAllDetail();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения продуктов: " + ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<ProductDto> GetAvailable() => GetAll()
            .Where(rec => rec.IsAvailable
            && rec.Quantity >= AvailableQuantityMinValue);

        public IEnumerable<ProductDetailDto> GetAvailableDetail() => GetAllDetail()
            .Where(rec => rec.IsAvailable
                          && rec.Quantity >= AvailableQuantityMinValue);

        public ProductDto? GetById(int id)
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

        public ProductDetailDto? GetByIdDetail(int id)
        {
            try
            {
                return _Repository.GetByIdDetail(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении записи по Id:" + ex.Message, ex.InnerException);
            }
        }

        #endregion

        #region override template-methods

        private bool IsCorrectReqDto(ProductDto reqDto)
        {
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
}