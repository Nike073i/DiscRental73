using DiscRental73TestWpf.Infrastructure.Commands;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class EntityFormationWindowViewModel : ViewModel
    {
        private ViewModel _CurrentModel;

        public ViewModel CurrentModel { get => _CurrentModel; set => Set(ref _CurrentModel, value); }

        private string _Title = "Окно формирования записи";
        public string Title { get => _Title; set => Set(ref _Title, value); }

        private string _Caption = "Формирование записи";
        public string Caption { get => _Caption; set => Set(ref _Caption, value); }

        private readonly ICommand _CloseDialogCommand;
        private readonly ICommand _CloseWindowCommand;

        public ICommand CloseDialogCommand => _CloseDialogCommand;
        public ICommand CloseWindowCommand => _CloseWindowCommand;

        public EntityFormationWindowViewModel()
        {
            _CloseDialogCommand = new CloseDialogCommand();
            _CloseWindowCommand = new CloseWindowCommand();
        }

        private ICommand _LoadViewData;

        public ICommand LoadViewData => _LoadViewData ??= new LambdaCommand(OnLoadViewData);
        private void OnLoadViewData(object? p)
        {
            CurrentModel = App.Host.Services.GetRequiredService<CdDiscFormationViewModel>();
        }
    }
}
