using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;

public class ShowProductQuantityStrategy : IShowContentStrategy
{
    #region Ограничения на ввод данных 

    public int QuantityMaxValue { get; set; }
    public int QuantityMinValue { get; set; }

    #endregion

    #region readonly fields

    private readonly EditProductQuantityFormationViewModel _FormationVm;
    private readonly EntityFormationWindowViewModel _WindowVm;

    #endregion

    #region constructors

    public ShowProductQuantityStrategy(EntityFormationWindowViewModel windowVm,
        EditProductQuantityFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно изменения количества продукта");
        SetValueRange(_FormationVm);
    }

    #endregion

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not EditProductQuantityModel item) return false;

        _FormationVm.EditQuantityModel = item;
        _WindowVm.Caption = $"Продукт - {item.DiscTitle}, количество - {item.CurrentQuantity}";

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() != true) return false;

        formationData = item;
        return true;
    }

    private void SetValueRange(EditProductQuantityFormationViewModel viewModel)
    {
        viewModel.QuantityMaxValue = QuantityMaxValue;
        viewModel.QuantityMinValue = QuantityMinValue;
    }

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
        string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }
}
