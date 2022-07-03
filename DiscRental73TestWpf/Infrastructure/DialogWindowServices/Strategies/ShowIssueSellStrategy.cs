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

public class ShowIssueSellStrategy : IShowContentStrategy
{
    #region Ограничения для сущности Sell

    public DateTime DateMaxValue { get; set; }

    public DateTime DateMinValue { get; set; }

    #endregion

    #region readonly fields

    private readonly IssueSellFormationViewModel _FormationVm;
    private readonly EntityFormationWindowViewModel _WindowVm;

    #endregion

    #region constructors

    public ShowIssueSellStrategy(EntityFormationWindowViewModel windowVm,
        IssueSellFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно оформления продажи", "Продажа");
        SetValueRange(_FormationVm);
    }

    #endregion

    public IEnumerable<ProductResDto>? Products { get; set; }

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not IssueSellBindingModel item) return false;

        item.DateOfSell = DateTime.Now;

        _FormationVm.Products = Products ?? Enumerable.Empty<ProductResDto>();
        _FormationVm.IssueSellBindingModel = item;

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() is not true || !IsCompletedData(_FormationVm)) return false;

        item.ProductId = _FormationVm.SelectedProduct.Id;
        item.Price = _FormationVm.SelectedProduct.Cost;
        formationData = item;
        return true;
    }

    private bool IsCompletedData(IssueSellFormationViewModel viewModel) => viewModel?.SelectedProduct is not null;

    private void SetValueRange(IssueSellFormationViewModel viewModel)
    {
        viewModel.DateMaxValue = DateMaxValue;
        viewModel.DateMinValue = DateMinValue;
    }

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
        string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }
}