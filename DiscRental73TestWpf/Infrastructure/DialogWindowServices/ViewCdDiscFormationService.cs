using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class ViewCdDiscFormationService : WindowDataFormationService<CdDiscResDto>
    {
        protected override bool EditData(CdDiscResDto dto)
        {
            if (dto is not CdDiscResDto item)
            {
                return false;
            }

            //var viewModel = App.Host.Services.GetRequiredService<CdDiscFormationViewModel>();

            var viewModel = new CdDiscFormationViewModel();
            viewModel.Title = item.Title;
            viewModel.DateOfRelease = item.DateOfRelease;
            viewModel.Performer = item.Performer ?? string.Empty;
            viewModel.Genre = item.Genre ?? string.Empty;
            viewModel.NumberOfTracks = item.NumberOfTracks ?? 0;

            var viewModelWindow = new EntityFormationWindowViewModel();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно формирования CD-диска";
            viewModelWindow.Caption = "CD-диск";

            /// Можно передавать не параметры, а просто CurrentItem в по свойству

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

            dto.Title = viewModel.Title;
            dto.DateOfRelease = viewModel.DateOfRelease;
            dto.DiscType = DiscType.CD;
            dto.Performer = viewModel.Performer;
            dto.Genre = viewModel.Genre;
            dto.NumberOfTracks = viewModel.NumberOfTracks;
            return true;
        }
    }
}
