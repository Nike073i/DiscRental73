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
    public class ShowBluRayDiscStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public int TitleMaxLength { get; set; }
        public int TitleMinLength { get; set; }
        public DateTime DateOfReleaseMaxDate { get; set; }
        public DateTime DateOfReleaseMinDate { get; set; }

        public int PublisherMaxLength { get; set; }
        public int PublisherMinLength { get; set; }
        public int InfoMaxLength { get; set; }
        public int InfoMinLength { get; set; }
        public int SystemRequirementsMaxLength { get; set; }
        public int SystemRequirementsMinLength { get; set; }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData is not BluRayDiscResDto item)
            {
                return false;
            }

            if (item.Id.Equals(0))
            {
                item.DateOfRelease = DateTime.Now;
            }

            var viewModel = App.Host.Services.GetRequiredService<BluRayDiscFormationViewModel>();

            viewModel.BluRayDisc = item;
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования BluRay-диска";
            viewModelWindow.Caption = "BluRay-диск";

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

            var InputData = viewModel.BluRayDisc;

            if (string.IsNullOrEmpty(InputData.Info)) InputData.Info = null;
            if (string.IsNullOrEmpty(InputData.SystemRequirements)) InputData.SystemRequirements = null;

            formationData = InputData;

            return true;
        }

        private void SetValueRange(BluRayDiscFormationViewModel viewModel)
        {
            viewModel.TitleMaxLength = TitleMaxLength;
            viewModel.TitleMinLength = TitleMinLength;
            viewModel.DateOfReleaseMaxDate = DateOfReleaseMaxDate;
            viewModel.DateOfReleaseMinDate = DateOfReleaseMinDate;
            viewModel.PublisherMaxLength = PublisherMaxLength;
            viewModel.PublisherMinLength = PublisherMinLength;
            viewModel.InfoMaxLength = InfoMaxLength;
            viewModel.InfoMinLength = InfoMinLength;
            viewModel.SystemRequirementsMaxLength = SystemRequirementsMaxLength;
            viewModel.SystemRequirementsMinLength = SystemRequirementsMinLength;
        }
    }
}
