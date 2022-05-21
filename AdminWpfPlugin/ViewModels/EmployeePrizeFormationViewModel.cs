using AdminWpfPlugin.Models;
using DiscRental73TestWpf.ViewModels.Base;

namespace AdminWpfPlugin.ViewModels
{
    public class EmployeePrizeFormationViewModel : FormationViewModel
    {
        #region SetEmployeePrizeModel SetEmployeePrizeModel - модель для изменения премии

        private SetEmployeePrizeModel _SetEmployeePrizeModel;

        /// <summary>модель для изменения премии</summary>
        public SetEmployeePrizeModel SetEmployeePrizeModel
        {
            get => _SetEmployeePrizeModel;
            set => Set(ref _SetEmployeePrizeModel, value);
        }

        #endregion

        #region Ограничения на ввод данных 

        public double PrizeMaxValue { get; set; }
        public double PrizeMinValue { get; set; }

        #endregion
    }
}