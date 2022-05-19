using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class SellService
    {
        protected readonly ISellRepository _repository;
        protected readonly ProductService _productService;

        #region Ограничения для сущности Sell

        private readonly DateTime _DateMaxValue = new DateTime(2100, 1, 1);
        public DateTime DateMaxValue => _DateMaxValue;

        private readonly DateTime _DateMinValue = new DateTime(2000, 1, 1);
        public DateTime DateMinValue => _DateMinValue;

        #endregion

        public SellService(ISellRepository repository, ProductService productService)
        {
            _repository = repository;
            _productService = productService;
        }

        public void SellProduct(SellReqDto reqDto)
        {
            if (!IsCorrectReqDto(reqDto))
            {
                throw new Exception("Ошибка при создании записи: модель некорректна");
            }
            try
            {
                _productService.EditProductQuantity(new EditProductQuantityReqDto { ProductId = reqDto.ProductId, EditQuantity = -1 });
                _repository.Insert(reqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании записи:" + ex.Message);
            }
        }

        public IEnumerable<ProductResDto> GetProducts() => _productService.GetAvailable();

        public void CancelSell(SellReqDto reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }

            if (reqDto.Id is null)
            {
                throw new Exception("Ошибка отмены продажи: Id не указан");
            }

            try
            {
                var item = _repository.GetById(new SellReqDto { Id = reqDto.Id });
                if (item == null) throw new Exception("Ошибка отмены продажи: Продажа не найдена");
                _productService.EditProductQuantity(new EditProductQuantityReqDto { ProductId = item.ProductId, EditQuantity = +1 });
                _repository.DeleteById(reqDto);
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
    }
}
