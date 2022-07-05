using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class ProductRepository : DbRepository<ProductDto, ProductDetailDto, Product>,
        IRepository<ProductDto, ProductDetailDto>
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

        internal override IDbMapper<ProductDto, Product> Mapper => _DetailMapper;
        internal override IDbMapper<ProductDto, ProductDetailDto, Product> DetailMapper => _DetailMapper;
        internal override DAL.Repositories.ProductRepository DbRepos { get; }

        #endregion
    }
}