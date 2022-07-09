using DiscRental73TestWpf.ViewModels.Base;
using System.Collections.Generic;
using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class ProductFormationViewModel : FormationViewModel
    {
        #region FormationData ProductDto - модель продукта

        private ProductDto _Product;

        /// <summary>Модель продукта</summary>
        public ProductDto Product
        {
            get => _Product;
            set => Set(ref _Product, value);
        }

        #endregion

        #region Discs IEnumerable - список доступных дисков 

        private IEnumerable<DiscDto> _Discs;

        public IEnumerable<DiscDto> Discs
        {
            get => _Discs;
            set => Set(ref _Discs, value);
        }

        #endregion

        #region Ограничения на ввод данных 

        public int QuantityMaxValue { get; set; }
        public int QuantityMinValue { get; set; }
        public decimal CostMaxValue { get; set; }
        public decimal CostMinValue { get; set; }

        #endregion
    }
}
