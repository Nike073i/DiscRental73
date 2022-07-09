using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System;
using System.Windows;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;

public class ShowDvdDiscStrategy : IShowContentStrategy
{
    #region Ограничения на ввод данных 

    public int TitleMaxLength { get; set; }
    public int TitleMinLength { get; set; }
    public DateTime DateOfReleaseMaxDate { get; set; }
    public DateTime DateOfReleaseMinDate { get; set; }

    public int DirectorMaxLength { get; set; }
    public int DirectorMinLength { get; set; }
    public int InfoMaxLength { get; set; }
    public int InfoMinLength { get; set; }
    public int PlotMaxLength { get; set; }
    public int PlotMinLength { get; set; }

    #endregion

    #region readonly fields

    private readonly EntityFormationWindowViewModel _WindowVm;
    private readonly DvdDiscFormationViewModel _FormationVm;

    #endregion

    #region constructors

    public ShowDvdDiscStrategy(EntityFormationWindowViewModel windowVm, DvdDiscFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно формирования Dvd-диска", "Dvd-диск");
        SetValueRange(_FormationVm);
    }

    #endregion

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not DvdDiscDto item) return false;

        if (item.Id.Equals(0))
            item.DateOfRelease = DateTime.Now;

        _FormationVm.DvdDisc = item;

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() is not true) return false;

        if (string.IsNullOrEmpty(item.Info)) item.Info = null;
        if (string.IsNullOrEmpty(item.Plot)) item.Plot = null;

        formationData = item;
        return true;
    }
    private void SetValueRange(DvdDiscFormationViewModel viewModel)
    {
        viewModel.TitleMaxLength = TitleMaxLength;
        viewModel.TitleMinLength = TitleMinLength;
        viewModel.DateOfReleaseMaxDate = DateOfReleaseMaxDate;
        viewModel.DateOfReleaseMinDate = DateOfReleaseMinDate;
        viewModel.DirectorMaxLength = DirectorMaxLength;
        viewModel.DirectorMinLength = DirectorMinLength;
        viewModel.InfoMaxLength = InfoMaxLength;
        viewModel.InfoMinLength = InfoMinLength;
        viewModel.PlotMaxLength = PlotMaxLength;
        viewModel.PlotMinLength = PlotMinLength;
    }

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
        string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }
}
