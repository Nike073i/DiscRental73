using DesignDebugStorage.Repositories;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using MathCore.WPF.Commands;
using System;
using System.Windows.Input;
using DiscRental73.Domain.BusinessLogic;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels;

public class DvdDiscManagementViewModel : CrudManagementViewModel<DvdDiscDto>
{
    #region readonly fields

    private readonly DvdDiscService _Service;
    private readonly EntityFormationWindowViewModel _WindowVm;
    private readonly DvdDiscFormationViewModel _FormationVm;

    #endregion

    #region constructors

    /// <summary>Отладочный конструктор для VS</summary>
    public DvdDiscManagementViewModel() : base(null!)
    {
        if (!App.IsDesignMode)
            throw new NotSupportedException("Данный конструктор предназначен для визуального конструктора VS");
        _WindowVm = null!;
        _Service = null!;
        _FormationVm = null!;
        Items = new DvdDiscDebugRepository().GetAll();
    }

    public DvdDiscManagementViewModel(DvdDiscService service,
        IFormationService dialogService,
        EntityFormationWindowViewModel
            formationWindowVm,
        DvdDiscFormationViewModel formationVm) : base(dialogService)
    {
        _Service = service;
        _WindowVm = formationWindowVm;
        _FormationVm = formationVm;
        Items = _Service.GetAll();
    }

    #endregion

    protected override void OnRefreshCommand(object? p)
    {
        Items = _Service.GetAll();
    }

    protected override ShowDvdDiscStrategy CreateContentStrategy() => new(_WindowVm, _FormationVm);

    //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
    //{
    //    if (!(E.Item is DvdDiscDto dto))
    //    {
    //        E.Accepted = false;
    //        return;
    //    }

    //    var filterText = SearchedFilter;
    //    if (string.IsNullOrWhiteSpace(filterText)) return;
    //    if (dto.Title.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
    //    if (dto.Director.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

    //    E.Accepted = false;
    //}

    #region DeleteCommand - удаление элемента

    private ICommand? _DeleteCommand;

    public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

    private bool CanDeleteCommand(object? p)
    {
        return p is DvdDiscDto && IsLoginUser(p);
    }

    private void OnDeleteCommand(object? p)
    {
        if (!DialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
        try
        {
            if (p is not DvdDiscDto dto) return;
            _Service.DeleteById(dto.Id);
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
        return p is DvdDiscDto && IsLoginUser(p);
    }

    private void OnEditItemCommand(object? p)
    {
        if (!DialogService.ShowContent(ref p, ShowStrategy)) return;
        try
        {
            if (p is not DvdDiscDto dto) return;
            _Service.Save(dto);
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
        object item = new DvdDiscDto();
        if (!DialogService.ShowContent(ref item, ShowStrategy)) return;
        try
        {
            if (p is not DvdDiscDto dto) return;
            _Service.Save(dto);
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

