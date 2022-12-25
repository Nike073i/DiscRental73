using System;
using System.Windows.Input;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Services;
using DiscRental73.Wpf.Infrastructure.FormationServices;
using DiscRental73.Wpf.ViewModels.Base;
using MathCore.WPF.Commands;

namespace DiscRental73.Wpf.ViewModels.ActionViewModels
{
    public class ProductActionViewModel : ActionViewModel<ProductDto, ProductDetailDto>
    {
        #region fields

        private readonly IProductService<ProductDto, ProductDetailDto> _Service;
        protected IFormationService FormationService { get; }

        #endregion

        #region constructors

        public ProductActionViewModel(IProductService<ProductDto, ProductDetailDto> service, IFormationService formationService) :
            base(service)
        {
            _Service = service;
            FormationService = formationService;
            //formationService.EditStrategy = new ;
            ActionHeader = "Продукция";
        }

        #endregion

        //#region commands

        //#region DeleteCommand - удаление элемента

        //private ICommand? _DeleteCommand;

        //public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnExecutedDeleteCommand, CanExecuteDeleteCommand);

        //private bool CanExecuteDeleteCommand(object? p) => p is TDto;

        //private void OnExecutedDeleteCommand(object? p)
        //{
        //    if (!FormationService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
        //    try
        //    {
        //        if (p is not TDto dto) return;
        //        _Service.DeleteById(dto.Id);
        //        FormationService.ShowInformation("Запись удалена", "Успех");
        //        RefreshItems();
        //    }
        //    catch (Exception ex)
        //    {
        //        FormationService.ShowWarning(ex.Message, "Ошибка удаления");
        //    }
        //}

        //#endregion

        //#region EditCommand - редактирование элемента

        //private ICommand? _EditCommand;

        //public ICommand EditCommand => _EditCommand ??= new LambdaCommand(OnExecutedEditCommand, CanExecuteEditCommand);

        //public bool CanExecuteEditCommand(object? p) => p is TDto;
        //private void OnExecutedEditCommand(object? p)
        //{
        //    if (!FormationService.EditEntity(ref p!)) return;
        //    try
        //    {
        //        if (p is not TDto dto) return;
        //        _Service.Save(dto);
        //        FormationService.ShowInformation("Запись отредактирована", "Успех");
        //        RefreshItems();
        //    }
        //    catch (Exception ex)
        //    {
        //        FormationService.ShowWarning(ex.Message, "Ошибка редактирования");
        //    }
        //}

        //#endregion

        //#region CreateCommand - создание элемента

        //private ICommand? _CreateCommand;

        //public ICommand CreateCommand =>
        //    _CreateCommand ??= new LambdaCommand(OnExecutedCreateCommand);

        //private void OnExecutedCreateCommand(object? p)
        //{
        //    object dtoWrapper = new TDto();
        //    if (!FormationService.EditEntity(ref dtoWrapper)) return;
        //    if (dtoWrapper is not TDto dto) return;
        //    try
        //    {
        //        _Service.Save(dto);
        //        FormationService.ShowInformation("Запись создана", "Успех");
        //        RefreshItems();
        //    }
        //    catch (Exception ex)
        //    {
        //        FormationService.ShowWarning(ex.Message, "Ошибка создания");
        //    }
        //}

        //#endregion

        //#endregion
    }
}
