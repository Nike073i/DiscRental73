using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowClientStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public int ContactNumberLength { get; set; }
        public int FirstNameMaxLength { get; set; }
        public int FirstNameMinLength { get; set; }
        public int SecondNameMaxLength { get; set; }
        public int SecondNameMinLength { get; set; }
        public int AddressMaxLength { get; set; }
        public int AddressMinLength { get; set; }

        #endregion

        #region readonly fields

        private readonly EntityFormationWindowViewModel _WindowVm;
        private readonly ClientFormationViewModel _FormationVm;

        #endregion

        #region constructors

        public ShowClientStrategy(EntityFormationWindowViewModel windowVm, ClientFormationViewModel formationVm)
        {
            _WindowVm = windowVm;
            _FormationVm = formationVm;
            InitializeWindow(_FormationVm, "Окно формирования клиента", "Клиент");
            SetValueRange(_FormationVm);
        }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData is not ClientResDto item) return false;

            _FormationVm.Client = item;

            var dlg = new EntityFormationWindow
            {
                DataContext = _WindowVm,
                //Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            formationData = item;
            return true;
        }

        private void SetValueRange(ClientFormationViewModel viewModel)
        {
            viewModel.ContactNumberLength = ContactNumberLength;
            viewModel.FirstNameMaxLength = FirstNameMaxLength;
            viewModel.FirstNameMinLength = FirstNameMinLength;
            viewModel.SecondNameMaxLength = SecondNameMaxLength;
            viewModel.SecondNameMinLength = SecondNameMinLength;
            viewModel.AddressMaxLength = AddressMaxLength;
            viewModel.AddressMinLength = AddressMinLength;
        }

        private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
            string caption = "Формирование записи")
        {
            _WindowVm.CurrentModel = viewModel;
            _WindowVm.Title = title;
            _WindowVm.Caption = caption;
        }
    }
}
