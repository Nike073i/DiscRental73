using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies.Base;
using DiscRental73.Wpf.ViewModels.EntityViewModels;

namespace DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies
{
    public class ClientEditStrategy : EntityEditStrategy
    {
        public override bool EditDialog(ref object formationData)
        {
            if (formationData is not ClientDto dto) return false;
            var entityVm = new ClientViewModel(dto);

            var formationWindow = CreateFormationWindow("Окно формирования клиента", "Клиент", entityVm);
            if (formationWindow.ShowDialog() is not true) return false;

            formationData = entityVm.Dto;
            return true;
        }
    }
}