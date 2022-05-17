using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage.Repositories
{
    // НЕРЕАЛИЗОВАН //
    public class SellRepository : ISellRepository
    {
        protected readonly DiscRentalDb _db;
        protected readonly DbSet<Sell> _set;
        protected readonly SellMapper _mapper;

        public SellRepository(DiscRentalDb db)
        {
            _db = db;
            _set = db.Set<Sell>();
            _mapper = new SellMapper();
        }

        public void DeleteById(SellReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public ICollection<SellResDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public SellResDto GetById(SellReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Insert(SellReqDto reqDto)
        {
            throw new NotImplementedException();
        }
    }
}
