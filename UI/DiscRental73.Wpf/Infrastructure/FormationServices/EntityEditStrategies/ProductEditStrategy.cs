using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies.Base;
using DiscRental73.Wpf.ViewModels.EntityViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies
{
    public class ProductEditStrategy : EntityEditStrategy
    {
        public IEnumerable<DiscDto>? Discs { get; set; }

        public override bool EditDialog(ref object formationData)
        {
            if (formationData is not ProductDto dto) return false;

            if (dto.Id.Equals(0))
                InsertDefaultValues(dto);
            var entityVm = new ProductViewModel(dto);
            entityVm.AvailableDiscs = Discs ?? Enumerable.Empty<DiscDto>();

            var formationWindow = CreateFormationWindow("Окно формирования продукта", "Продукт", entityVm);

            if (formationWindow.ShowDialog() is not true) return false;

            formationData = entityVm.Dto;
            return true;
        }

        private static void InsertDefaultValues(in ProductDto dto)
        {
            dto.IsAvailable = true;
        }
    }

    public class ProductCostEditStrategy : EntityEditStrategy
    {
        /// Беда... Я хз че делать....
        public override bool EditDialog(ref object formationData)
        {
            if (formationData is not ProductDto dto) return false;

            var entityVm = new ProductViewModel(dto);

            var formationWindow = CreateFormationWindow("Окно изменения стоимости продукта", "Продукт", entityVm);

            if (formationWindow.ShowDialog() is not true) return false;

            formationData = entityVm.Dto;
            return true;
        }
    }
}
