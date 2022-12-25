using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Interfaces.Services.Base;
using DiscRental73.Wpf.Infrastructure.FormationServices;
using MathCore.WPF.Commands;
using System;
using System.Windows.Input;

namespace DiscRental73.Wpf.ViewModels.Base
{
    public abstract class CrudActionViewModel<TDto> : ActionViewModel<TDto>
        where TDto : DtoBase, new()
    {
        #region fields

        private readonly ICrudService<TDto> _CrudService;
        protected IFormationService FormationService { get; }

        #endregion

        #region constructors

        protected CrudActionViewModel(ICrudService<TDto> service, IFormationService formationService, IEntityEditStrategy editStrategy)
            : base(service)
        {
            _CrudService = service;
            FormationService = formationService;
            formationService.EditStrategy = editStrategy;
        }

        #endregion

        #region commands

        #region DeleteCommand - удаление элемента

        private ICommand? _DeleteCommand;

        public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnExecutedDeleteCommand, CanExecuteDeleteCommand);

        private bool CanExecuteDeleteCommand(object? p) => p is TDto;

        private void OnExecutedDeleteCommand(object? p)
        {
            if (!FormationService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
            try
            {
                if (p is not TDto dto) return;
                _CrudService.DeleteById(dto.Id);
                FormationService.ShowInformation("Запись удалена", "Успех");
                RefreshItems();
            }
            catch (Exception ex)
            {
                FormationService.ShowWarning(ex.Message, "Ошибка удаления");
            }
        }

        #endregion

        #region EditCommand - редактирование элемента

        private ICommand? _EditCommand;

        public ICommand EditCommand => _EditCommand ??= new LambdaCommand(OnExecutedEditCommand, CanExecuteEditCommand);

        public bool CanExecuteEditCommand(object? p) => p is TDto;
        private void OnExecutedEditCommand(object? p)
        {
            if (!FormationService.EditEntity(ref p!)) return;
            try
            {
                if (p is not TDto dto) return;
                _CrudService.Save(dto);
                FormationService.ShowInformation("Запись отредактирована", "Успех");
                RefreshItems();
            }
            catch (Exception ex)
            {
                FormationService.ShowWarning(ex.Message, "Ошибка редактирования");
            }
        }

        #endregion

        #region CreateCommand - создание элемента

        private ICommand? _CreateCommand;

        public ICommand CreateCommand =>
            _CreateCommand ??= new LambdaCommand(OnExecutedCreateCommand);

        private void OnExecutedCreateCommand(object? p)
        {
            object dtoWrapper = new TDto();
            if (!FormationService.EditEntity(ref dtoWrapper)) return;
            if (dtoWrapper is not TDto dto) return;
            try
            {
                _CrudService.Save(dto);
                FormationService.ShowInformation("Запись создана", "Успех");
                RefreshItems();
            }
            catch (Exception ex)
            {
                FormationService.ShowWarning(ex.Message, "Ошибка создания");
            }
        }

        #endregion

        #endregion
    }
}
