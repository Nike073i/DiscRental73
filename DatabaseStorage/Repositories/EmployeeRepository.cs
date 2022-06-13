using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;
using DatabaseStorage.Context;
using DatabaseStorage.Entities;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class EmployeeRepository : PersonRepository<EmployeeReqDto, EmployeeResDto, Employee>, IEmployeeRepository
    {
        private readonly IRentalRepository _RentalRepository;
        private readonly ISellRepository _SellRepository;

        public EmployeeRepository(DiscRentalDb db, ISellRepository sellRepository, IRentalRepository rentalRepository) : base(db)
        {
            _SellRepository = sellRepository;
            _RentalRepository = rentalRepository;
        }

        protected override EmployeeMapper CreateMapper() => new();

        protected override IEnumerable<EmployeeResDto> DoGetAll(in DiscRentalDb db)
        {
            var set = db.Set<Employee>();

            var data = set.Where(entity => !entity.IsDeleted).
                Select(rec => Mapper.MapToRes(rec)).ToList();
            data.ForEach(employee =>
                {
                    employee.Rentals = _RentalRepository.GetAll().Where(rec => rec.EmployeeId.Equals(employee.Id)).ToList();
                    employee.Sells = _SellRepository.GetAll().Where(rec => rec.EmployeeId.Equals(employee.Id)).ToList();
                });
            return data;
        }

        protected override EmployeeResDto DoGetById(in DiscRentalDb db, int id)
        {
            var set = db.Set<Employee>();

            var entity = set.SingleOrDefault(rec => rec.Id.Equals(id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            var data = Mapper.MapToRes(entity);
            data.Rentals = _RentalRepository.GetAll().Where(rec => rec.EmployeeId.Equals(data.Id)).ToList();
            data.Sells = _SellRepository.GetAll().Where(rec => rec.EmployeeId.Equals(data.Id)).ToList();
            return data;
        }
    }
}