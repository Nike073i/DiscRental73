using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.Base
{
    public abstract class EntityManagementViewModel : ViewModel
    {
        protected readonly WindowDataFormationService _dialogService;
        protected bool IsLoginUser(object? p) => App.CurrentUser is not null;


        public EntityManagementViewModel(WindowDataFormationService dialogService)
        {
            _dialogService = dialogService;
        }

        #region Items - IEnumerable<object> - набор элементов

        public abstract IEnumerable<object> Items { get; }

        #endregion

        #region SelectedItem - Res - модель выбранного элемента

        private object _SelectedItem;

        public object SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        #endregion

        #region RefreshCommand - обновление списка элементов

        private ICommand _RefreshCommand;

        public ICommand RefreshCommand => _RefreshCommand ??= new LambdaCommand(OnRefreshCommand);

        private void OnRefreshCommand(object? p) => OnPropertyChanged(nameof(Items));

        #endregion
    }
}
