using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;

public class ShowCdDiscStrategy : IShowContentStrategy
{
    #region Ограничения на ввод данных 

    public int TitleMaxLength { get; set; }
    public int TitleMinLength { get; set; }
    public DateTime DateOfReleaseMaxDate { get; set; }
    public DateTime DateOfReleaseMinDate { get; set; }

    public int PerformerMaxLength { get; set; }
    public int PerformerMinLength { get; set; }
    public int GenreMaxLength { get; set; }
    public int GenreMinLength { get; set; }
    public int NumberOfTracksMaxValue { get; set; }
    public int NumberOfTracksMinValue { get; set; }

    #endregion

    #region readonly fields

    private readonly EntityFormationWindowViewModel _WindowVm;
    private readonly CdDiscFormationViewModel _FormationVm;

    #endregion

    #region constructors

    public ShowCdDiscStrategy(EntityFormationWindowViewModel windowVm, CdDiscFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно формирования Cd-диска", "Cd-диск");
        SetValueRange(_FormationVm);
    }

    #endregion

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not CdDiscResDto item) return false;

        if (item.Id.Equals(0))
            item.DateOfRelease = DateTime.Now;

        _FormationVm.CdDisc = item;

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() is not true) return false;

        if (string.IsNullOrEmpty(item.Genre)) item.Genre = null;

        formationData = item;
        return true;
    }

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
        string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }

    private void SetValueRange(CdDiscFormationViewModel viewModel)
    {
        viewModel.TitleMaxLength = TitleMaxLength;
        viewModel.TitleMinLength = TitleMinLength;
        viewModel.DateOfReleaseMaxDate = DateOfReleaseMaxDate;
        viewModel.DateOfReleaseMinDate = DateOfReleaseMinDate;

        viewModel.PerformerMaxLength = PerformerMaxLength;
        viewModel.PerformerMinLength = PerformerMinLength;
        viewModel.GenreMaxLength = GenreMaxLength;
        viewModel.GenreMinLength = GenreMinLength;
        viewModel.NumberOfTracksMaxValue = NumberOfTracksMaxValue;
        viewModel.NumberOfTracksMinValue = NumberOfTracksMinValue;
    }
}
