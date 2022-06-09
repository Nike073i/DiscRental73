using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.Interfaces.Storages.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using MathCore.WPF.Commands;
using System;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.Base;

public abstract class CrudManagementViewModel<TReq, TRes> : EntityManagementViewModel
    where TReq : ReqDto, new() where TRes : ResDto, new()
{

    protected CrudManagementViewModel(WindowDataFormationService dialogService) :
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

    protected abstract ShowContentWindowStrategy CreateContentStrategy();

    #region ShowStrategy : ShowContentWindowStrategy - стратегия формировния записи

    private ShowContentWindowStrategy? _ShowStrategy;
    protected ShowContentWindowStrategy ShowStrategy => _ShowStrategy ??= CreateContentStrategy();

    #endregion
}