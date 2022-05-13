using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.ResponseDto;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
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

        private IEnumerable<CdDiscResDto> Disks => _logic.GetAll();

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
            System.Console.WriteLine("Команда выполена");
        }
    }
}
