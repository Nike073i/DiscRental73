﻿using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class ClientRepository : PersonRepository<ClientReqDto, ClientResDto, Client>, IClientRepository
    {
        protected override ClientMapper CreateMapper() => new();
    }
}
