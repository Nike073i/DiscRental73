using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using System.Collections.Generic;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowCancelRentalStrategy : IShowContentStrategy
    {
        private readonly EntityFormationWindowViewModel _WindowVm;
        private readonly CancelRentalFormationViewModel _FormationVm;
        private bool IsConfirmed { get; set; } = false;

        public ShowCancelRentalStrategy(EntityFormationWindowViewModel windowVm, CancelRentalFormationViewModel formationVm)
        {
            _WindowVm = windowVm;
            _FormationVm = formationVm;
        }

        public IEnumerable<RentalResDto>? Rentals { get; set; }

        public void SetData(ref object formationData)
        {
            if (formationData is not CancelRentalBindingModel item) return;

            _FormationVm.Rentals = Rentals ?? new List<RentalResDto>();
            _FormationVm.CancelRentalBindingModel = item;

            _WindowVm.CurrentModel = _FormationVm;
            _WindowVm.Title = "Окно оформления возврата проката";
            _WindowVm.Caption = "Возврат";
        }

        public bool ShowDialog()
        {
            var dlg = new EntityFormationWindow
            {
                DataContext = _WindowVm,
                //Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            IsConfirmed = dlg.ShowDialog() ?? false;
            return IsConfirmed;
        }

        public object? GetData()
        {
            if (!IsConfirmed) return null;
            if (!IsCompletedData(in _FormationVm)) return null;

            var inputData = _FormationVm.CancelRentalBindingModel;
            inputData.RentalId = _FormationVm.SelectedRental.Id;

            return inputData;
        }

        private static bool IsCompletedData(in CancelRentalFormationViewModel viewModel)
        {
            if (viewModel.SelectedRental is null) return false;

            return true;
        }
    }
}
