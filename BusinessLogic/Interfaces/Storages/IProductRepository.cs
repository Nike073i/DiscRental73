﻿using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;

namespace BusinessLogic.Interfaces.Storages
{
    public interface IProductRepository
    {
        ICollection<ProductResDto> GetAll();
        ProductResDto GetById(ProductReqDto reqDto);
        void Insert(ProductReqDto reqDto);
        void Update(ProductReqDto reqDto);
    }
}
