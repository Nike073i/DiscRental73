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
    public class ClientManagementViewModel : CrudManagementViewModel<ClientReqDto, ClientResDto>
    {
        private readonly IClientService _Service;

        public ClientManagementViewModel(IClientService service, WindowDataFormationService dialogService) : base(dialogService)
        {
            _Service = service;
            Items = _Service.GetAll();
        }

        protected override void OnRefreshCommand(object? p)
        {
            Items = _Service.GetAll();
        }

        protected override ShowClientStrategy CreateContentStrategy() => new();

        protected override ClientReqDto CreateReqDtoToCreate(ClientResDto resDto)
        {
            var reqDto = new ClientReqDto
            {
                ContactNumber = resDto.ContactNumber,
                FirstName = resDto.FirstName,
                SecondName = resDto.SecondName,
                Address = resDto.Address,
            };
            return reqDto;
        }

        protected override ClientReqDto CreateReqDtoToUpdate(ClientResDto resDto)
        {
            var reqDto = new ClientReqDto
            {
                Id = resDto.Id,
                ContactNumber = resDto.ContactNumber,
                FirstName = resDto.FirstName,
                SecondName = resDto.SecondName,
                Address = resDto.Address,
            };
            return reqDto;
        }

        //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        //{
        //    if (!(E.Item is ClientResDto dto))
        //    {
        //        E.Accepted = false;
        //        return;
        //    }

        //    var filterText = SearchedFilter;
        //    if (string.IsNullOrWhiteSpace(filterText)) return;
        //    if (dto.SecondName.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
        //    if (dto.ContactNumber.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

        //    E.Accepted = false;
        //}

        #region DeleteCommand - удаление элемента

        private ICommand? _DeleteCommand;

        public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

        private bool CanDeleteCommand(object? p)
        {
            return p is ClientResDto && IsLoginUser(p);
        }

        private void OnDeleteCommand(object? p)
        {
            if (!DialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
            try
            {
                var resDto = p as ClientResDto;
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
            return p is ClientResDto && IsLoginUser(p);
        }

        private void OnEditItemCommand(object? p)
        {
            DialogService.ShowStrategy = ShowStrategy;
            if (!DialogService.ShowContent(ref p)) return;
            try
            {
                var resDto = p as ClientResDto;
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
            object item = new ClientResDto();
            if (!DialogService.ShowContent(ref item)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item as ClientResDto);
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
