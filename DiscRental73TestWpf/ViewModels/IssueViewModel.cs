using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class IssueViewModel : ViewModel
    {
        private readonly WindowDataFormationService _dialogService;

        private readonly SellService _sellService;
        private readonly RentalService _rentalService;
        private readonly ClientService _clientService;

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

        public IssueViewModel(WindowDataFormationService dialogService, SellService sellService, ClientService clientService, RentalService rentalService)
        {
            _sellService = sellService;
            _clientService = clientService;
            _rentalService = rentalService;
            _dialogService = dialogService;
        }

        #region IssueRentalCommand - команда оформления проката

        private ICommand _IssueRentalCommand;

        public ICommand IssueRentalCommand => _IssueRentalCommand ??= new LambdaCommand(OnIssueRentalCommand);

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
                //
                var employeeId = 3;
                //
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

        public ICommand IssueReturnCommand => _IssueReturnCommand ??= new LambdaCommand(OnIssueReturnCommand);

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

        public ICommand CancelRentalCommand => _CancelRentalCommand ??= new LambdaCommand(OnCancelRentalCommand);

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

        public ICommand IssueSellCommand => _IssueSellCommand ??= new LambdaCommand(OnIssueSellCommand);

        private void OnIssueSellCommand(object? p)
        {
            object item = new IssueSellBindingModel();
            var strategy = IssueSellStrategy;
            strategy.Products = _sellService.GetProducts();
            _dialogService.ShowStrategy = strategy;
            if (!_dialogService.ShowContent(ref item)) return;
            try
            {
                //
                var employeeId = 3;
                //
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

        public ICommand CancelSellCommand => _CancelSellCommand ??= new LambdaCommand(OnCancelSellCommand);

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
        }

        #endregion

        #region ShowAdminViewCommand - команда вызова окна администратора

        private ICommand _ShowAdminViewCommand;

        public ICommand ShowAdminViewCommand => _ShowAdminViewCommand ??= new LambdaCommand(OnShowAdminViewCommand);

        private void OnShowAdminViewCommand(object? p)
        {
        }

        #endregion
    }
}
