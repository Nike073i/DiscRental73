using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.ViewModels.Base;
using MathCore.WPF.Commands;
using System;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class BluRayDiscManagementViewModel : CrudManagementViewModel<BluRayDiscReqDto, BluRayDiscResDto>
    {
        private readonly IBluRayDiscService _Service;

        public BluRayDiscManagementViewModel(IBluRayDiscService service, WindowDataFormationService dialogService) : base(dialogService)
        {
            _Service = service;
            Items = _Service.GetAll();
        }

        protected override void OnRefreshCommand(object? p)
        {
            Items = _Service.GetAll();
        }

        //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        //{
        //    if (!(E.Item is BluRayDiscResDto dto))
        //    {
        //        E.Accepted = false;
        //        return;
        //    }

        //    var filterText = SearchedFilter;
        //    if (string.IsNullOrWhiteSpace(filterText)) return;
        //    if (dto.Title.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
        //    if (dto.Publisher.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

        //    E.Accepted = false;
        //}

        protected override ShowBluRayDiscStrategy CreateContentStrategy() => new();

        protected override BluRayDiscReqDto CreateReqDtoToCreate(BluRayDiscResDto resDto)
        {
            var reqDto = new BluRayDiscReqDto
            {
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Publisher = resDto.Publisher,
                Info = resDto.Info,
                SystemRequirements = resDto.SystemRequirements
            };
            return reqDto;
        }

        protected override BluRayDiscReqDto CreateReqDtoToUpdate(BluRayDiscResDto resDto)
        {
            var reqDto = new BluRayDiscReqDto
            {
                Id = resDto.Id,
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Publisher = resDto.Publisher,
                Info = resDto.Info,
                SystemRequirements = resDto.SystemRequirements
            };
            return reqDto;
        }

        #region DeleteCommand - удаление элемента

        private ICommand? _DeleteCommand;

        public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

        private bool CanDeleteCommand(object? p)
        {
            return p is BluRayDiscResDto && IsLoginUser(p);
        }

        private void OnDeleteCommand(object? p)
        {
            if (!DialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
            try
            {
                var resDto = p as BluRayDiscResDto;
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
            return p is BluRayDiscResDto && IsLoginUser(p);
        }

        private void OnEditItemCommand(object? p)
        {
            DialogService.ShowStrategy = ShowStrategy;
            if (!DialogService.ShowContent(ref p)) return;
            try
            {
                var resDto = p as BluRayDiscResDto;
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
            object item = new BluRayDiscResDto();
            if (!DialogService.ShowContent(ref item)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item as BluRayDiscResDto);
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
}
