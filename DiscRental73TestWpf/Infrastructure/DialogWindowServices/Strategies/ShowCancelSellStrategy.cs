using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;

public class ShowCancelSellStrategy : IShowContentStrategy
{
    #region readonly fields

    private readonly EntityFormationWindowViewModel _WindowVm;
    private readonly CancelSellFormationViewModel _FormationVm;

    #endregion

    #region constructors

    public ShowCancelSellStrategy(EntityFormationWindowViewModel windowVm,
        CancelSellFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно оформления отмены продажи", "Отмена продажи");
    }

    #endregion

    public IEnumerable<SellResDto>? Sells { get; set; }

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not CancelSellBindingModel item) return false;

        _FormationVm.Sells = Sells ?? Enumerable.Empty<SellResDto>();
        _FormationVm.DateOfSell = DateTime.Now;
        _FormationVm.CancelSellBindingModel = item;

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() is not true || !IsCompletedData(_FormationVm)) return false;

        item.SellId = _FormationVm.SelectedSell.Id;
        formationData = item;

        return true;
    }

    private bool IsCompletedData(CancelSellFormationViewModel viewModel) => viewModel?.SelectedSell is not null;

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
        string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }
}
