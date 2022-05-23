using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.Base;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.WindowViewModels
{
    public class AuthorizationWindowViewModel : FormationViewModel
    {
        private readonly EmployeeService _service;
        private readonly WindowDataFormationService _dialogService;

        public AuthorizationWindowViewModel(EmployeeService service, WindowDataFormationService dialogService)
        {
            _service = service;
            _dialogService = dialogService;
        }

        #region Title - string Название окна

        private string _Title = "Авторизация";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region ContactNumber - string Номер т.

        private string _ContactNumber;

        public string ContactNumber
        {
            get => _ContactNumber;
            set => Set(ref _ContactNumber, value);
        }

        #endregion

        #region Password - string пароль

        private string _Password;

        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }

        #endregion

        #region AuthorizationCommand - ICommand команда авторизации

        private ICommand _AuthorizationCommand;

        public ICommand AuthorizationCommand => _AuthorizationCommand ??= new LambdaCommand(OnAuthorizationCommandExecute, CanAuthorizationCommandExecute);

        private bool CanAuthorizationCommandExecute(object? p) =>
            !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ContactNumber);

        private void OnAuthorizationCommandExecute(object? p)
        {
            if (p is not Window window) return;
            try
            {
                var employee = _service.Authorization(new EmployeeReqDto
                {
                    ContactNumber = ContactNumber,
                    Password = Password
                });
                if (employee is null)
                {
                    _dialogService.ShowError("Ошибка авторизации. Попробуйте снова","Ошибка");
                    return;
                }
                App.CurrentUser = employee;
                var mainWindow = new MainWindow();
                mainWindow.Show();
                window.Close();
            }
            catch (Exception ex)
            {
                _dialogService.ShowError(ex.Message, "Ошибка");
            }
        }

        #endregion
    }
}
