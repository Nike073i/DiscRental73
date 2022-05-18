using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class DvdDiscManagementViewModel : CrudManagementViewModel<DvdDiscReqDto, DvdDiscResDto>
    {
        public DvdDiscManagementViewModel(DvdDiscService service, WindowDataFormationService dialogService) : base(service, dialogService)
        {
        }

        protected override ShowDvdDiscStrategy CreateContentStrategy() => new();

        protected override DvdDiscReqDto CreateReqDtoToCreate(DvdDiscResDto resDto)
        {
            var reqDto = new DvdDiscReqDto
            {
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Director = resDto.Director,
                Info = resDto.Info,
                Plot = resDto.Plot
            };
            return reqDto;
        }

        protected override DvdDiscReqDto CreateReqDtoToUpdate(DvdDiscResDto resDto)
        {
            var reqDto = new DvdDiscReqDto
            {
                Id = resDto.Id,
                Title = resDto.Title,
                DateOfRelease = resDto.DateOfRelease,
                Director = resDto.Director,
                Info = resDto.Info,
                Plot = resDto.Plot
            };
            return reqDto;
        }
    }
}
