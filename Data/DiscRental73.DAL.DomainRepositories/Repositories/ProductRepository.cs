using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class ProductRepository : DbRepository<ProductDto, ProductDetailDto, Product>
    {
        #region readonly fields

        private readonly IDbMapper<ProductDto, ProductDetailDto, Product> _DetailMapper;

        #endregion

        #region constructors

        public ProductRepository(DiscRentalDb db)
        {
            _DetailMapper = new ProductMapper();
            DbRepos = new DAL.Repositories.ProductRepository(db);
        }

        #endregion

        #region override abstract methods

        protected override IDbMapper<ProductDto, Product> Mapper => _DetailMapper;
        protected override IDbMapper<ProductDto, ProductDetailDto, Product> DetailMapper => _DetailMapper;
        protected override DAL.Repositories.ProductRepository DbRepos { get; }

        #endregion
    }
}