using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class IssueReturnFormationViewModel : FormationViewModel
    {
        #region IssueReturnBindingModel IssueReturnBindingModel - модель возврата проката

        private IssueReturnBindingModel _IssueReturnBindingModel;

        /// <summary>Модель возврата проката</summary>
        public IssueReturnBindingModel IssueReturnBindingModel
        {
            get => _IssueReturnBindingModel;
            set => Set(ref _IssueReturnBindingModel, value);
        }

        #endregion
    }
}
