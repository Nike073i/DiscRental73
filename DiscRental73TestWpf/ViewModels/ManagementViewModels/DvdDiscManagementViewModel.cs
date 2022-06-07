using System;
using System.Windows.Data;
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

        //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        //{
        //    if (!(E.Item is DvdDiscResDto dto))
        //    {
        //        E.Accepted = false;
        //        return;
        //    }

        //    var filterText = SearchedFilter;
        //    if (string.IsNullOrWhiteSpace(filterText)) return;
        //    if (dto.Title.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
        //    if (dto.Director.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

        //    E.Accepted = false;
        //}

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
