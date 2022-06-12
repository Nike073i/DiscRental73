using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;

public class ShowCancelRentalStrategy : IShowContentStrategy
{
    #region readonly fields

    private readonly CancelRentalFormationViewModel _FormationVm;
    private readonly EntityFormationWindowViewModel _WindowVm;

    #endregion

    #region constructors

    public ShowCancelRentalStrategy(EntityFormationWindowViewModel windowVm,
        CancelRentalFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно оформления возврата проката", "Возврат");
    }

    #endregion

    public IEnumerable<RentalResDto>? Rentals { get; set; }

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not CancelRentalBindingModel item) return false;

        _FormationVm.Rentals = Rentals ?? Enumerable.Empty<RentalResDto>();
        _FormationVm.CancelRentalBindingModel = item;

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() is not true || IsCompletedData(_FormationVm)) return false;

        item.RentalId = _FormationVm.SelectedRental.Id;
        formationData = item;
        return true;
    }

    private static bool IsCompletedData(in CancelRentalFormationViewModel viewModel)
    {
        return viewModel?.SelectedRental is not null;
    }

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
        string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }
}