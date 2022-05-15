using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class ViewCdDiscFormationService : WindowDataFormationService<CdDiscResDto>
    {
        protected override bool EditData(ref CdDiscResDto dto)
        {
            if (dto is not CdDiscResDto item)
            {
                return false;
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
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            dto = viewModel.CdDisc;
            return true;
        }
    }
}
