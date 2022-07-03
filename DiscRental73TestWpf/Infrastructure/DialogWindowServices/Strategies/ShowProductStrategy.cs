using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;

public class ShowProductStrategy : IShowContentStrategy
{
    #region Ограничения на ввод данных 

    public int QuantityMaxValue { get; set; }
    public int QuantityMinValue { get; set; }
    public decimal CostMaxValue { get; set; }
    public decimal CostMinValue { get; set; }

    #endregion

    #region readonly fields

    private readonly ProductFormationViewModel _FormationVm;
    private readonly EntityFormationWindowViewModel _WindowVm;

    #endregion

    #region constructors

    public ShowProductStrategy(EntityFormationWindowViewModel windowVm,
        ProductFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно создания продукта", "Продукт");
        SetValueRange(_FormationVm);
    }

    #endregion

    public IEnumerable<DiscResDto>? Discs { get; set; }

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not ProductResDto item) return false;

        if (item.Id.Equals(0)) item.IsAvailable = true;

        _FormationVm.Product = item;
        _FormationVm.Discs = Discs ?? Enumerable.Empty<DiscResDto>();

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() is not true || !IsCompletedData(_FormationVm)) return false;

        formationData = item;
        return true;
    }

    private bool IsCompletedData(ProductFormationViewModel viewModel) => viewModel?.Product is not null;

    private void SetValueRange(ProductFormationViewModel viewModel)
    {
        viewModel.QuantityMaxValue = QuantityMaxValue;
        viewModel.QuantityMinValue = QuantityMinValue;
        viewModel.CostMaxValue = CostMaxValue;
        viewModel.CostMinValue = CostMinValue;
    }

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
        string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }
}