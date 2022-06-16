using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces.Services;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.Infrastructure.Plugins;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels;

public class IssueViewModel : ViewModel
{
    #region readonly fields

    private readonly IFormationService _DialogService;
    private readonly ISellService _SellService;
    private readonly IRentalService _RentalService;
    private readonly IClientService _ClientService;
    private readonly IEmployeeService _EmployeeService;

    private readonly ShowIssueRentalStrategy _IssueRentalStrategy;
    private readonly ShowIssueReturnStrategy _IssueReturnStrategy;
    private readonly ShowCancelRentalStrategy _CancelRentalStrategy;
    private readonly ShowIssueSellStrategy _IssueSellStrategy;
    private readonly ShowCancelSellStrategy _CancelSellStrategy;

    #endregion

    public IssueViewModel(IFormationService dialogService,
        ISellService sellService,
        IClientService clientService,
        IRentalService rentalService,
        IEmployeeService employeeService,
        EntityFormationWindowViewModel windowVm,
        CancelRentalFormationViewModel cancelRentalFormationVm,
        CancelSellFormationViewModel cancelSellFormationVm,
        IssueRentalFormationViewModel issueRentalFormationVm,
        IssueReturnFormationViewModel issueReturnFormationVm,
        IssueSellFormationViewModel issueSellFormationVm)
    {
        _SellService = sellService;
        _ClientService = clientService;
        _RentalService = rentalService;
        _DialogService = dialogService;
        _EmployeeService = employeeService;

        _CancelRentalStrategy = new ShowCancelRentalStrategy(windowVm, cancelRentalFormationVm);
        _CancelSellStrategy = new ShowCancelSellStrategy(windowVm, cancelSellFormationVm);
        _IssueRentalStrategy = new ShowIssueRentalStrategy(windowVm, issueRentalFormationVm);
        _IssueReturnStrategy = new ShowIssueReturnStrategy(windowVm, issueReturnFormationVm);
        _IssueSellStrategy = new ShowIssueSellStrategy(windowVm, issueSellFormationVm);
    }

    #region IssueRentalCommand - команда оформления проката

    private ICommand _IssueRentalCommand;

    public ICommand IssueRentalCommand => _IssueRentalCommand ??= new LambdaCommand(OnIssueRentalCommand, IsLoginUser);

    private void OnIssueRentalCommand(object? p)
    {
        object item = new IssueRentalBindingModel();
        var strategy = _IssueRentalStrategy;
        strategy.Clients = _ClientService.GetAll();
        strategy.Products = _RentalService.GetProducts();
        if (!_DialogService.ShowContent(ref item, strategy)) return;
        try
        {
            var employeeId = App.CurrentUser.Id;

            var model = item as IssueRentalBindingModel;
            _RentalService.IssueRental(new RentalReqDto
            {
                ProductId = model.ProductId,
                ClientId = model.ClientId,
                EmployeeId = employeeId,
                DateOfIssue = model.DateOfIssue,
                DateOfRental = model.DateOfReturn,
                PledgeSum = model.PledgeSum
            });
            _DialogService.ShowInformation("Прокат создан", "Успех");
        }
        catch (Exception ex)
        {
            _DialogService.ShowWarning(ex.Message, "Ошибка создания");
        }
    }

    #endregion

    #region IssueReturnCommand - команда оформления возврата

    private ICommand _IssueReturnCommand;

    public ICommand IssueReturnCommand => _IssueReturnCommand ??= new LambdaCommand(OnIssueReturnCommand, IsLoginUser);

    private void OnIssueReturnCommand(object? p)
    {
        object item = new IssueReturnBindingModel();
        var strategy = _IssueReturnStrategy;
        strategy.Rentals = _RentalService.GetInRental();
        if (!_DialogService.ShowContent(ref item, strategy)) return;
        try
        {
            var model = item as IssueReturnBindingModel;
            _RentalService.IssueReturn(new IssueReturnReqDto
            {
                RentalId = model.RentalId,
                ReturnSum = model.ReturnSum
            });
            _DialogService.ShowInformation("Прокат возвращен", "Успех");
        }
        catch (Exception ex)
        {
            _DialogService.ShowWarning(ex.Message, "Ошибка возврата");
        }
    }

    #endregion

    #region CancelRentalCommand - команда отмены проката

    private ICommand _CancelRentalCommand;

    public ICommand CancelRentalCommand => _CancelRentalCommand ??= new LambdaCommand(OnCancelRentalCommand, IsLoginUser);

