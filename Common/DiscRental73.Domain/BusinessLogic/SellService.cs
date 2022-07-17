using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;
using DiscRental73.Interfaces.Services.Base;

namespace DiscRental73.Domain.BusinessLogic
{
    public class SellService : IService<SellDto, SellDetailDto>
    {
        #region readonly fields

        private readonly ProductService _ProductService;
        private readonly IRepository<SellDto, SellDetailDto> _Repository;

        #endregion

        #region constuctors

        public SellService(IRepository<SellDto, SellDetailDto> repository, ProductService productService)
        {
            _Repository = repository;
            _ProductService = productService;
        }

        #endregion

        #region public methods

        public int SellProduct(SellDto reqDto)
        {
            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
            if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при создании записи: модель некорректна");
            try
            {
                _ProductService.EditProductQuantity(reqDto.ProductId, -1);
                return _Repository.Insert(reqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании записи:" + ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<SellDto> GetAll()
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

        public SellDto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SellDetailDto> GetAllDetail()
        {
            try
            {
                return _Repository.GetAllDetail();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения продаж : " + ex.Message, ex.InnerException);
            }
        }

        public SellDetailDto? GetByIdDetail(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts() => _ProductService.GetAvailable();

        public IEnumerable<ProductDetailDto> GetProductsDetail() => _ProductService.GetAvailableDetail();

        public bool CancelSell(SellDto reqDto)
        {
            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
            if (reqDto.Id.Equals(default)) throw new Exception("Ошибка отмены продажи: Id не указан");
            try
            {
                var item = _Repository.GetById(reqDto.Id);
                if (item == null) throw new Exception("Ошибка отмены продажи: Продажа не найдена");
                _ProductService.EditProductQuantity(item.ProductId, 1);
                return _Repository.DeleteById(reqDto.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при отмене проката :" + ex.Message, ex.InnerException);
            }
        }

        #endregion

        #region private methods

        private bool IsCorrectReqDto(SellDto reqDto)
        {
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
}