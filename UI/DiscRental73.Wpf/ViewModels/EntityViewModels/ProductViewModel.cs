using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Enums.ModelEnums;
using DiscRental73.Wpf.ViewModels.Base;
using System;
using System.Collections.Generic;

namespace DiscRental73.Wpf.ViewModels.EntityViewModels
{
    public class ProductViewModel : EntityViewModel
    {
        #region constructors

        public ProductViewModel() : this(new ProductDto()) { }

        public ProductViewModel(ProductDto product)
        {
            Id = product.Id;
            _Cost = product.Cost;
            _Quantity = product.Quantity;
            _DiscId = product.DiscId;
            _IsAvailable = product.IsAvailable;
        }

        public ProductViewModel(ProductDetailDto product) : this((ProductDto)product)
        {
            DiscType = product.DiscType;
            DiscDate = product.DiscDate;
            DiscTitle = product.DiscTitle;
        }

        #endregion

        #region properties

        #region AvailableDiscs : IEnumerable<DiscDto> - Список доступных для привязки дисков

        /// <summary>Список доступных для привязки дисков</summary>
        private IEnumerable<DiscDto>? _AvailableDiscs;

        /// <summary>Список доступных для привязки дисков</summary>
        public IEnumerable<DiscDto>? AvailableDiscs
        {
            get => _AvailableDiscs;
            set => Set(ref _AvailableDiscs, value);
        }

        #endregion

        /// <summary>Идентификатор продукта</summary>
        private int Id { get; }

        #region Cost : decimal - Стоимость продукта

        /// <summary>Стоимость продукта</summary>
        private decimal _Cost;

        /// <summary>Стоимость продукта</summary>
        public decimal Cost { get => _Cost; set => Set(ref _Cost, value); }

        #endregion

        #region Quantity : int - Количество продукта на складе

        /// <summary>Количество продукта на складе</summary>
        private int _Quantity;

        /// <summary>Количество продукта на складе</summary>
        public int Quantity { get => _Quantity; set => Set(ref _Quantity, value); }

        #endregion

        #region DiscId : int - Идентификатор диска

        /// <summary>Идентификатор диска</summary>
        private int _DiscId;

        /// <summary>Идентификатор диска</summary>
        public int DiscId { get => _DiscId; set => Set(ref _DiscId, value); }

        #endregion

        /// <summary>Название диска</summary>
        public string? DiscTitle { get; }
        /// <summary>Тип диска</summary>
        public DiscType? DiscType { get; }
        /// <summary>Дата выпуска</summary>
        public DateTime? DiscDate { get; }

        #region IsAvailable : bool - Доступность товара к прокату или продаже

        /// <summary>Доступность товара к прокату или продаже</summary>
        private bool _IsAvailable;

        /// <summary>Доступность товара к прокату или продаже</summary>
        public bool IsAvailable { get => _IsAvailable; set => Set(ref _IsAvailable, value); }

        #endregion

        #region Dto : ProductDto - сформированный dto по введенной информации

        public override ProductDto Dto =>
            new()
            {
                Id = Id,
                Cost = Cost,
                Quantity = Quantity,
                DiscId = DiscId,
                IsAvailable = IsAvailable
            };

        #endregion

        #endregion
    }
}