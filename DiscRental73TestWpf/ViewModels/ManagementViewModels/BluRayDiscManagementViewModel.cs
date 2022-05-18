using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class BluRayDiscManagementViewModel : CrudManagementViewModel<BluRayDiscReqDto, BluRayDiscResDto>
    {
        public BluRayDiscManagementViewModel(BluRayDiscService service, WindowDataFormationService dialogService) : base(service, dialogService)
        {
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
