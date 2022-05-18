using BusinessLogic.BusinessLogics;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class IssueViewModel : ViewModel
    {
        private readonly SellService _sellService;
        private readonly RentalService _rentalService;

        public IssueViewModel(SellService sellService, RentalService rentalService)
        {
            _sellService = sellService;
            _rentalService = rentalService;
        }

        #region IssueRentalCommand - команда оформления проката

        private ICommand _IssueRentalCommand;

        public ICommand IssueRentalCommand => _IssueRentalCommand ??= new LambdaCommand(OnIssueRentalCommand);

        private void OnIssueRentalCommand(object? p)
        {
            //if (!_dialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
            //try
            //{
            //    var resDto = p as Res;
            //    var reqDto = CreateReqDtoToDelete(resDto);
            //    _service.DeleteById(reqDto);
            //    _dialogService.ShowInformation("Запись удалена", "Успех");
            //    OnPropertyChanged(nameof(Items));
            //}
            //catch (Exception ex)
            //{
            //    _dialogService.ShowWarning(ex.Message, "Ошибка удаления");
            //}
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
