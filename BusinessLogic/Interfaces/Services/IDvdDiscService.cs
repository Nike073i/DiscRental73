﻿using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Services;

public interface IDvdDiscService
{
    IEnumerable<DvdDiscResDto> GetAll();
    DvdDiscResDto GetById(int id);
    DvdDiscResDto Save(DvdDiscReqDto reqDto);
    bool DeleteById(int id);
}