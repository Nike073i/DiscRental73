using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.Interfaces.Storages;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.Base
{
    public abstract class EntityManagemenetViewModel<Req, Res> : ViewModel where Req : ReqDto, new() where Res : ResDto, new()
    {
        private readonly CrudService<Req, Res> _service;
        private readonly IFormationService _dialogService;

        public EntityManagemenetViewModel(CrudService<Req, Res> service, IFormationService dialogService)
        {
            _service = service;
            _dialogService = dialogService;
        }

        public IEnumerable<Res> Items => _service.GetAll();

        #region SelectedItem - Res - модель выбранного элемента

        private Res _SelectedItem;

        public Res SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        #endregion

        #region DeleteCommand - удаление элемента

        private ICommand _DeleteCommand;

        public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

        private bool CanDeleteCommand(object? p) => p is Res;

        private void OnDeleteCommand(object? p)
        {
            if (!_dialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
            try
            {
                var resDto = p as Res;
                var reqDto = CreateReqDtoToDelete(resDto);
                _service.DeleteById(reqDto);
                _dialogService.ShowInformation("Запись удалена", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка удаления");
            }
        }

        #endregion

        #region EditItemCommand - редактирование элемента

        private ICommand _EditItemCommand;

        public ICommand EditItemCommand => _EditItemCommand ??= new LambdaCommand(OnEditItemCommand, CanEditItemCommand);

        private bool CanEditItemCommand(object? p) => p is Res;

        private void OnEditItemCommand(object? p)
        {
            if (!_dialogService.Edit(p)) return;

            try
            {
                var resDto = p as Res;
                var reqDto = CreateReqDtoToUpdate(resDto);
                _service.Save(reqDto);
                _dialogService.ShowInformation("Запись отредактирована", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка редактирования");
            }
        }

        #endregion

        #region CreateNewItemCommand - создание элемента

        private ICommand _CreateNewItemCommand;

        public ICommand CreateNewItemCommand => _CreateNewItemCommand ??= new LambdaCommand(OnCreateNewItemCommand);

        private void OnCreateNewItemCommand(object? p)
        {
            var item = new Res();
            if (!_dialogService.Edit(item)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item);
                _service.Save(reqDto);
                _dialogService.ShowInformation("Запись создана", "Успех");
                OnPropertyChanged(nameof(Items));

            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка создания");
            }
        }

        #endregion

        #region RefreshCommand - обновление списка элементов

        private ICommand _RefreshCommand;

        public ICommand RefreshCommand => _RefreshCommand ??= new LambdaCommand(OnRefreshCommand, CanRefreshCommand);

        private bool CanRefreshCommand(object? p) => _service is not null;

        private void OnRefreshCommand(object? p) => OnPropertyChanged(nameof(Items));

        #endregion

        protected abstract Req CreateReqDtoToDelete(Res resDto);

        protected abstract Req CreateReqDtoToUpdate(Res resDto);

        protected abstract Req CreateReqDtoToCreate(Res resDto);
    }
}
