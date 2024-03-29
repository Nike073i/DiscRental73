﻿using BusinessLogic.Interfaces.Storages.Base;
using DatabaseStorage.Entityes.Base;

namespace DatabaseStorage.Mappers.Base
{
    public interface IDbMapper<Req, Res, T> where Req : ReqDto, new() where Res : ResDto, new() where T : Entity, new()
    {
        void MapToEntity(in T entity, Req reqDto);
        Res MapToRes(T entity);
    }
}
