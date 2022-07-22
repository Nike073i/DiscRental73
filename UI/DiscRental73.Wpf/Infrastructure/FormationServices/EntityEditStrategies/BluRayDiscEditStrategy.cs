using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies.Base;
using DiscRental73.Wpf.ViewModels.EntityViewModels;
using System;

namespace DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies
{
    public class BluRayDiscEditStrategy : EntityEditStrategy
    {
        public override bool EditDialog(ref object formationData)
        {
            if (formationData is not BluRayDiscDto dto) return false;
            if (dto.Id.Equals(default))
                InsertDefaultValues(dto);
            var entityVm = new BluRayDiscViewModel(dto);

            var formationWindow = CreateFormationWindow("Окно формирования BluRay - диска", "BluRay-диск", entityVm);
            if (formationWindow.ShowDialog() is not true) return false;

            var editDto = entityVm.Dto;
            if (editDto.Info.IsNullOrWhiteSpace()) editDto.Info = null;
            if (editDto.SystemRequirements.IsNullOrWhiteSpace()) editDto.SystemRequirements = null;
            formationData = editDto;
            return true;
        }

        private static void InsertDefaultValues(in BluRayDiscDto dto)
        {
            dto.DateOfRelease = DateTime.Now;
        }
    }
}
