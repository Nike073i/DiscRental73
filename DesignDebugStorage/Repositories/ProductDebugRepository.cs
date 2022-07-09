using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DesignDebugStorage.Repositories
{
    public class ProductDebugRepository : IRepository<ProductDto>
    {
        private readonly IEnumerable<ProductDto> _Products = Enumerable.Range(1, 10).Select(i => new ProductDto
        {
            Id = i,
            Cost = i,
            //DiscDate = DateTime.Now,
            DiscId = i,
            //DiscTitle = $"Диск - {i}",
            //DiscType = DiscType.CD,
            Quantity = i
        });

        public int Insert(ProductDto reqDto)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        public ProductDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetAll() => _Products;

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}