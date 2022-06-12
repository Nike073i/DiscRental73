using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Storage;

namespace BusinessLogic.BusinessLogics;

public class RentalService : IRentalService
{
    protected readonly IProductService ProductService;
    protected readonly IRentalRepository Repository;

    public RentalService(IRentalRepository repository, IProductService productService)
    {
        Repository = repository;
        ProductService = productService;
    }

    public bool IssueRental(RentalReqDto reqDto)
    {
        if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при создании записи: модель некорректна");
        try
        {
            ProductService.EditProductQuantity(reqDto.ProductId, -1);
            Repository.Insert(reqDto);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при создании записи:" + ex.Message);
        }
    }

    public bool IssueReturn(IssueReturnReqDto reqDto)
    {
        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
        try
        {
            var item = Repository.GetById(reqDto.RentalId);
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
            if (!IsCorrectReqDto(issueReturnReqDto))
                throw new Exception("Ошибка возврата проката: Модель имеет некорректное значение");
            ProductService.EditProductQuantity(issueReturnReqDto.ProductId, 1);
            Repository.Update(issueReturnReqDto);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка изменения количества продукции: " + ex.Message);
        }
    }

    public IEnumerable<ProductResDto> GetProducts()
    {
        return ProductService.GetAvailable();
    }

    public IEnumerable<RentalResDto> GetInRental()
    {
        return Repository.GetAll().Where(rec => rec.ReturnSum is null);
    }

    public IEnumerable<RentalResDto> GetAll()
    {
        return Repository.GetAll();
    }

    public bool CancelRental(RentalReqDto reqDto)
    {
        if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

        if (!reqDto.Id.HasValue) throw new Exception("Ошибка отмены проката: Id не указан");

        try
        {
            var item = Repository.GetById(reqDto.Id.Value);
            if (item == null) throw new Exception("Ошибка отмены проката: Прокат не найден");
            ProductService.EditProductQuantity(item.ProductId, 1);
            return Repository.DeleteById(reqDto.Id.Value);
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при отмене проката :" + ex.Message);
        }
    }

    private bool IsCorrectReqDto(RentalReqDto reqDto)
    {
        #region Проверка области допустимых значений

        if (reqDto.DateOfIssue < DateMinValue || reqDto.DateOfIssue > DateMaxValue) return false;
        if (reqDto.DateOfRental < reqDto.DateOfIssue || reqDto.DateOfRental < DateMinValue ||
            reqDto.DateOfIssue > DateMaxValue) return false;
        if (reqDto.PledgeSum < PledgeSumMinValue || reqDto.ReturnSum > PledgeSumMaxValue) return false;

        if (reqDto.ReturnSum is not null &&
            (reqDto.ReturnSum < ReturnSumMinValue || reqDto.ReturnSum > ReturnSumMaxValue)) return false;

        #endregion

        return true;
    }

    #region Ограничения для сущности Rental

    public DateTime DateMaxValue { get; } = new(2100, 1, 1);

    public DateTime DateMinValue { get; } = new(2000, 1, 1);

    private const double _PledgeSumMaxValue = 100000d;
    public double PledgeSumMaxValue => _PledgeSumMaxValue;

    private const double _PledgeSumMinValue = 1d;
    public double PledgeSumMinValue => _PledgeSumMinValue;

    private const double _ReturnSumMaxValue = 100000d;
    public double ReturnSumMaxValue => _ReturnSumMaxValue;

    private const double _ReturnSumMinValue = 0d;
    public double ReturnSumMinValue => _ReturnSumMinValue;

    #endregion
}