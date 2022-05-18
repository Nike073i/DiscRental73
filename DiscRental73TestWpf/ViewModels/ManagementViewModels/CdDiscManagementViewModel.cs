using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.ViewModels.Base;

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
    }
}
