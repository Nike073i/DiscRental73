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
    public class ShowCdDiscStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public int TitleMaxLength { get; set; }
        public int TitleMinLength { get; set; }
        public DateTime DateOfReleaseMaxDate { get; set; }
        public DateTime DateOfReleaseMinDate { get; set; }

        public int PerformerMaxLength { get; set; }
        public int PerformerMinLength { get; set; }
        public int GenreMaxLength { get; set; }
        public int GenreMinLength { get; set; }
        public int NumberOfTracksMaxValue { get; set; }
        public int NumberOfTracksMinValue { get; set; }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not CdDiscResDto item)
            {
                return false;
            }

            if (item.Id.Equals(0))
            {
                item.DateOfRelease = DateTime.Now;
            }

            var viewModel = App.Host.Services.GetRequiredService<CdDiscFormationViewModel>();
            viewModel.CdDisc = item;
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования CD-диска";
            viewModelWindow.Caption = "CD-диск";

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

            var InputData = viewModel.CdDisc;

            if (string.IsNullOrEmpty(InputData.Genre)) InputData.Genre = null;

            formationData = InputData;

            return true;
        }

        private void SetValueRange(CdDiscFormationViewModel viewModel)
        {
            viewModel.TitleMaxLength = TitleMaxLength;
            viewModel.TitleMinLength = TitleMinLength;
            viewModel.DateOfReleaseMaxDate = DateOfReleaseMaxDate;
            viewModel.DateOfReleaseMinDate = DateOfReleaseMinDate;

            viewModel.PerformerMaxLength = PerformerMaxLength;
            viewModel.PerformerMinLength = PerformerMinLength;
            viewModel.GenreMaxLength = GenreMaxLength;
            viewModel.GenreMinLength = GenreMinLength;
            viewModel.NumberOfTracksMaxValue = NumberOfTracksMaxValue;
            viewModel.NumberOfTracksMinValue = NumberOfTracksMinValue;
        }
    }
}