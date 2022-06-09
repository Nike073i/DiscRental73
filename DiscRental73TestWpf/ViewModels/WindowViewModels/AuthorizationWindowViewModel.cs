using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.Interfaces.Services;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.Base;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.WindowViewModels;

public class AuthorizationWindowViewModel : FormationViewModel
{
    #region constructors

    public AuthorizationWindowViewModel(IEmployeeService service, WindowDataFormationService dialogService)
    {
        _Service = service;
        _DialogService = dialogService;

        AuthorizationCommand = new LambdaCommand(OnAuthorizationCommandExecute, CanAuthorizationCommandExecute);
    }

    #endregion

    #region readonly fiedls

    private readonly WindowDataFormationService _DialogService;
    private readonly IEmployeeService _Service;

    #endregion

    #region Title - string Название окна

    private string _Title = "Авторизация";

    public string Title
    {
        get => _Title;
        set => Set(ref _Title!, value);
    }

    #endregion

    #region ContactNumber - string Номер т.

    private string _ContactNumber = string.Empty;

    public string ContactNumber
    {
        get => _ContactNumber;
        set => Set(ref _ContactNumber!, value);
    }

    #endregion

    #region Password - string пароль

    private string _Password = string.Empty;

    public string Password
    {
        get => _Password;
        set => Set(ref _Password!, value);
    }

    #endregion

    #region AuthorizationCommand - ICommand команда авторизации

    public ICommand AuthorizationCommand { get; }

    private bool CanAuthorizationCommandExecute(object? p)
    {
        return !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ContactNumber);
    }

    private void OnAuthorizationCommandExecute(object? p)
    {
        if (p is not Window window) return;
        try
        {
            var employee = _Service.Authorization(new EmployeeReqDto
            {
                ContactNumber = ContactNumber,
                Password = Password
            });
            if (employee is null)
            {
                _DialogService.ShowError("Ошибка авторизации. Попробуйте снова", "Ошибка");
                return;
            }

            App.CurrentUser = employee;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            window.Close();
        }
        catch (Exception ex)
        {
            _DialogService.ShowError(ex.Message, "Ошибка");
        }
    }

    #endregion
}