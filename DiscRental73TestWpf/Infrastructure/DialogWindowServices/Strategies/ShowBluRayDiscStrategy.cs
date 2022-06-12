using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.ViewModels;
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

        #region readonly fields

        private readonly EntityFormationWindowViewModel _WindowVm;
        private readonly BluRayDiscFormationViewModel _FormationVm;

        #endregion

        #region constructors

        public ShowBluRayDiscStrategy(EntityFormationWindowViewModel windowVm, BluRayDiscFormationViewModel formationVm)
        {
            _WindowVm = windowVm;
            _FormationVm = formationVm;
            InitializeWindow(_FormationVm, "Окно формирования BluRay-диска", "BluRay-диск");
            SetValueRange(_FormationVm);
        }

        #endregion

        public bool ShowDialog(ref object formationData)
        {
            if (formationData is not BluRayDiscResDto item) return false;

            if (item.Id.Equals(0))
            {
                item.DateOfRelease = DateTime.Now;
            }

            _FormationVm.BluRayDisc = item;

            var dlg = new EntityFormationWindow
            {
                DataContext = _WindowVm,
                //Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() is not true) return false;

            if (string.IsNullOrEmpty(item.Info)) item.Info = null;
            if (string.IsNullOrEmpty(item.SystemRequirements)) item.SystemRequirements = null;

            formationData = item;
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

        private void InitializeWindow(ViewModel viewModel, string title = "Окно формирования",
            string caption = "Формирование записи")
        {
            _WindowVm.CurrentModel = viewModel;
            _WindowVm.Title = title;
            _WindowVm.Caption = caption;
        }
    }
}
