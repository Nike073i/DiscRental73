using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels.Base;
using System.Collections.Generic;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class ProductFormationViewModel : FormationViewModel
    {
        #region FormationData ProductResDto - модель продукта

        private ProductResDto _Product;

        /// <summary>Модель продукта</summary>
        public ProductResDto Product
        {
            get => _Product;
            set => Set(ref _Product, value);
        }

        #endregion

        #region Discs IEnumerable - список доступных дисков 

        private IEnumerable<DiscResDto> _Discs;

        public IEnumerable<DiscResDto> Discs
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
