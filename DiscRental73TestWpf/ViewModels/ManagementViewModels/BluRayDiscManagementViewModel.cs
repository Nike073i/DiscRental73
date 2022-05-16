using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class BluRayDiscManagementViewModel : EntityManagemenetViewModel<BluRayDiscReqDto, BluRayDiscResDto>
    {
        public BluRayDiscManagementViewModel(BluRayDiscService service, ViewBluRayDiscFormationService dialogService) : base(service, dialogService)
        {
        }

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
