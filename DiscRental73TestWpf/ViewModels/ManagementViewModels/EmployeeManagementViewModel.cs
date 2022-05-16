using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class EmployeeManagementViewModel : EntityManagemenetViewModel<EmployeeReqDto, EmployeeResDto>
    {
        public EmployeeManagementViewModel(EmployeeService service, ViewEmployeeFormationService dialogService) : base(service, dialogService)
        {
        }

        protected override EmployeeReqDto CreateReqDtoToCreate(EmployeeResDto resDto)
        {
            var reqDto = new EmployeeReqDto
            {
                ContactNumber = resDto.ContactNumber,
                FirstName = resDto.FirstName,
                SecondName = resDto.SecondName,
                Password = resDto.Password,
                Position = resDto.Position,
            };
            return reqDto;
        }

        protected override EmployeeReqDto CreateReqDtoToUpdate(EmployeeResDto resDto)
        {
            var reqDto = new EmployeeReqDto
            {
                Id = resDto.Id,
                ContactNumber = resDto.ContactNumber,
                FirstName = resDto.FirstName,
                SecondName = resDto.SecondName,
                Password = resDto.Password,
                Position = resDto.Position,
            };
            return reqDto;
        }
    }
}
