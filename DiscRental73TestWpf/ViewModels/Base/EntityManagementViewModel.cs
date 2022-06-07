using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.Base;

public abstract class EntityManagementViewModel : ViewModel
{
    protected readonly WindowDataFormationService DialogService;
    protected EntityManagementViewModel(WindowDataFormationService dialogService)
    {
        DialogService = dialogService;
        //_FilteredItems = new CollectionViewSource();
        //_FilteredItems.Filter += OnItemsFiltered;
        RefreshCommand = new LambdaCommand(OnRefreshCommand);
    }

    #region Items - IEnumerable<object> - набор элементов

    private IEnumerable<object> _Items;

    public IEnumerable<object> Items
    {
        get => _Items;
        set => Set(ref _Items, value);
    }

    #endregion

    //#region string SearchedFilter - Текст фильтрации

    /////<summary>Текст фильтрации</summary>
    //private string _SearchedFilter;

    /////<summary>Текст фильтрации</summary>
    //public string SearchedFilter
    //{
    //    get => _SearchedFilter;
    //    set
    //    {
    //        if (!Set(ref _SearchedFilter, value)) return;
    //        FilteredItems?.Refresh();
    //    }
    //}

    //#endregion

    //#region ICollectionView FilteredItems - Элементы, проходящие фильтр

    /////<summary>Элементы, проходящие фильтр</summary>
    //protected CollectionViewSource _FilteredItems;

    /////<summary>Элементы, проходящие фильтр</summary>
    //public ICollectionView FilteredItems => _FilteredItems?.View;

    //protected abstract void OnItemsFiltered(object sender, FilterEventArgs E);

    //#endregion

    #region SelectedItem - object - модель выбранного элемента

    private object _SelectedItem;

    public object SelectedItem
    {
        get => _SelectedItem;
        set => Set(ref _SelectedItem, value);
    }

    #endregion

    #region RefreshCommand - обновление списка элементов

    public ICommand RefreshCommand { get; }

    protected abstract void OnRefreshCommand(object? p);

    #endregion

    protected bool IsLoginUser(object? p)
    {
        return App.CurrentUser is not null;
    }
}