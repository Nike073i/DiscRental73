﻿using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages.Base;

namespace BusinessLogic.Interfaces.Storages
{
    public interface IClientRepository : IPersonRepository<ClientReqDto, ClientResDto>
    {
    }
}
