using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class ViewBluRayDiscFormationService : WindowDataFormationService<BluRayDiscResDto>
    {
        protected override bool EditData(ref BluRayDiscResDto dto)
        {
            if (dto is not BluRayDiscResDto item)
            {
                return false;
            }

            if (item.Id.Equals(0))
            {
                item.DateOfRelease = DateTime.Now;
            }

            var viewModel = App.Host.Services.GetRequiredService<BluRayDiscFormationViewModel>();
            viewModel.BluRayDisc = item;

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования BluRay-диска";
            viewModelWindow.Caption = "BluRay-диск";

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            dto = viewModel.BluRayDisc;
            if (string.IsNullOrEmpty(dto.Info)) dto.Info = null;
            if (string.IsNullOrEmpty(dto.SystemRequirements)) dto.SystemRequirements = null;

            return true;
        }
    }
}
