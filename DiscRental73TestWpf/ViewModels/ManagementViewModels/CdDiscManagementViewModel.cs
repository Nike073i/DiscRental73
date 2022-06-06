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
    public class CdDiscManagementViewModel : CrudManagementViewModel<CdDiscReqDto, CdDiscResDto>
    {
        public CdDiscManagementViewModel(CdDiscService service, WindowDataFormationService dialogService) : base(service, dialogService)
        {
        }

        protected override ShowCdDiscStrategy CreateContentStrategy() => new();

        protected override CdDiscReqDto CreateReqDtoToCreate(CdDiscResDto resDto)
        {
            var reqDto = new CdDiscReqDto
            {
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Performer = resDto.Performer,
                Genre = resDto.Genre,
                NumberOfTracks = resDto.NumberOfTracks
            };
            return reqDto;
        }

        protected override CdDiscReqDto CreateReqDtoToUpdate(CdDiscResDto resDto)
        {
            var reqDto = new CdDiscReqDto
            {
                Id = resDto.Id,
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Performer = resDto.Performer,
                Genre = resDto.Genre,
                NumberOfTracks = resDto.NumberOfTracks
            };
            return reqDto;
        }

        protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        {
            if (!(E.Item is CdDiscResDto dto))
            {
                E.Accepted = false;
                return;
            }

            var filterText = SearchedFilter;
            if (string.IsNullOrWhiteSpace(filterText)) return;
            if (dto.Title.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (dto.Performer.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            E.Accepted = false;
        }
    }
}
