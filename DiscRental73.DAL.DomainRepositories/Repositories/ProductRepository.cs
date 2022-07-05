using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Interfaces.Repositories.Base;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class ProductRepository : DbRepository<ProductDto, Product>,
        IRepository<ProductDto>
    {
        #region readonly fields

        private readonly ProductMapper _Mapper;

        #endregion

        #region constructors

        public ProductRepository(DiscRentalDb db)
        {
            _Mapper = new ProductMapper();
            DbRepos = new DAL.Repositories.ProductRepository(db);
        }

        #endregion

        #region override abstract methods

        internal override IDbMapper<ProductDto, Product> Mapper => _Mapper;
        internal override DAL.Repositories.ProductRepository DbRepos { get; }

        #endregion
    }
}