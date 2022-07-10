﻿using DiscRental73.DAL.Context;
using DiscRental73.DAL.DomainRepositories.Mappers;
using DiscRental73.DAL.DomainRepositories.Mappers.Base;
using DiscRental73.DAL.DomainRepositories.Repositories.Base;
using DiscRental73.DAL.Entities;
using DiscRental73.Domain.DtoModels.DetailDto;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73.DAL.DomainRepositories.Repositories
{
    public class RentalRepository : DbRepository<RentalDto, RentalDetailDto, Rental>
    {
        #region readonly fields

        private readonly IDbMapper<RentalDto, RentalDetailDto, Rental> _DetailMapper;

        #endregion

        #region constructors

        public RentalRepository(DiscRentalDb db)
        {
            _DetailMapper = new RentalMapper();
            DbRepos = new DAL.Repositories.RentalRepository(db);
        }

        #endregion

        #region override abstract methods

        protected override IDbMapper<RentalDto, Rental> Mapper => _DetailMapper;
        protected override IDbMapper<RentalDto, RentalDetailDto, Rental> DetailMapper => _DetailMapper;
        protected override DAL.Repositories.RentalRepository DbRepos { get; }

        #endregion
    }
}