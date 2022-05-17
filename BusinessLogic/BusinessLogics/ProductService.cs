using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class ProductService
    {
        protected readonly IProductRepository _repository;

        #region Ограничения для сущности Product
        private const int _AvailableQuantityMinValue = 5;

        private const int _QuantityMaxValue = 100000;
        private const int _QuantityMinValue = 0;

        private const float _CostMaxValue = 100000f;
        private const float _CostMinValue = 1f;

        #endregion

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void EditProductQuantity(ChangeProductQuantityReqDto reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }
            if (reqDto.EditQuantity > _QuantityMaxValue || reqDto.EditQuantity < -_QuantityMaxValue)
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
            var listItems = _repository.GetAll().Where(rec => rec.IsAvailable && rec.Quantity >= _AvailableQuantityMinValue);
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

            if (reqDto.Cost < _CostMinValue || reqDto.Cost > _CostMaxValue) return false;
            if (reqDto.Quantity < _QuantityMinValue || reqDto.Quantity > _QuantityMaxValue) return false;

            #endregion

            return true;
        }
    }
}