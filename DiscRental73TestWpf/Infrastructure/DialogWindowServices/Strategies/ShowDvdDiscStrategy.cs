using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowDvdDiscStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public int TitleMaxLength { get; set; }
        public int TitleMinLength { get; set; }
        public DateTime DateOfReleaseMaxDate { get; set; }
        public DateTime DateOfReleaseMinDate { get; set; }

        public int DirectorMaxLength { get; set; }
        public int DirectorMinLength { get; set; }
        public int InfoMaxLength { get; set; }
        public int InfoMinLength { get; set; }
        public int PlotMaxLength { get; set; }
        public int PlotMinLength { get; set; }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not DvdDiscResDto item)
            {
                return false;
            }

            if (item.Id.Equals(0))
            {
                item.DateOfRelease = DateTime.Now;
            }

            var viewModel = App.Host.Services.GetRequiredService<DvdDiscFormationViewModel>();
            viewModel.DvdDisc = item;
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования DVD-диска";
            viewModelWindow.Caption = "DVD-диск";

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                //Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            var InputData = viewModel.DvdDisc;

            if (string.IsNullOrEmpty(InputData.Info)) InputData.Info = null;
            if (string.IsNullOrEmpty(InputData.Plot)) InputData.Plot = null;

            formationData = InputData;

            return true;
        }
        private void SetValueRange(DvdDiscFormationViewModel viewModel)
        {
            viewModel.TitleMaxLength = TitleMaxLength;
            viewModel.TitleMinLength = TitleMinLength;
            viewModel.DateOfReleaseMaxDate = DateOfReleaseMaxDate;
            viewModel.DateOfReleaseMinDate = DateOfReleaseMinDate;
            viewModel.DirectorMaxLength = DirectorMaxLength;
            viewModel.DirectorMinLength = DirectorMinLength;
            viewModel.InfoMaxLength = InfoMaxLength;
            viewModel.InfoMinLength = InfoMinLength;
            viewModel.PlotMaxLength = PlotMaxLength;
            viewModel.PlotMinLength = PlotMinLength;
        }
    }
}
