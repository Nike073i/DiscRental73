using System;
using System.Windows.Input;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.Base;
using MathCore.WPF.Commands;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class DvdDiscManagementViewModel : CrudManagementViewModel<DvdDiscReqDto, DvdDiscResDto>
    {
        private readonly IDvdDiscService _Service;
        public DvdDiscManagementViewModel(IDvdDiscService service, IFormationService dialogService) : base(dialogService)
        {
            _Service = service;
            Items = _Service.GetAll();
        }

        protected override void OnRefreshCommand(object? p)
        {
            Items = _Service.GetAll();
        }

        protected override ShowDvdDiscStrategy CreateContentStrategy() => new();

        //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        //{
        //    if (!(E.Item is DvdDiscResDto dto))
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

        protected override DvdDiscReqDto CreateReqDtoToCreate(DvdDiscResDto resDto)
        {
            var reqDto = new DvdDiscReqDto
            {
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Director = resDto.Director,
                Info = resDto.Info,
                Plot = resDto.Plot
            };
            return reqDto;
        }

        protected override DvdDiscReqDto CreateReqDtoToUpdate(DvdDiscResDto resDto)
        {
            var reqDto = new DvdDiscReqDto
            {
                Id = resDto.Id,
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Director = resDto.Director,
                Info = resDto.Info,
                Plot = resDto.Plot
            };
            return reqDto;
        }

        #region DeleteCommand - удаление элемента

        private ICommand? _DeleteCommand;

        public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

        private bool CanDeleteCommand(object? p)
        {
            return p is DvdDiscResDto && IsLoginUser(p);
        }

        private void OnDeleteCommand(object? p)
        {
            if (!DialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
            try
            {
                var resDto = p as DvdDiscResDto;
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
            return p is DvdDiscResDto && IsLoginUser(p);
        }

        private void OnEditItemCommand(object? p)
        {
            if (!DialogService.ShowContent(ref p, ShowStrategy)) return;
            try
            {
                var resDto = p as DvdDiscResDto;
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
            object item = new DvdDiscResDto();
            if (!DialogService.ShowContent(ref item, ShowStrategy)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item as DvdDiscResDto);
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
