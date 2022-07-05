﻿using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.Domain.BusinessLogic
{
    public class RentalService
    {
        #region readonly fields

        private readonly ProductService _ProductService;
        private readonly IRepository<RentalDto> _Repository;

        #endregion

        #region constuctors

        public RentalService(IRepository<RentalDto> repository, ProductService productService)
        {
            _Repository = repository;
            _ProductService = productService;
        }

        #endregion

        #region public methods

        public bool IssueRental(RentalDto reqDto)
        {
            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
            if (!IsCorrectReqDto(reqDto)) throw new Exception("Ошибка при создании записи: модель некорректна");
            try
            {
                _ProductService.EditProductQuantity(reqDto.ProductId, -1);
                _Repository.Insert(reqDto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании записи:" + ex.Message, ex.InnerException);
            }
        }

        public bool IssueReturn(int rentalId, decimal returnSum)
        {
            try
            {
                var item = _Repository.GetById(rentalId);
                if (item == null) throw new Exception("Ошибка возврата проката: Прокат не найден");
                var issueReturnReqDto = new RentalDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ClientId = item.ClientId,
                    EmployeeId = item.EmployeeId,
                    DateOfIssue = item.DateOfIssue,
                    DateOfRental = item.DateOfRental,
                    PledgeSum = item.PledgeSum,
                    ReturnSum = returnSum
                };
                if (!IsCorrectReqDto(issueReturnReqDto))
                    throw new Exception("Ошибка возврата проката: Модель имеет некорректное значение");
                _ProductService.EditProductQuantity(issueReturnReqDto.ProductId, 1);
                _Repository.Update(issueReturnReqDto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка изменения количества продукции: " + ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            try
            {
                return _ProductService.GetAvailable();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения продуктов : " + ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<RentalDto> GetInRental()
        {
            try
            {
                return _Repository.GetAll().Where(rec => rec.ReturnSum is null);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения прокатных записей : " + ex.Message, ex.InnerException);
            }
        }

        public IEnumerable<RentalDto> GetAll()
        {
            try
            {
                return _Repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка получения прокатов : " + ex.Message, ex.InnerException);
            }
        }

        public bool CancelRental(RentalDto reqDto)
        {
            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));
            if (!reqDto.Id.Equals(default)) throw new Exception("Ошибка отмены проката: Id не указан");
            try
            {
                var item = _Repository.GetById(reqDto.Id);
                if (item == null) throw new Exception("Ошибка отмены проката: Прокат не найден");
                _ProductService.EditProductQuantity(item.ProductId, 1);
                return _Repository.DeleteById(reqDto.Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при отмене проката :" + ex.Message, ex.InnerException);
            }
        }

        #endregion

        #region override template-methods

        private bool IsCorrectReqDto(RentalDto reqDto)
        {
            #region Проверка полученных параметров

            if (reqDto is null) throw new ArgumentNullException(nameof(reqDto));

            #endregion

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

        #endregion

        #region Ограничения для сущности Rental

        public DateTime DateMaxValue { get; } = new(2100, 1, 1);

        public DateTime DateMinValue { get; } = new(2000, 1, 1);

        private const decimal _PledgeSumMaxValue = 100000M;
        public decimal PledgeSumMaxValue => _PledgeSumMaxValue;

        private const decimal _PledgeSumMinValue = 1M;
        public decimal PledgeSumMinValue => _PledgeSumMinValue;

        private const decimal _ReturnSumMaxValue = 100000M;
        public decimal ReturnSumMaxValue => _ReturnSumMaxValue;

        private const decimal _ReturnSumMinValue = 0M;
        public decimal ReturnSumMinValue => _ReturnSumMinValue;

        #endregion
    }
}