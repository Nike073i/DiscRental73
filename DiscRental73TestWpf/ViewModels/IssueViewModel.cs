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

        public IssueViewModel(WindowDataFormationService dialogService, ClientService clientService, SellService sellService, RentalService rentalService)
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
        }

        #endregion

        #region CancelRentalCommand - команда отмены проката

        private ICommand _CancelRentalCommand;

        public ICommand CancelRentalCommand => _CancelRentalCommand ??= new LambdaCommand(OnCancelRentalCommand);

        private void OnCancelRentalCommand(object? p)
        {
        }

        #endregion

        #region IssueSellCommand - команда оформления продажи

        private ICommand _IssueSellCommand;

        public ICommand IssueSellCommand => _IssueSellCommand ??= new LambdaCommand(OnIssueSellCommand);

        private void OnIssueSellCommand(object? p)
        {
        }

        #endregion

        #region CancelSellCommand - команда отмены продажи

        private ICommand _CancelSellCommand;

        public ICommand CancelSellCommand => _CancelSellCommand ??= new LambdaCommand(OnCancelSellCommand);

        private void OnCancelSellCommand(object? p)
        {
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

        //#region EditItemCommand - редактирование элемента

        //private ICommand _EditItemCommand;

        //public ICommand EditItemCommand => _EditItemCommand ??= new LambdaCommand(OnEditItemCommand, CanEditItemCommand);

        //private bool CanEditItemCommand(object? p) => p is Res;

        //private void OnEditItemCommand(object? p)
        //{
        //    if (!_dialogService.Edit(p)) return;

        //    try
        //    {
        //        var resDto = p as Res;
        //        var reqDto = CreateReqDtoToUpdate(resDto);
        //        _service.Save(reqDto);
        //        _dialogService.ShowInformation("Запись отредактирована", "Успех");
        //        OnPropertyChanged(nameof(Items));
        //    }
        //    catch (Exception ex)
        //    {
        //        _dialogService.ShowWarning(ex.Message, "Ошибка редактирования");
        //    }
        //}

        //#endregion

        //#region CreateNewItemCommand - создание элемента

        //private ICommand _CreateNewItemCommand;

        //public ICommand CreateNewItemCommand => _CreateNewItemCommand ??= new LambdaCommand(OnCreateNewItemCommand);

        //private void OnCreateNewItemCommand(object? p)
        //{
        //    var item = new Res();
        //    if (!_dialogService.Edit(item)) return;
        //    try
        //    {
        //        var reqDto = CreateReqDtoToCreate(item);
        //        _service.Save(reqDto);
        //        _dialogService.ShowInformation("Запись создана", "Успех");
        //        OnPropertyChanged(nameof(Items));

        //    }
        //    catch (Exception ex)
        //    {
        //        _dialogService.ShowWarning(ex.Message, "Ошибка создания");
        //    }
        //}

        //#endregion

        //#region RefreshCommand - обновление списка элементов

        //private ICommand _RefreshCommand;

        //public ICommand RefreshCommand => _RefreshCommand ??= new LambdaCommand(OnRefreshCommand, CanRefreshCommand);

        //private bool CanRefreshCommand(object? p) => _service is not null;

        //private void OnRefreshCommand(object? p) => OnPropertyChanged(nameof(Items));

        //#endregion
    }
}
