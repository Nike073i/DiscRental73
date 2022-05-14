using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Views.Windows;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class WindowCdDiscFormationService : WindowDataFormationService<CdDiscResDto>
    {
        protected override bool EditData(CdDiscResDto dto)
        {
            if (dto is not CdDiscResDto item)
            {
                return false;
            }

            var dlg = new CdDiscFormationWindow
            {
                Title = item.Title ?? string.Empty,
                DateOfRelease = item.DateOfRelease,
                Performer = item.Performer ?? string.Empty,
                Genre = item.Genre ?? string.Empty,
                NumberOfTracks = item.NumberOfTracks ?? 0,
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            dto.Title = dlg.Title;
            dto.DateOfRelease = dlg.DateOfRelease;
            dto.DiscType = DiscType.CD;
            dto.Performer = dlg.Performer;
            dto.Genre = dlg.Genre;
            dto.NumberOfTracks = dlg.NumberOfTracks;
            return true;
        }
    }
}
