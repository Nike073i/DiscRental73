using BusinessLogic.Interfaces.Storages.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.Interfaces;

namespace DiscRental73TestWpf.ViewModels.Base;

public abstract class CrudManagementViewModel<TReq, TRes> : EntityManagementViewModel
    where TReq : ReqDto, new() where TRes : ResDto, new()
{

    protected CrudManagementViewModel(IFormationService dialogService) :
        base(dialogService)
    {

        //_FilteredItems.Source = Items;
    }

    protected virtual TReq CreateReqDtoToDelete(TRes resDto)
    {
        var reqDto = new TReq
        {
            Id = resDto.Id
        };
        return reqDto;
    }

    protected abstract TReq CreateReqDtoToCreate(TRes resDto);
    protected abstract TReq CreateReqDtoToUpdate(TRes resDto);

    protected abstract IShowContentStrategy CreateContentStrategy();

    #region ShowStrategy : ShowContentWindowStrategy - стратегия формировния записи

    private IShowContentStrategy? _ShowStrategy;
    protected IShowContentStrategy ShowStrategy => _ShowStrategy ??= CreateContentStrategy();

    #endregion
}