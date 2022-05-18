using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;
using System.Collections.Generic;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class IssueRentalFormationViewModel : FormationViewModel
    {
        #region IssueRentalBindingModel IssueRentalBindingModel - модель оформления проката

        private IssueRentalBindingModel _IssueRentalBindingModel;

        /// <summary>Модель оформления проката</summary>
        public IssueRentalBindingModel IssueRentalBindingModel
        {
            get => _IssueRentalBindingModel;
            set => Set(ref _IssueRentalBindingModel, value);
        }

        #endregion

        #region Products IEnumerable - список доступных продуктов 

        private IEnumerable<ProductResDto> _Products;

        public IEnumerable<ProductResDto> Products
        {
            get => _Products;
            set => Set(ref _Products, value);
        }

        #endregion

        #region Clients IEnumerable - список клиентов

        private IEnumerable<ClientResDto> _Clients;

        public IEnumerable<ClientResDto> Clients
        {
            get => _Clients;
            set => Set(ref _Clients, value);
        }

        #endregion
    }
}
