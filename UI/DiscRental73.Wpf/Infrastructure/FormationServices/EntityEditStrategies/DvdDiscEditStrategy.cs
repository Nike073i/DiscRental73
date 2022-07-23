using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies.Base;
using DiscRental73.Wpf.ViewModels.EntityViewModels;
using System;

namespace DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies
{
    public class DvdDiscEditStrategy : EntityEditStrategy
    {
        public override bool EditDialog(ref object formationData)
        {
            if (formationData is not DvdDiscDto dto) return false;
            if (dto.Id.Equals(default))
                InsertDefaultValues(dto);
            var entityVm = new DvdDiscViewModel(dto);

            var formationWindow = CreateFormationWindow("Окно формирования Dvd - диска", "Dvd-диск", entityVm);
            if (formationWindow.ShowDialog() is not true) return false;

            var editDto = entityVm.Dto;
            if (editDto.Info.IsNullOrWhiteSpace()) editDto.Info = null;
            if (editDto.Plot.IsNullOrWhiteSpace()) editDto.Plot = null;
            formationData = editDto;
            return true;
        }

        private static void InsertDefaultValues(in DvdDiscDto dto)
        {
            dto.DateOfRelease = DateTime.Now;
        }
    }
}