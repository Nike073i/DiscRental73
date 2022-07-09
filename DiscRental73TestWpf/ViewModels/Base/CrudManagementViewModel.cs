using DiscRental73.Domain.DtoModels.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.Interfaces;

namespace DiscRental73TestWpf.ViewModels.Base;

public abstract class CrudManagementViewModel<TDto> : EntityManagementViewModel
    where TDto : DtoBase, new()
{

    protected CrudManagementViewModel(IFormationService dialogService) :
        base(dialogService)
    {
        //_FilteredItems.Source = Items;
    }

    protected abstract IShowContentStrategy CreateContentStrategy();

    #region ShowStrategy : ShowContentWindowStrategy - стратегия формировния записи

    private IShowContentStrategy? _ShowStrategy;
    protected IShowContentStrategy ShowStrategy => _ShowStrategy ??= CreateContentStrategy();

    #endregion
}