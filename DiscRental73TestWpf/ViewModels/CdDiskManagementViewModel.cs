using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class CdDiskManagementViewModel : ViewModel
    {
        private readonly CdDiscLogic _logic;
        public CdDiskManagementViewModel(CdDiscLogic logic)
        {
            _logic = logic;
        }

        private CdDiscResDto _SelectedDisc;

        public IEnumerable<CdDiscResDto> Discs => _logic.GetAll();

        public CdDiscResDto SelectedDisc { get => _SelectedDisc; set => Set(ref _SelectedDisc, value); }


        private ICommand _createNewCommand;

        public ICommand CreateNewCommand
        {
            get
            {
                if (_createNewCommand == null)
                {
                    _createNewCommand = new LambdaCommand(OnCreateNewCommandExecuted, CanCreateNewCommandExecute);
                }
                return _createNewCommand;
            }
        }

        private bool CanCreateNewCommandExecute()
        {
            return true;
        }

        private void OnCreateNewCommandExecuted()
        {
            string Title = "Тестовая запись";
            DiscType discType = DiscType.CD;
            DateTime dateTime = DateTime.UtcNow;
            string Performer = "Тестовый исп";
            string Genre = "Тестовый жанр";
            int NumberOfTracks = 444;
            try
            {
                //_logic.Save(new CdDiscReqDto
                //{
                //    Title = Title,
                //    DiscType = discType,
                //    DateOfRelease = dateTime,
                //    Performer = Performer,
                //    Genre = Genre,
                //    NumberOfTracks = NumberOfTracks
                //});
            }catch(Exception ex)
            {

            }
        }
    }
}