    private void OnCancelRentalCommand(object? p)
    {
        object item = new CancelRentalBindingModel();
        var strategy = _CancelRentalStrategy;
        strategy.Rentals = _RentalService.GetInRental();
        if (!_DialogService.ShowContent(ref item, strategy)) return;
        if (!_DialogService.Confirm("Вы уверены в отмене проката без возможности восстановления?", "Подтверждение отмены")) return;
        try
        {
            var model = item as CancelRentalBindingModel;
            _RentalService.CancelRental(new RentalReqDto
            {
                Id = model.RentalId,
            });
            _DialogService.ShowInformation("Прокат отменен", "Успех");
        }
        catch (Exception ex)
        {
            _DialogService.ShowWarning(ex.Message, "Ошибка отмены");
        }
    }

    #endregion

    #region IssueSellCommand - команда оформления продажи

    private ICommand _IssueSellCommand;

    public ICommand IssueSellCommand => _IssueSellCommand ??= new LambdaCommand(OnIssueSellCommand, IsLoginUser);

    private void OnIssueSellCommand(object? p)
    {
        object item = new IssueSellBindingModel();
        var strategy = _IssueSellStrategy;
        strategy.Products = _SellService.GetProducts();
        if (!_DialogService.ShowContent(ref item, strategy)) return;
        try
        {
            var employeeId = App.CurrentUser.Id;
            var model = item as IssueSellBindingModel;
            _SellService.SellProduct(new SellReqDto()
            {
                ProductId = model.ProductId,
                EmployeeId = employeeId,
                DateOfSell = model.DateOfSell,
                Price = model.Price
            });
            _DialogService.ShowInformation("Продажа создана", "Успех");
        }
        catch (Exception ex)
        {
            _DialogService.ShowWarning(ex.Message, "Ошибка создания");
        }
    }

    #endregion

    #region CancelSellCommand - команда отмены продажи

    private ICommand _CancelSellCommand;

    public ICommand CancelSellCommand => _CancelSellCommand ??= new LambdaCommand(OnCancelSellCommand, IsLoginUser);

    private void OnCancelSellCommand(object? p)
    {
        object item = new CancelSellBindingModel();
        _CancelSellStrategy.Sells = _SellService.GetAll();
        if (!_DialogService.ShowContent(ref item, _CancelSellStrategy)) return;
        if (!_DialogService.Confirm("Вы уверены в отмене продажи без возможности восстановления?", "Подтверждение отмены")) return;
        try
        {
            var model = item as CancelSellBindingModel;
            _SellService.CancelSell(new SellReqDto
            {
                Id = model.SellId,
            });
            _DialogService.ShowInformation("Продажа отменена", "Успех");
        }
        catch (Exception ex)
        {
            _DialogService.ShowWarning(ex.Message, "Ошибка отмены");
        }
    }

    #endregion

    #region ExitCommand - команда выхода из текущего пользователя

    private ICommand _ExitCommand;

    public ICommand ExitCommand => _ExitCommand ??= new LambdaCommand(OnExitCommand);

    private void OnExitCommand(object? p)
    {
        if (p is not Window window) return;
        if (IsLoginUser(null)) App.CurrentUser = null;
        var authWindow = new AuthorizationWindow();
        authWindow.Show();
        window.Close();
    }

    #endregion

    #region ShowAdminViewCommand - команда вызова окна администратора

    private ICommand _ShowAdminViewCommand;

    public ICommand ShowAdminViewCommand => _ShowAdminViewCommand ??= new LambdaCommand(OnShowAdminViewCommand, CanShowAdminViewCommandExecute);


    private bool CanShowAdminViewCommandExecute(object? p) => IsAdminUser;

    private void OnShowAdminViewCommand(object? p)
    {
        var manager = App.Host.Services.GetRequiredService<AdminPluginManager>();
        if (manager.AdminPlugin is null) return;
        var plugin = manager.AdminPlugin;
        plugin.RegisterService(_RentalService, _EmployeeService, _SellService);
        plugin.ShowAdminView();
    }

    #endregion

    #region IsAdminUser bool - бит прав администратора

    private bool _IsAdminUser = false;
    public bool IsAdminUser
    {
        get => _IsAdminUser;
        set => Set(ref _IsAdminUser, value);
    }

    #endregion

    #region IsAdminUserCommand - команда проверки прав администратора

    private ICommand _IsAdminUserCommand;

    public ICommand IsAdminUserCommand => _IsAdminUserCommand ??= new LambdaCommand(OnIsAdminUserCommandExecute, IsLoginUser);

    private void OnIsAdminUserCommandExecute(object? p)
    {
        var employee = App.CurrentUser;
        if (employee.Position.Equals(UserPosition.Administrator)) IsAdminUser = true;
    }

    #endregion

    protected bool IsLoginUser(object? p) => App.CurrentUser is not null;
}
