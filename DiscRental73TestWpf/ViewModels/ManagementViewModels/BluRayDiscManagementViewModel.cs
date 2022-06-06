using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.ViewModels.Base;
using System;
using System.Windows.Data;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class BluRayDiscManagementViewModel : CrudManagementViewModel<BluRayDiscReqDto, BluRayDiscResDto>
    {
        public BluRayDiscManagementViewModel(BluRayDiscService service, WindowDataFormationService dialogService) : base(service, dialogService)
        {

        }

        protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        {
            if (!(E.Item is BluRayDiscResDto dto))
            {
                E.Accepted = false;
                return;
            }

            var filterText = SearchedFilter;
            if (string.IsNullOrWhiteSpace(filterText)) return;
            if (dto.Title.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (dto.Publisher.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            E.Accepted = false;
        }

        protected override ShowBluRayDiscStrategy CreateContentStrategy() => new();

        protected override BluRayDiscReqDto CreateReqDtoToCreate(BluRayDiscResDto resDto)
        {
            var reqDto = new BluRayDiscReqDto
            {
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Publisher = resDto.Publisher,
                Info = resDto.Info,
                SystemRequirements = resDto.SystemRequirements
            };
            return reqDto;
        }

        protected override BluRayDiscReqDto CreateReqDtoToUpdate(BluRayDiscResDto resDto)
        {
            var reqDto = new BluRayDiscReqDto
            {
                Id = resDto.Id,
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Publisher = resDto.Publisher,
                Info = resDto.Info,
                SystemRequirements = resDto.SystemRequirements
            };
            return reqDto;
        }
    }
}
