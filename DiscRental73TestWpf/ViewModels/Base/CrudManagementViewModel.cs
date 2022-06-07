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
    private readonly CrudService<TReq, TRes> _Service;

    protected CrudManagementViewModel(CrudService<TReq, TRes> service, WindowDataFormationService dialogService) :
        base(dialogService)
    {
        _Service = service;
        Items = _Service.GetAll();
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

    protected override void OnRefreshCommand(object? p)
    {
        Items = _Service.GetAll();
    }

    #region ShowStrategy : ShowContentWindowStrategy - стратегия формировния записи

    private ShowContentWindowStrategy? _ShowStrategy;
    protected ShowContentWindowStrategy ShowStrategy => _ShowStrategy ??= CreateContentStrategy();

    #endregion

    #region DeleteCommand - удаление элемента

    private ICommand? _DeleteCommand;

    public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

    private bool CanDeleteCommand(object? p)
    {
        return p is TRes && IsLoginUser(p);
    }

    private void OnDeleteCommand(object? p)
    {
        if (!DialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
        try
        {
            var resDto = p as TRes;
            var reqDto = CreateReqDtoToDelete(resDto);
            _Service.DeleteById(reqDto);
            DialogService.ShowInformation("Запись удалена", "Успех");
            OnPropertyChanged(nameof(Items));
        }
        catch (Exception ex)
        {
            DialogService.ShowWarning(ex.Message, "Ошибка удаления");
        }
    }

    #endregion

    #region EditItemCommand - редактирование элемента

    private ICommand? _EditItemCommand;

    public ICommand EditItemCommand => _EditItemCommand ??= new LambdaCommand(OnEditItemCommand, CanEditItemCommand);

    private bool CanEditItemCommand(object? p)
    {
        return p is TRes && IsLoginUser(p);
    }

    private void OnEditItemCommand(object? p)
    {
        DialogService.ShowStrategy = ShowStrategy;
        if (!DialogService.ShowContent(ref p)) return;
        try
        {
            var resDto = p as TRes;
            var reqDto = CreateReqDtoToUpdate(resDto);
            _Service.Save(reqDto);
            DialogService.ShowInformation("Запись отредактирована", "Успех");
            OnPropertyChanged(nameof(Items));
        }
        catch (Exception ex)
        {
            DialogService.ShowWarning(ex.Message, "Ошибка редактирования");
        }
    }

    #endregion

    #region CreateNewItemCommand - создание элемента

    private ICommand? _CreateNewItemCommand;

    public ICommand CreateNewItemCommand =>
        _CreateNewItemCommand ??= new LambdaCommand(OnCreateNewItemCommand, IsLoginUser);

    private void OnCreateNewItemCommand(object? p)
    {
        DialogService.ShowStrategy = ShowStrategy;
        object item = new TRes();
        if (!DialogService.ShowContent(ref item)) return;
        try
        {
            var reqDto = CreateReqDtoToCreate(item as TRes);
            _Service.Save(reqDto);
            DialogService.ShowInformation("Запись создана", "Успех");
            OnPropertyChanged(nameof(Items));
        }
        catch (Exception ex)
        {
            DialogService.ShowWarning(ex.Message, "Ошибка создания");
        }
    }

    #endregion
}