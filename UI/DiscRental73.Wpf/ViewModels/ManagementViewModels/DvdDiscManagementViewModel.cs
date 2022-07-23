using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.ViewModels.ActionViewModels;
using DiscRental73.Wpf.ViewModels.Base;
using DiscRental73.Wpf.ViewModels.EntityViewModels;

namespace DiscRental73.Wpf.ViewModels.ManagementViewModels
{
    public class DvdDiscManagementViewModel : ManagementViewModel<DvdDiscDto>
    {
        public DvdDiscManagementViewModel(DvdDiscActionViewModel actionViewModel) : base(actionViewModel)
        {
            actionViewModel.OnChangedSelectedItemAction = dto =>
                EntityViewModel = dto is null ? null : new DvdDiscViewModel(dto);
        }
    }
}