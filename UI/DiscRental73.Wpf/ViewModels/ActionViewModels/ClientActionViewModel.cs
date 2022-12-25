﻿using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Services.Base;
using DiscRental73.Wpf.Infrastructure.FormationServices;
using DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies;
using DiscRental73.Wpf.ViewModels.Base;

namespace DiscRental73.Wpf.ViewModels.ActionViewModels
{
    public class ClientActionViewModel : CrudActionViewModel<ClientDto>
    {
        public ClientActionViewModel(ICrudService<ClientDto> service, IFormationService formationService)
            : base(service, formationService, new ClientEditStrategy())
        {
            ActionHeader = "Клиенты";
        }
    }
}