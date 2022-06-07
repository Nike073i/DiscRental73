﻿using AdminWpfPlugin.Infrastructure.DialogWindowServices.Strategies;
using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.ViewModels.Base;

namespace AdminWpfPlugin.ViewModels
{
    public class EmployeeManagementViewModel : CrudManagementViewModel<EmployeeReqDto, EmployeeResDto>
    {
        public EmployeeManagementViewModel(EmployeeService service, WindowDataFormationService dialogService) : base(service, dialogService)
        {
        }

        protected override ShowEmployeeStrategy CreateContentStrategy() => new();

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

        //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        //{
        //    if (!(E.Item is EmployeeResDto dto))
        //    {
        //        E.Accepted = false;
        //        return;
        //    }

        //    var filterText = SearchedFilter;
        //    if (string.IsNullOrWhiteSpace(filterText)) return;
        //    if (dto.SecondName.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
        //    if (dto.ContactNumber.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

        //    E.Accepted = false;
        //}
    }
}