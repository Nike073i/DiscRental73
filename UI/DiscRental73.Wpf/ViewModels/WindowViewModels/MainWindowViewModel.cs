using DiscRental73.Wpf.ViewModels.ManagementViewModels;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

namespace DiscRental73.Wpf.ViewModels.WindowViewModels;

public class MainWindowViewModel : ViewModel
{
    #region fields

    private readonly BluRayDiscManagementViewModel _BluRayManagementViewModel;

    #endregion

    #region constructors

    public MainWindowViewModel(BluRayDiscManagementViewModel bluRayManagementViewModel)
    {
        _BluRayManagementViewModel = bluRayManagementViewModel;
    }

    #endregion

    #region properties

    #region CurrentModel - ViewModel Текущее представление

    private ViewModel? _CurrentModel;

    public ViewModel? CurrentModel
    {
        get => _CurrentModel;
        private set => Set(ref _CurrentModel, value);
    }

    #endregion

    #region Title - string Название окна

    private string _Title = "Прокат дисков 73";

    public string Title
    {
        get => _Title;
        set => Set(ref _Title!, value);
    }

    #endregion

    #endregion

    #region commands

    #region ShowBluRayManagementViewCommand : ICommand - команда показа окна управления BluRay-дисками

    private ICommand? _ShowBluRayManagementViewCommand;

    public ICommand ShowBluRayManagementViewCommand => _ShowBluRayManagementViewCommand ??=
        new LambdaCommand(OnExecutedShowBluRayManagementViewCommand);

    private void OnExecutedShowBluRayManagementViewCommand(object? p) => CurrentModel = _BluRayManagementViewModel;

    #endregion

    #endregion
}