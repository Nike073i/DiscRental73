using System.Windows.Input;
using DiscRental73TestWpf.ViewModels.ManagementViewModels;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace DiscRental73TestWpf.ViewModels.WindowViewModels;

public class MainWindowViewModel : ViewModel
{
    #region constructors

    public MainWindowViewModel(CdDiscManagementViewModel cdDiscManagementViewModel,
        DvdDiscManagementViewModel dvdDiscManagementViewModel,
        BluRayDiscManagementViewModel bluRayDiscManagementViewModel,
        ClientManagementViewModel clientManagementViewModel,
        ProductManagementViewModel productManagementViewModel, IssueViewModel issueViewModel)
    {
        _CdDiscManagementViewModel = cdDiscManagementViewModel;
        _DvdDiscManagementViewModel = dvdDiscManagementViewModel;
        _BluRayDiscManagementViewModel = bluRayDiscManagementViewModel;
        _ClientManagementViewModel = clientManagementViewModel;
        _ProductManagementViewModel = productManagementViewModel;
        _IssueViewModel = issueViewModel;

        ShowCdDiscManagementViewCommand = new LambdaCommand(OnShowCdDiscManagementViewCommand, IsLoginUser);
        ShowDvdDiscManagementViewCommand = new LambdaCommand(OnShowDvdDiscManagementViewCommand, IsLoginUser);
        ShowBluRayDiscManagementViewCommand = new LambdaCommand(OnShowBluRayDiscManagementViewCommand, IsLoginUser);
        ShowClientManagementViewCommand = new LambdaCommand(OnShowClientManagementViewCommand, IsLoginUser);
        ShowProductManagementViewCommand = new LambdaCommand(OnShowProductManagementViewCommand, IsLoginUser);
        ShowIssueViewCommand = new LambdaCommand(OnShowIssueViewCommand, IsLoginUser);
    }

    #endregion

    private static bool IsLoginUser(object? p)
    {
        return App.CurrentUser is not null;
    }

    #region readonly fields

    private readonly BluRayDiscManagementViewModel _BluRayDiscManagementViewModel;
    private readonly CdDiscManagementViewModel _CdDiscManagementViewModel;
    private readonly ClientManagementViewModel _ClientManagementViewModel;
    private readonly DvdDiscManagementViewModel _DvdDiscManagementViewModel;
    private readonly IssueViewModel _IssueViewModel;
    private readonly ProductManagementViewModel _ProductManagementViewModel;

    #endregion

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

    #region ShowCdDiscManagementViewCommand - ICommand - команда для вызова менеджера CD-дисков

    public ICommand ShowCdDiscManagementViewCommand { get; }

    private void OnShowCdDiscManagementViewCommand()
    {
        CurrentModel = _CdDiscManagementViewModel;
    }

    #endregion

    #region ShowDvdDiscManagementViewCommand - ICommand - команда для вызова менеджера DVD-дисков

    public ICommand ShowDvdDiscManagementViewCommand { get; }

    private void OnShowDvdDiscManagementViewCommand()
    {
        CurrentModel = _DvdDiscManagementViewModel;
    }

    #endregion

    #region ShowBluRayDiscManagementViewCommand - ICommand - команда для вызова менеджера BluRay-дисков

    public ICommand ShowBluRayDiscManagementViewCommand { get; }

    private void OnShowBluRayDiscManagementViewCommand()
    {
        CurrentModel = _BluRayDiscManagementViewModel;
    }

    #endregion

    #region ShowClientManagementViewCommand - ICommand - команда для вызова менеджера клиентов

    public ICommand ShowClientManagementViewCommand { get; }

    private void OnShowClientManagementViewCommand()
    {
        CurrentModel = _ClientManagementViewModel;
    }

    #endregion

    #region ShowProductManagementViewCommand - ICommand - команда для вызова менеджера продукции

    public ICommand ShowProductManagementViewCommand { get; }

    private void OnShowProductManagementViewCommand()
    {
        CurrentModel = _ProductManagementViewModel;
    }

    #endregion

    #region ShowIssueViewCommand - ICommand - команда для вызова формы оформлений

    public ICommand ShowIssueViewCommand { get; }

    private void OnShowIssueViewCommand()
    {
        CurrentModel = _IssueViewModel;
    }

    #endregion
}