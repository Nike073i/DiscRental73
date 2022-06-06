using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
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
            _FilteredItems = new CollectionViewSource();
            _FilteredItems.Filter += OnItemsFiltered;
        }

        #region string SearchedFilter - Текст фильтрации

        ///<summary>Текст фильтрации</summary>
        private string _SearchedFilter;

        ///<summary>Текст фильтрации</summary>
        public string SearchedFilter
        {
            get => _SearchedFilter;
            set
            {
                if (!Set(ref _SearchedFilter, value)) return;
                _FilteredItems.View.Refresh();
            }
        }

        #endregion

        #region ICollectionView FilteredItems - Элементы, проходящие фильтр

        ///<summary>Элементы, проходящие фильтр</summary>
        protected CollectionViewSource _FilteredItems;

        ///<summary>Элементы, проходящие фильтр</summary>
        public ICollectionView FilteredItems => _FilteredItems?.View;

        protected abstract void OnItemsFiltered(object sender, FilterEventArgs E);

        #endregion

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
