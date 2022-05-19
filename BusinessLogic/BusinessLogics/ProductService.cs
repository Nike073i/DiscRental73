using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

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

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void EditProductQuantity(EditProductQuantityReqDto reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }
            if (reqDto.EditQuantity > QuantityMaxValue || reqDto.EditQuantity < -QuantityMaxValue)
            {
                throw new Exception("Ошибка изменения количества продукции: Указано некорректное значение");
            }
            try
            {
                var item = _repository.GetById(new ProductReqDto { Id = reqDto.ProductId });
                if (item == null) throw new Exception("Ошибка изменения количества продукции: Продукт не найден");
                var changedReqDto = new ProductReqDto
                {
                    Id = item.Id,
                    Cost = item.Cost,
                    Quantity = reqDto.EditQuantity + item.Quantity,
                    DiscId = item.DiscId,
                    IsAvailable = item.IsAvailable
                };
                if (!IsCorrectReqDto(changedReqDto)) throw new Exception("Ошибка изменения количества продукции: Модель имеет некорректное значение");
                _repository.Update(changedReqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
            }
        }

        public void ChangeProductCost(ChangeProductCostReqDto reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }
            try
            {
                var item = _repository.GetById(new ProductReqDto { Id = reqDto.ProductId });
                if (item == null) throw new Exception("Ошибка изменения цены продукции: Продукт не найден");
                var changedReqDto = new ProductReqDto
                {
                    Id = item.Id,
                    Cost = reqDto.Cost,
                    Quantity = item.Quantity,
                    DiscId = item.DiscId,
                    IsAvailable = item.IsAvailable
                };
                if (!IsCorrectReqDto(changedReqDto)) throw new Exception("Ошибка изменения цены продукции: Модель имеет некорректное значение");
                _repository.Update(changedReqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
            }
        }

        public void Create(ProductReqDto reqDto)
        {
            if (!IsCorrectReqDto(reqDto))
            {
                throw new Exception("Ошибка при создании записи: модель некорректна");
            }
            try
            {
                _repository.Insert(reqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании записи:" + ex.Message);
            }
        }

        public void ChangeAvailable(ChangeProductAvailable reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }
            try
            {
                var item = _repository.GetById(new ProductReqDto { Id = reqDto.ProductId });
                if (item == null) throw new Exception("Ошибка изменения доступности продукции: Продукт не найден");
                if (item.IsAvailable.Equals(reqDto.IsAvailable)) return;
                var changedReqDto = new ProductReqDto
                {
                    Id = item.Id,
                    Cost = item.Id,
                    Quantity = item.Quantity,
                    DiscId = item.DiscId,
                    IsAvailable = reqDto.IsAvailable
                };
                _repository.Update(changedReqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
            }
        }

        public IEnumerable<ProductResDto> GetAll()
        {
            var listItems = _repository.GetAll();
            return listItems;
        }

        public IEnumerable<ProductResDto> GetAvailable()
        {
            var listItems = _repository.GetAll().Where(rec => rec.IsAvailable && rec.Quantity >= AvailableQuantityMinValue);
            return listItems;
        }

        public ProductResDto GetById(ProductReqDto reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }

            if (reqDto.Id is null)
            {
                throw new Exception("Ошибка получения записи по Id: Id не указан");
            }

            try
            {
                var item = _repository.GetById(reqDto);
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
    }
}