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
    public class ShowCdDiscStrategy : ShowContentWindowStrategy
    {
        public ShowCdDiscStrategy(Window activeWindow) : base(activeWindow)
        {
        }

        public override bool ShowDialog(ref object formationData)
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

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования CD-диска";
            viewModelWindow.Caption = "CD-диск";

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                Owner = _activeWindow,
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
    }
}