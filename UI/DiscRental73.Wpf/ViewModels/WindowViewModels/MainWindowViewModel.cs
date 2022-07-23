using DiscRental73.Wpf.ViewModels.ManagementViewModels;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows.Input;

namespace DiscRental73.Wpf.ViewModels.WindowViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region fields

        private readonly BluRayDiscManagementViewModel _BluRayDiscManagementViewModel;
        private readonly CdDiscManagementViewModel _CdDiscManagementViewModel;
        private readonly DvdDiscManagementViewModel _DvdDiscManagementViewModel;

        #endregion

        #region constructors

        public MainWindowViewModel(BluRayDiscManagementViewModel bluRayManagementViewModel, CdDiscManagementViewModel cdManagementViewModel, DvdDiscManagementViewModel dvdDiscManagementViewModel)
        {
            _BluRayDiscManagementViewModel = bluRayManagementViewModel;
            _CdDiscManagementViewModel = cdManagementViewModel;
            _DvdDiscManagementViewModel = dvdDiscManagementViewModel;
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

        #region ShowBluRayDiscManagementViewCommand : ICommand - команда показа окна управления BluRay-дисками

        private ICommand? _ShowBluRayDiscManagementViewCommand;

        public ICommand ShowBluRayDiscManagementViewCommand => _ShowBluRayDiscManagementViewCommand ??=
            new LambdaCommand(OnExecutedShowBluRayDiscManagementViewCommand);

        private void OnExecutedShowBluRayDiscManagementViewCommand(object? p) => CurrentModel = _BluRayDiscManagementViewModel;

        #endregion

        #region ShowCdDiscManagementViewCommand : ICommand - команда показа окна управления Cd-дисками

        private ICommand? _ShowCdDiscManagementViewCommand;

        public ICommand ShowCdDiscManagementViewCommand => _ShowCdDiscManagementViewCommand ??=
            new LambdaCommand(OnExecutedShowCdDiscManagementViewCommand);

        private void OnExecutedShowCdDiscManagementViewCommand(object? p) => CurrentModel = _CdDiscManagementViewModel;

        #endregion

        #region ShowDvdDiscManagementViewCommand : ICommand - команда показа окна управления Dvd-дисками

        private ICommand? _ShowDvdDiscManagementViewCommand;

        public ICommand ShowDvdDiscManagementViewCommand => _ShowDvdDiscManagementViewCommand ??=
            new LambdaCommand(OnExecutedShowDvdDiscManagementViewCommand);

        private void OnExecutedShowDvdDiscManagementViewCommand(object? p) => CurrentModel = _DvdDiscManagementViewModel;

        #endregion

        #endregion
    }
}