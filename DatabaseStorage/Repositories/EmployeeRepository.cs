using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;
using DatabaseStorage.Context;
using DatabaseStorage.Entityes;
using DatabaseStorage.Mappers;
using DatabaseStorage.Repositories.Base;

namespace DatabaseStorage.Repositories
{
    public class EmployeeRepository : PersonRepository<EmployeeReqDto, EmployeeResDto, Employee>, IEmployeeRepository
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ISellRepository _sellRepository;

        public EmployeeRepository(ISellRepository sellRepository, IRentalRepository rentalRepository)
        {
            _sellRepository = sellRepository;
            _rentalRepository = rentalRepository;
        }

        protected override EmployeeMapper CreateMapper() => new EmployeeMapper();

        public override ICollection<EmployeeResDto> GetAll()
        {
            using var db = new DiscRentalDb();
            var set = db.Set<Employee>();

            var data = set.Where(entity => !entity.IsDeleted).
                Select(rec => _mapper.MapToRes(rec)).ToList();
            data.ForEach(employee =>
                {
                    employee.Rentals = _rentalRepository.GetAll().Where(rec => rec.EmployeeId.Equals(employee.Id)).ToList();
                    employee.Sells = _sellRepository.GetAll().Where(rec => rec.EmployeeId.Equals(employee.Id)).ToList();
                });
            return data;
        }

        public override EmployeeResDto GetById(EmployeeReqDto reqDto)
        {
            using var db = new DiscRentalDb();
            var set = db.Set<Employee>();

            var entity = set.SingleOrDefault(rec => rec.Id.Equals(reqDto.Id));
            if (entity is null || entity.IsDeleted)
            {
                throw new Exception("Запись не найдена");
            }
            var data = _mapper.MapToRes(entity);
            data.Rentals = _rentalRepository.GetAll().Where(rec => rec.EmployeeId.Equals(data.Id)).ToList();
            data.Sells = _sellRepository.GetAll().Where(rec => rec.EmployeeId.Equals(data.Id)).ToList();
            return data;
        }
    }
}