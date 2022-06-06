using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.Interfaces.Storages.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using MathCore.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.Base
{
    public abstract class CrudManagementViewModel<Req, Res> : EntityManagementViewModel where Req : ReqDto, new() where Res : ResDto, new()
    {
        private readonly CrudService<Req, Res> _service;

        private ShowContentWindowStrategy _ShowStrategy;
        protected ShowContentWindowStrategy ShowStrategy => _ShowStrategy ??= CreateContentStrategy();

        public CrudManagementViewModel(CrudService<Req, Res> service, WindowDataFormationService dialogService) : base(dialogService)
        {
            _service = service;
            _FilteredItems.Source = Items;
        }

        public override IEnumerable<Res> Items => _service.GetAll();

        #region DeleteCommand - удаление элемента

        private ICommand _DeleteCommand;

        public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

        private bool CanDeleteCommand(object? p) => p is Res && IsLoginUser(p);

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

        private bool CanEditItemCommand(object? p) => p is Res && IsLoginUser(p);

        private void OnEditItemCommand(object? p)
        {
            _dialogService.ShowStrategy = ShowStrategy;
            if (!_dialogService.ShowContent(ref p)) return;
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

        public ICommand CreateNewItemCommand => _CreateNewItemCommand ??= new LambdaCommand(OnCreateNewItemCommand, IsLoginUser);

        private void OnCreateNewItemCommand(object? p)
        {
            _dialogService.ShowStrategy = ShowStrategy;
            object item = new Res();
            if (!_dialogService.ShowContent(ref item)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item as Res);
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


        protected virtual Req CreateReqDtoToDelete(Res resDto)
        {
            var reqDto = new Req
            {
                Id = resDto?.Id
            };
            return reqDto;
        }

        protected abstract Req CreateReqDtoToCreate(Res resDto);
        protected abstract Req CreateReqDtoToUpdate(Res resDto);

        protected abstract ShowContentWindowStrategy CreateContentStrategy();
    }
}
