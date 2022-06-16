using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using DesignDebugStorage.Repositories;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using MathCore.WPF.Commands;
using System;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class CdDiscManagementViewModel : CrudManagementViewModel<CdDiscReqDto, CdDiscResDto>
    {
        #region readonly fields

        private readonly ICdDiscService _Service;
        private readonly EntityFormationWindowViewModel _WindowVm;
        private readonly CdDiscFormationViewModel _FormationVm;

        #endregion

        #region constructors

        /// <summary>Отладочный конструктор для VS</summary>
        public CdDiscManagementViewModel() : base(null!)
        {
            if (!App.IsDesignMode)
                throw new NotSupportedException("Данный конструктор предназначен для визуального конструктора VS");
            _WindowVm = null!;
            _Service = null!;
            _FormationVm = null!;
            Items = new CdDiscDebugRepository().GetAll();
        }

        public CdDiscManagementViewModel(ICdDiscService service,
            IFormationService dialogService,
            EntityFormationWindowViewModel formationWindowVm,
            CdDiscFormationViewModel formationVm) : base(dialogService)
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

        protected override ShowCdDiscStrategy CreateContentStrategy() => new(_WindowVm, _FormationVm);

        protected override CdDiscReqDto CreateReqDtoToCreate(CdDiscResDto resDto)
        {
            var reqDto = new CdDiscReqDto
            {
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Performer = resDto.Performer,
                Genre = resDto.Genre,
                NumberOfTracks = resDto.NumberOfTracks
            };
            return reqDto;
        }

        protected override CdDiscReqDto CreateReqDtoToUpdate(CdDiscResDto resDto)
        {
            var reqDto = new CdDiscReqDto
            {
                Id = resDto.Id,
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Performer = resDto.Performer,
                Genre = resDto.Genre,
                NumberOfTracks = resDto.NumberOfTracks
            };
            return reqDto;
        }

        //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        //{
        //    if (!(E.Item is CdDiscResDto dto))
        //    {
        //        E.Accepted = false;
        //        return;
        //    }

        //    var filterText = SearchedFilter;
        //    if (string.IsNullOrWhiteSpace(filterText)) return;
        //    if (dto.Title.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
        //    if (dto.Performer.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

        //    E.Accepted = false;
        //}

        #region DeleteCommand - удаление элемента

        private ICommand? _DeleteCommand;

        public ICommand DeleteCommand => _DeleteCommand ??= new LambdaCommand(OnDeleteCommand, CanDeleteCommand);

        private bool CanDeleteCommand(object? p)
        {
            return p is CdDiscResDto && IsLoginUser(p);
        }

        private void OnDeleteCommand(object? p)
        {
            if (!DialogService.Confirm("Вы действительно хотите удалить?", "Удаление записи")) return;
            try
            {
                var resDto = p as CdDiscResDto;
                var reqDto = CreateReqDtoToDelete(resDto);
                _Service.DeleteById(reqDto.Id.Value);
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
            return p is CdDiscResDto && IsLoginUser(p);
        }

        private void OnEditItemCommand(object? p)
        {
            if (!DialogService.ShowContent(ref p, ShowStrategy)) return;
            try
            {
                var resDto = p as CdDiscResDto;
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
            object item = new CdDiscResDto();
            if (!DialogService.ShowContent(ref item, ShowStrategy)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item as CdDiscResDto);
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
