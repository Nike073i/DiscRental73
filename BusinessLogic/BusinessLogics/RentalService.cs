using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.BusinessLogics
{
    public class RentalService
    {
        protected readonly IRentalRepository _repository;
        protected readonly ProductService _productService;

        #region Ограничения для сущности Rental

        private readonly DateTime _DateMaxValue = new DateTime(2100, 1, 1);
        private readonly DateTime _DateMinValue = new DateTime(2000, 1, 1);

        private const double _PledgeSumMaxValue = 100000d;
        private const double _PledgeSumMinValue = 1d;

        private const double _ReturnSumMaxValue = 100000d;
        private const double _ReturnSumMinValue = 0d;

        #endregion

        public RentalService(IRentalRepository repository, ProductService productService)
        {
            _repository = repository;
            _productService = productService;
        }

        public void IssueRental(RentalReqDto reqDto)
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

        public void IssueReturn(IssueReturnReqDto reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }
            try
            {
                var item = _repository.GetById(new RentalReqDto { Id = reqDto.RentalId });
                if (item == null) throw new Exception("Ошибка возврата проката: Прокат не найден");
                var issueReturnReqDto = new RentalReqDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ClientId = item.ClientId,
                    EmployeeId = item.EmployeeId,
                    DateOfIssue = item.DateOfIssue,
                    DateOfRental = item.DateOfRental,
                    PledgeSum = item.PledgeSum,
                    ReturnSum = reqDto.ReturnSum
                };
                if (!IsCorrectReqDto(issueReturnReqDto)) throw new Exception("Ошибка возврата проката: Модель имеет некорректное значение");
                _productService.EditProductQuantity(new EditProductQuantityReqDto { ProductId = issueReturnReqDto.ProductId, EditQuantity = +1 });
                _repository.Update(issueReturnReqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
            }
        }

        public IEnumerable<ProductResDto> GetProducts() => _productService.GetAvailable();

        public void CancelRental(RentalReqDto reqDto)
        {
            if (reqDto is null)
            {
                throw new ArgumentNullException(nameof(reqDto));
            }

            if (reqDto.Id is null)
            {
                throw new Exception("Ошибка отмены проката: Id не указан");
            }

            try
            {
                var item = _repository.GetById(new RentalReqDto { Id = reqDto.Id });
                if (item == null) throw new Exception("Ошибка отмены проката: Прокат не найден");
                _productService.EditProductQuantity(new EditProductQuantityReqDto { ProductId = item.ProductId, EditQuantity = +1 });
                _repository.DeleteById(reqDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при отмене проката :" + ex.Message);
            }
        }

        private bool IsCorrectReqDto(RentalReqDto reqDto)
        {
            #region Проверка области допустимых значений

            if (reqDto.DateOfIssue < _DateMinValue || reqDto.DateOfIssue > _DateMaxValue) return false;
            if (reqDto.DateOfRental < reqDto.DateOfIssue || reqDto.DateOfRental < _DateMinValue || reqDto.DateOfIssue > _DateMaxValue) return false;
            if (reqDto.PledgeSum < _PledgeSumMinValue || reqDto.ReturnSum > _PledgeSumMaxValue) return false;

            if (reqDto.ReturnSum is not null && (reqDto.ReturnSum < _ReturnSumMinValue || reqDto.ReturnSum > _ReturnSumMaxValue)) return false;

            #endregion

            return true;
        }
    }
}
