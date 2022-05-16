using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class ClientManagementViewModel : EntityManagemenetViewModel<ClientReqDto, ClientResDto>
    {
        public ClientManagementViewModel(ClientService service, ViewClientFormationService dialogService) : base(service, dialogService)
        {
        }

        protected override ClientReqDto CreateReqDtoToCreate(ClientResDto resDto)
        {
            var reqDto = new ClientReqDto
            {
                ContactNumber = resDto.ContactNumber,
                FirstName = resDto.FirstName,
                SecondName = resDto.SecondName,
                Address = resDto.Address,
            };
            return reqDto;
        }

        protected override ClientReqDto CreateReqDtoToUpdate(ClientResDto resDto)
        {
            var reqDto = new ClientReqDto
            {
                Id = resDto.Id,
                ContactNumber = resDto.ContactNumber,
                FirstName = resDto.FirstName,
                SecondName = resDto.SecondName,
                Address = resDto.Address,
            };
            return reqDto;
        }
    }
}
