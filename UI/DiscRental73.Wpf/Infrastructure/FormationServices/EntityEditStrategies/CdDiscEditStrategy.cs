using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies.Base;
using DiscRental73.Wpf.ViewModels.EntityViewModels;
using System;

namespace DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies
{
    public class CdDiscEditStrategy : EntityEditStrategy
    {
        public override bool EditDialog(ref object formationData)
        {
            if (formationData is not CdDiscDto dto) return false;
            if (dto.Id.Equals(default))
                InsertDefaultValues(dto);
            var entityVm = new CdDiscViewModel(dto);

            var formationWindow = CreateFormationWindow("Окно формирования Cd - диска", "Cd-диск", entityVm);
            if (formationWindow.ShowDialog() is not true) return false;

            var editDto = entityVm.Dto;
            if (editDto.Genre.IsNullOrWhiteSpace()) editDto.Genre = null;
            formationData = editDto;
            return true;
        }

        private static void InsertDefaultValues(in CdDiscDto dto)
        {
            dto.DateOfRelease = DateTime.Now;
        }
    }
}