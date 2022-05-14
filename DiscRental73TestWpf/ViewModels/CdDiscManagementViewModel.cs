using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Mappers;
using DiscRental73TestWpf.Infrastructure.Commands;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class CdDiscManagementViewModel : ViewModel
    {
        private readonly CdDiscService _service;
        private readonly CdDiscMapper _mapper;
        private readonly IFormationService _dialogService;
        private readonly ICommand _DeleteCommand;
        private readonly ICommand _SaveCommand;
        private readonly ICommand _RefreshCommand;

        public CdDiscManagementViewModel(CdDiscService service, CdDiscMapper mapper, IFormationService formationService)
        {
            _service = service;
            _mapper = mapper;
            _dialogService = formationService;
            _DeleteCommand = new DeleteDataCommand<CdDiscReqDto, CdDiscResDto>(_service, mapper);
            _SaveCommand = new SaveDataCommand<CdDiscReqDto, CdDiscResDto>(_service, mapper);
            _RefreshCommand = new LambdaCommand(OnRefreshCommand,CanRefreshCommand);
        }

        private CdDiscResDto _SelectedDisc;

        public IEnumerable<CdDiscResDto> Discs => _service.GetAll();

        public CdDiscResDto SelectedDisc { get => _SelectedDisc; set => Set(ref _SelectedDisc, value); }

        public ICommand SaveDataCommand => _SaveCommand;
        public ICommand DeleteCommand => _DeleteCommand;

        #region EditItemCommand - редактирование элемента
        private ICommand _EditItemCommand;
        public ICommand EditItemCommand => _EditItemCommand ??= new LambdaCommand(OnEditItemCommand, CanEditItemCommand);

        private bool CanEditItemCommand(object? p)
        {
            return p is CdDiscResDto;
        }

        private void OnEditItemCommand(object? p)
        {
            if (p is not CdDiscResDto item)
            {
                return;
            }

            if (_dialogService.Edit(p))
            {
                var req = _mapper.MapToReq(item);
                _service.Save(req);
                _dialogService.ShowInformation("Студент отредактирован", "сд-дисков");
            }
            else
            {
                _dialogService.ShowWarning("Отказ от редактирования", "сд-дисков");
            }
        }
        #endregion

        #region CreateNewItemCommand - создание элемента
        private ICommand _CreateNewItemCommand;
        public ICommand CreateNewItemCommand => _CreateNewItemCommand ??= new LambdaCommand(OnCreateNewItemCommand);

        private void OnCreateNewItemCommand(object? p)
        {
            var item = new CdDiscResDto();
            if (_dialogService.Edit(item))
            {
                try
                {
                    var req = _mapper.MapToReq(item);
                    _service.Save(req);
                    OnPropertyChanged(nameof(Discs));
                    return;
                }
                catch
                {
                    if (_dialogService.Confirm("Не удалось создать сд-диск. Повторить?", "Менеджер сд-дисков"))
                    {
                        OnCreateNewItemCommand(p);
                    }
                }
            }
        }
        #endregion

        #region RefreshCommand - обновление списка

        public ICommand RefreshCommand => _RefreshCommand;

        public void OnRefreshCommand(object? p)
        {
            var dlg = new EntityFormationWindow();
            if (dlg.ShowDialog()== true)
            {
                _dialogService.ShowInformation("ДА", "АГА");
            }
        }

        public bool CanRefreshCommand(object? p) => true;

        #endregion
    }
}
