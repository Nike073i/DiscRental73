using System;
using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.ViewModels.Base;
using System.Windows.Data;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class ClientManagementViewModel : CrudManagementViewModel<ClientReqDto, ClientResDto>
    {
        public ClientManagementViewModel(ClientService service, WindowDataFormationService dialogService) : base(service, dialogService)
        {
        }

        protected override ShowClientStrategy CreateContentStrategy() => new();

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

        protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        {
            if (!(E.Item is ClientResDto dto))
            {
                E.Accepted = false;
                return;
            }

            var filterText = SearchedFilter;
            if (string.IsNullOrWhiteSpace(filterText)) return;
            if (dto.SecondName.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (dto.ContactNumber.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            E.Accepted = false;
        }
    }
}
