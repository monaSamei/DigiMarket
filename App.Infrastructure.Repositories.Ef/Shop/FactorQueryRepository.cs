using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Dtos;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Shop
{
    public class FactorQueryRepository:IFactorQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public FactorQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<FactorDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Factors.Select(x => new FactorDto()
            {
                Id = x.Id,
                SellerId = x.SellerId,
                CustomerId = x.CustomerId,
                IsAccepted = x.IsAccepted,
                TotalPrice = x.TotalPrice,
                CreatedAt =x.CreatedAt,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
                IsDeleted = x.IsDeleted
            }
           ).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return entity;
        }

        public async Task<List<FactorDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Factors.Select(x => new FactorDto()
            {
                Id = x.Id,
                SellerId = x.SellerId,
                CustomerId = x.CustomerId,
                IsAccepted = x.IsAccepted,
                TotalPrice = x.TotalPrice,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
            }
         ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
