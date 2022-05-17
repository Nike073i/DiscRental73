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
    public class RentalRepository : IRentalRepository
    {
        protected readonly DiscRentalDb _db;
        protected readonly DbSet<Rental> _set;
        protected readonly RentalMapper _mapper;

        public RentalRepository(DiscRentalDb db)
        {
            _db = db;
            _set = db.Set<Rental>();
            _mapper = new RentalMapper();
        }

        public void DeleteById(RentalReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public ICollection<RentalResDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public RentalResDto GetById(RentalReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Insert(RentalReqDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(RentalReqDto reqDto)
        {
            throw new NotImplementedException();
        }
    }
}
