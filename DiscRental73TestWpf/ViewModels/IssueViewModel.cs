using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.Infrastructure.Plugins;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class IssueViewModel : ViewModel
    {
        private readonly WindowDataFormationService _dialogService;

        private readonly SellService _sellService;
        private readonly RentalService _rentalService;
        private readonly ClientService _clientService;
        private readonly EmployeeService _employeeService;

        private ShowIssueRentalStrategy _IssueRentalStrategy;
        public ShowIssueRentalStrategy IssueRentalStrategy => _IssueRentalStrategy ??= new ShowIssueRentalStrategy();

        private ShowIssueReturnStrategy _IssueReturnStrategy;
        public ShowIssueReturnStrategy IssueReturnStrategy => _IssueReturnStrategy ??= new ShowIssueReturnStrategy();

        private ShowCancelRentalStrategy _CancelRentalStrategy;
        public ShowCancelRentalStrategy CancelRentalStrategy => _CancelRentalStrategy ??= new ShowCancelRentalStrategy();

        private ShowIssueSellStrategy _IssueSellStrategy;
        public ShowIssueSellStrategy IssueSellStrategy => _IssueSellStrategy ??= new ShowIssueSellStrategy();

        private ShowCancelSellStrategy _CancelSellStrategy;
        public ShowCancelSellStrategy CancelSellStrategy => _CancelSellStrategy ??= new ShowCancelSellStrategy();

        public IssueViewModel(WindowDataFormationService dialogService, SellService sellService, ClientService clientService, RentalService rentalService, EmployeeService employeeService)
        {
            _sellService = sellService;
            _clientService = clientService;
            _rentalService = rentalService;
            _dialogService = dialogService;
            _employeeService = employeeService;
        }

        #region IssueRentalCommand - команда оформления проката

        private ICommand _IssueRentalCommand;

        public ICommand IssueRentalCommand => _IssueRentalCommand ??= new LambdaCommand(OnIssueRentalCommand, IsLoginUser);

        private void OnIssueRentalCommand(object? p)
        {
            object item = new IssueRentalBindingModel();
            var strategy = IssueRentalStrategy;
            strategy.Clients = _clientService.GetAll();
            strategy.Products = _rentalService.GetProducts();
            _dialogService.ShowStrategy = strategy;
            if (!_dialogService.ShowContent(ref item)) return;
            try
            {
                var employeeId = App.CurrentUser.Id;

                var model = item as IssueRentalBindingModel;
                _rentalService.IssueRental(new RentalReqDto
                {
                    ProductId = model.ProductId,
                    ClientId = model.ClientId,
                    EmployeeId = employeeId,
                    DateOfIssue = model.DateOfIssue,
                    DateOfRental = model.DateOfReturn,
                    PledgeSum = model.PledgeSum
                });
                _dialogService.ShowInformation("Прокат создан", "Успех");
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка создания");
            }
        }

        #endregion

        #region IssueReturnCommand - команда оформления возврата

        private ICommand _IssueReturnCommand;

        public ICommand IssueReturnCommand => _IssueReturnCommand ??= new LambdaCommand(OnIssueReturnCommand, IsLoginUser);

        private void OnIssueReturnCommand(object? p)
        {
            object item = new IssueReturnBindingModel();
            var strategy = IssueReturnStrategy;
            strategy.Rentals = _rentalService.GetInRental();
            _dialogService.ShowStrategy = strategy;
            if (!_dialogService.ShowContent(ref item)) return;
            try
            {
                var model = item as IssueReturnBindingModel;
                _rentalService.IssueReturn(new IssueReturnReqDto
                {
                    RentalId = model.RentalId,
                    ReturnSum = model.ReturnSum
                });
                _dialogService.ShowInformation("Прокат возвращен", "Успех");
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка возврата");
            }
        }

        #endregion

        #region CancelRentalCommand - команда отмены проката

        private ICommand _CancelRentalCommand;

        public ICommand CancelRentalCommand => _CancelRentalCommand ??= new LambdaCommand(OnCancelRentalCommand, IsLoginUser);

        private void OnCancelRentalCommand(object? p)
        {
            object item = new CancelRentalBindingModel();
            var strategy = CancelRentalStrategy;
            strategy.Rentals = _rentalService.GetInRental();
            _dialogService.ShowStrategy = strategy;
            if (!_dialogService.ShowContent(ref item)) return;
            if (!_dialogService.Confirm("Вы уверены в отмене проката без возможности восстановления?", "Подтверждение отмены")) return;
            try
            {
                var model = item as CancelRentalBindingModel;
                _rentalService.CancelRental(new RentalReqDto
                {
                    Id = model.RentalId,
                });
                _dialogService.ShowInformation("Прокат отменен", "Успех");
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка отмены");
            }
        }

        #endregion

        #region IssueSellCommand - команда оформления продажи

        private ICommand _IssueSellCommand;

        public ICommand IssueSellCommand => _IssueSellCommand ??= new LambdaCommand(OnIssueSellCommand, IsLoginUser);

        private void OnIssueSellCommand(object? p)
        {
            object item = new IssueSellBindingModel();
            var strategy = IssueSellStrategy;
            strategy.Products = _sellService.GetProducts();
            _dialogService.ShowStrategy = strategy;
            if (!_dialogService.ShowContent(ref item)) return;
            try
            {
                var employeeId = App.CurrentUser.Id;
                var model = item as IssueSellBindingModel;
                _sellService.SellProduct(new SellReqDto()
                {
                    ProductId = model.ProductId,
                    EmployeeId = employeeId,
                    DateOfSell = model.DateOfSell,
                    Price = model.Price
                });
                _dialogService.ShowInformation("Продажа создана", "Успех");
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка создания");
            }
        }

        #endregion

        #region CancelSellCommand - команда отмены продажи

        private ICommand _CancelSellCommand;

        public ICommand CancelSellCommand => _CancelSellCommand ??= new LambdaCommand(OnCancelSellCommand, IsLoginUser);

        private void OnCancelSellCommand(object? p)
        {
            object item = new CancelSellBindingModel();
            var strategy = CancelSellStrategy;
            strategy.Sells = _sellService.GetAll();
            _dialogService.ShowStrategy = strategy;
            if (!_dialogService.ShowContent(ref item)) return;
            if (!_dialogService.Confirm("Вы уверены в отмене продажи без возможности восстановления?", "Подтверждение отмены")) return;
            try
            {
                var model = item as CancelSellBindingModel;
                _sellService.CancelSell(new SellReqDto
                {
                    Id = model.SellId,
                });
                _dialogService.ShowInformation("Продажа отменена", "Успех");
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка отмены");
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
            plugin.RegisterService(_rentalService, _employeeService, _sellService);
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
}
