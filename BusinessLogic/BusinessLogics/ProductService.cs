using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    // НЕРЕАЛИЗОВАН //
    public class ProductService
    {
        protected readonly IProductRepository _repository;

        #region Ограничения для сущности Product

        private const int _PasswordMaxLength = 25;
        private const int _PasswordMinLength = 5;

        private const float _PrizeMaxValue = 100000f;
        private const float _PrizeMinValue = 1f;

        #endregion

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void ChangeProductQuantity(ChangeProductQuantityReqDto reqDto)
        {
            // Реализация //
        }

        public void ChangeProductCost(ChangeProductCostReqDto reqDto)
        {
            // Реализация //
        }

        public void Create(ProductReqDto reqDto)
        {
            // Реализация //
        }

        public void Hide(ProductReqDto reqDto)
        {
            // Реализация //
        }

        public IEnumerable<ProductResDto> GetAll()
        {
            // Реализация //
            return new List<ProductResDto>();
        }

        private bool IsCorrectReqDto(ProductReqDto reqDto)
        {
            #region Проверка пустых/нулевых значений обязательных полей

            if (reqDto is null) return false;
            if (string.IsNullOrEmpty(reqDto.ContactNumber)) return false;
            if (string.IsNullOrEmpty(reqDto.FirstName)) return false;
            if (string.IsNullOrEmpty(reqDto.SecondName)) return false;

            #endregion

            #region Проверка области допустимых значений

            if (reqDto.ContactNumber.Length != _ContactNumberLength) return false;
            if (reqDto.FirstName.Length < _FirstNameMinLength || reqDto.FirstName.Length > _FirstNameMaxLength) return false;
            if (reqDto.SecondName.Length < _SecondNameMinLength || reqDto.SecondName.Length > _SecondNameMaxLength) return false;

            if (reqDto.Address.Length < _AddressMinLength || reqDto.Address.Length > _AddressMaxLength) return false;

            #endregion

            return true;
        }
    }
}
