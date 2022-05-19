using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class EditProductQuantityFormationViewModel : FormationViewModel
    {
        #region Ограничения на ввод данных 

        public int QuantityMaxValue { get; set; }
        public int QuantityMinValue { get; set; }

        #endregion

        #region EditProductQuantityModel EditQuantityModel - модель для изменения количества

        private EditProductQuantityModel _EditQuantityModel;

        /// <summary>Изменяемое количество продукта</summary>
        public EditProductQuantityModel EditQuantityModel
        {
            get => _EditQuantityModel;
            set => Set(ref _EditQuantityModel, value);
        }

        #endregion
    }
}
