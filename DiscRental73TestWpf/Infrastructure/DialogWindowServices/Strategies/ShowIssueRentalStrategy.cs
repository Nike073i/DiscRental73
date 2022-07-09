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
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;

public class ShowIssueRentalStrategy : IShowContentStrategy
{
    #region Ограничения на ввод данных 

    public DateTime DateMaxValue { get; set; }

    public DateTime DateMinValue { get; set; }

    public decimal PledgeSumMaxValue { get; set; }

    public decimal PledgeSumMinValue { get; set; }

    #endregion

    #region readonly fields

    private readonly IssueRentalFormationViewModel _FormationVm;
    private readonly EntityFormationWindowViewModel _WindowVm;

    #endregion

    #region constructors

    public ShowIssueRentalStrategy(EntityFormationWindowViewModel windowVm,
        IssueRentalFormationViewModel formationVm)
    {
        _WindowVm = windowVm;
        _FormationVm = formationVm;
        InitializeWindow(_FormationVm, "Окно оформления проката", "Прокат");
        SetValueRange(_FormationVm);
    }

    #endregion

    public IEnumerable<ProductDto>? Products { get; set; }
    public IEnumerable<ClientDto>? Clients { get; set; }

    public bool ShowDialog(ref object formationData)
    {
        if (formationData is not IssueRentalBindingModel item) return false;

        //item.DateOfIssue = DateTime.Now;
        //item.DateOfReturn = DateTime.Now.AddDays(7);

        _FormationVm.Products = Products ?? Enumerable.Empty<ProductDto>();
        _FormationVm.Clients = Clients ?? Enumerable.Empty<ClientDto>();
        _FormationVm.IssueRentalBindingModel = item;

        var dlg = new EntityFormationWindow
        {
            DataContext = _WindowVm,
            //Owner = ActiveWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        if (dlg.ShowDialog() is not true || !IsCompletedData(_FormationVm)) return false;

        item.ProductId = _FormationVm.SelectedProduct.Id;
        item.ClientId = _FormationVm.SelectedClient.Id;
        formationData = item;
        return true;
    }

    private bool IsCompletedData(IssueRentalFormationViewModel viewModel) =>
        viewModel?.SelectedProduct is not null && viewModel?.SelectedClient is not null;

    private void SetValueRange(IssueRentalFormationViewModel viewModel)
    {
        viewModel.DateMaxValue = DateMaxValue;
        viewModel.DateMinValue = DateMinValue;
        viewModel.PledgeSumMaxValue = PledgeSumMaxValue;
        viewModel.PledgeSumMinValue = PledgeSumMinValue;
    }

    private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
    string caption = "Формирование записи")
    {
        _WindowVm.CurrentModel = viewModel;
        _WindowVm.Title = title;
        _WindowVm.Caption = caption;
    }
}
